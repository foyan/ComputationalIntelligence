﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EA.Tests {

    public class Reporter {

        private readonly List<Item> _reports = new List<Item>();

        private double _bestest = double.MaxValue;

        public void Report(int generation, IEnumerable<IIndividual> population) {
            var pop = population.Where(p => p.Fit().IsFit).Select(p => p.Fit().Value).ToList();

            _bestest = Math.Min(_bestest, pop.Min());

            _reports.Add(new Item {
                                      Min = pop.Min(),
                                      Max = pop.Max(),
                                      Sigma = Math.Sqrt(pop.Sum(p => Math.Pow(pop.Average() - p, 2))/pop.Count),
                                      Generation = generation,
                                      Count = pop.Count,
                                      Bestest = _bestest
                                  });

        }

        public void Write() {
            Console.WriteLine(string.Join("\r\n", _reports.Select(r => "#" + r.Generation + ": min=" + r.Min + ",max=" + r.Max + ",sigma=" + r.Sigma + ",count=" + r.Count + ",bestest=" + r.Bestest)));
        }

        private class Item {

            public int Generation { get; set; }

            public double Min { get; set; }

            public double Max { get; set; }

            public double Sigma { get; set; }

            public int Count { get; set; }

            public double Bestest { get; set; }

        }

    }

}
