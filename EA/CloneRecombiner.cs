using System.Collections.Generic;
using System.Linq;

namespace EA {

    public class CloneRecombiner : IRecombiner {

        public int Count { get; set; }

        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public CloneRecombiner(IRandomNumberGenerator randomNumberGenerator) {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public IEnumerable<IIndividual> Recombine(IEnumerable<IIndividual> parents) {
            var list = parents.ToList();

            return Enumerable.Range(0, Count).Select(i => new Barrel {Code = list[_randomNumberGenerator.GetInt(0, list.Count)].Code});
        }

    }

}
