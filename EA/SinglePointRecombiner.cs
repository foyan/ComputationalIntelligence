using System;
using System.Collections.Generic;
using System.Linq;

namespace EA {

    public class SinglePointRecombiner : IRecombiner {

        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public SinglePointRecombiner(IRandomNumberGenerator randomNumberGenerator) {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public IEnumerable<IIndividual> Recombine(IEnumerable<IIndividual> parents) {

            var ps = parents.ToList();
            if (ps.Count != 2) {
                throw new Exception("Mom required, dad required.");
            }

            var mom = ps[0]; var dad = ps[1];

            var index = _randomNumberGenerator.GetInt(0, mom.Code.Length);

            yield return new Barrel {
                Code = mom.Code.Substring(0, index) + dad.Code.Substring(index)
            };

            yield return new Barrel {
                Code = dad.Code.Substring(0, index) + mom.Code.Substring(index)
            };

        }

    }

}
