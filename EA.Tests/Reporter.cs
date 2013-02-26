using System;
using System.Collections.Generic;
using System.Linq;

namespace EA.Tests {

    public class Reporter {

        private readonly List<Item> _reports = new List<Item>(); 

        public void Report(int generation, IEnumerable<IIndividual> population) {
            var pop = population.Select(p => p.Fit().Value).ToList();

            _reports.Add(new Item {
                                      Min = pop.Min(),
                                      Max = pop.Max(),
                                      Sigma = Math.Sqrt(pop.Sum(p => Math.Pow(pop.Average() - p, 2))/pop.Count),
                                      Generation = generation
                                  });
        }

        public void Write() {
            Console.WriteLine(string.Join("\r\n", _reports.Select(r => "#" + r.Generation + ": min=" + r.Min + ",max=" + r.Max + ",sigma=" + r.Sigma)));
        }

        private class Item {

            public int Generation { get; set; }

            public double Min { get; set; }

            public double Max { get; set; }

            public double Sigma { get; set; }

        }

    }

}
