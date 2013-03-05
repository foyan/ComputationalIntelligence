using System.Linq;
using NUnit.Framework;

namespace EA.Tests {

    public class Slide35 {

        private RandomizedBinaryEncoder _encoder;
        private ISelection _selection;
        private IMutator _mutator;
        private IRecombiner _recombiner;

        private Reporter _reporter;

        [SetUp]
        public void SetUp() {
            _encoder = new RandomizedBinaryEncoder();
            _selection = new RankSelection(new RandomNumberGenerator());
            _mutator = new Mutator(new RandomNumberGenerator()) { Probability = 0.1 };
            _recombiner = new SinglePointRecombiner(new RandomNumberGenerator());
            _reporter = new Reporter();
        }

        [Test]
        public void Run() {

            // initialize
            var population = Enumerable.Range(0, 30).Select(i => new Barrel()).ToList();
            population.ForEach(b => b.Code = _encoder.GetCode(b.D.GetBinaryEncodingLength() + b.H.GetBinaryEncodingLength()));
            population.ForEach(b => b.Decode());

            _reporter.Report(0, population);

            try {

                for (var r = 1; r <= 100; r++) {

                    _reporter.Report(r, population);

                    var pop = population.ToList();

                    var parents = Enumerable.Range(0, 10).Select(i => {

                        var b = _selection.Select(pop) as Barrel;
                        pop.Remove(b);
                        return b;
                    }).ToList();

                    var newChildren = Enumerable.Range(0, 5).SelectMany(i => _recombiner.Recombine(parents.Skip(i * 2).Take(2))).OfType<Barrel>();

                    var children = pop.Except(parents).Union(newChildren).ToList();

                    // mutation
                    children.ForEach(b => b.Code = _mutator.MutateCode(b.Code));

                    children = children.Select(b => new Barrel { Code = b.Code }).ToList();
                    children.ForEach(b => b.Decode());


                    children = Enumerable.Range(0, 30).Select(i => _selection.Select(children)).OfType<Barrel>().ToList();

                    // selection
                    population = children;

                }
            } finally {

                _reporter.Write();
            }

        }

    }

}
