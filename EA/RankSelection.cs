using System.Collections.Generic;
using System.Linq;

namespace EA {

    public class RankSelection : ISelection {

        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public RankSelection(IRandomNumberGenerator randomNumberGenerator) {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public IIndividual Select(IEnumerable<IIndividual> source) {

            var individuals = source
                .Select(i => new {
                                     individual = i,
                                     fit = i.Fit()
                                 })
                .Where(i => i.fit.IsFit)
                .OrderByDescending(i => i.fit.Value)
                .ToList();

            var z = _randomNumberGenerator.GetDouble(0, individuals.Count.GaussianSum());

            var index = Enumerable.Range(1, individuals.Count).Single(i => z >= (i - 1).GaussianSum() && z < i.GaussianSum());

            return individuals[index-1].individual;

        }

    }

}
