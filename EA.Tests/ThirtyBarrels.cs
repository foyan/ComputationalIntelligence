using System.Linq;
using NUnit.Framework;

namespace EA.Tests {

    public class ThirtyBarrels {

        private RandomizedBinaryEncoder _encoder;
        private ISelection _selection;
        private IRecombiner _recombiner;
        private IMutator _mutator;

        private Reporter _reporter;

        [SetUp]
        public void SetUp() {
            _encoder = new RandomizedBinaryEncoder();
            _selection = new RankSelection(new RandomNumberGenerator());
            _recombiner = new SinglePointRecombiner(new RandomNumberGenerator()) {Create = () => new Barrel()};
            _mutator = new BinaryMutator(new RandomNumberGenerator()) {Probability = 0.005};
            _reporter = new Reporter();
        }

        [Test]
        public void Run() {
            
            // initialize
            var population = Enumerable.Range(0, 30).Select(i => new Barrel()).ToList();
            population.ForEach(b => b.Code = _encoder.GetCode(b.D.GetBinaryEncodingLength() + b.H.GetBinaryEncodingLength()));
            population.ForEach(b => b.Decode());

            _reporter.Report(0, population);

            for (var r = 1; r <= 100; r++) {
                // reproduction
                var parents = Enumerable.Range(0, 2).Select(i => _selection.Select(population)).OfType<Barrel>().ToList();
                parents.ForEach(b => b.Decode());

                var children = Enumerable.Range(0, 15).SelectMany(i => _recombiner.Recombine(parents)).OfType<Barrel>().ToList();

                // mutation
                //children.ForEach(b => b.Code = _mutator.MutateCode(b.Code));

                children.ForEach(b => b.Decode());

                // selection
                population = children;

                _reporter.Report(r, population);
            }

            _reporter.Write();
        }

    }

}
