using System;
using System.Collections.Generic;
using System.Linq;

namespace EA {

    public class SinglePointRecombiner : IRecombiner {

        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public Func<IIndividual> Create { get; set; }

        public SinglePointRecombiner(IRandomNumberGenerator randomNumberGenerator) {
            _randomNumberGenerator = randomNumberGenerator;
        }

        private IIndividual CreateIndividual(string code) {
            var i = Create();
            i.Code = code;
            return i;
        }

        public IEnumerable<IIndividual> Recombine(IEnumerable<IIndividual> parents) {

            var ps = parents.ToList();
            if (ps.Count != 2) {
                throw new Exception("Mom required, dad required.");
            }

            var mom = ps[0]; var dad = ps[1];

            var index = _randomNumberGenerator.GetInt(0, mom.Code.Length);

            yield return CreateIndividual(mom.Code.Substring(0, index) + dad.Code.Substring(index));
            yield return CreateIndividual(dad.Code.Substring(0, index) + mom.Code.Substring(index));

        }

    }

}
