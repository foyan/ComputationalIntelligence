using System.Linq;
using NUnit.Framework;

namespace EA.Tests {

    public class Vega {

        private RandomizedBinaryEncoder _encoder;
        private ISelection _selection;
        private IMutator _mutator;
        private IRecombiner _recombiner;

        private Reporter _reporter;
        private RandomNumberGenerator _random;

        [SetUp]
        public void SetUp() {
            _encoder = new RandomizedBinaryEncoder();
            _selection = new RankSelection(new RandomNumberGenerator());
            _mutator = new BinaryMutator(new RandomNumberGenerator()) { Probability = 0.1 };
            _recombiner = new SinglePointRecombiner(new RandomNumberGenerator()) { Create = () => new VegaBarrel() };
            _reporter = new Reporter();
            _random = new RandomNumberGenerator();
        }

        [Test]
        public void Run() {

            // initialize
            var population = Enumerable.Range(0, 30).Select(i => new VegaBarrel()).ToList();
            population.ForEach(b => b.Code = _encoder.GetCode(b.D.GetBinaryEncodingLength() + b.H.GetBinaryEncodingLength()));
            population.ForEach(b => b.Decode());

            _reporter.Report(0, population);

            try {

                for (var r = 1; r <= 100; r++) {

                    _reporter.Report(r, population);

                    var pop = population.ToList();

                    var parents = Enumerable.Range(0, 10).Select(i => {

                                                                     var b = _selection.Select(pop) as VegaBarrel;
                                                                     pop.Remove(b);
                                                                     return b;
                                                                 }).ToList();

                    var newChildren = Enumerable.Range(0, 5).SelectMany(i => _recombiner.Recombine(parents.Skip(i * 2).Take(2))).OfType<VegaBarrel>();

                    var children = pop.Except(parents).Union(newChildren).ToList();

                    // mutation
                    children.ForEach(_mutator.Mutate);

                    children.ForEach(b => b.Decode());

                    children = Enumerable.Range(0, 30).Select(i => _selection.Select(children)).OfType<VegaBarrel>().ToList();

                    var pool = children.ToList();
                    Enumerable.Range(0, 15).ToList().ForEach(i => pool.RemoveAt(_random.GetInt(0, pool.Count - 1)));
                    children.ForEach(b => b.IndexOfF = pool.Contains(b) ? 1 : 0);

                    // selection
                    population = children;

                }
            } finally {

                _reporter.Write();

                _reporter.ReportLast();
            }

        }

    }

}
