using System;
using System.Collections.Generic;
using System.Linq;

namespace EA {

    public class DiscreteRecombiner : IRecombiner {

        private readonly IRandomNumberGenerator _random;

        public Func<IIndividual> Create { get; set; } 

        public DiscreteRecombiner(IRandomNumberGenerator random) {
            _random = random;
        }

        public IEnumerable<IIndividual> Recombine(IEnumerable<IIndividual> parents) {

            var p = parents.ToList();

            var i = Create();
            Enumerable.Range(0, p[0].NumberOfObjectParams).ToList().ForEach(x => i.GetObjectParams(x).Val = p[_random.GetInt(0, p.Count)].GetObjectParams(x).Val);
            yield return i;

        }

    }

}
