using System;
using System.Collections.Generic;
using System.Linq;

namespace EA {

    public class MeanRecombiner : IRecombiner {

        public Func<IIndividual> Create { get; set; } 

        public IEnumerable<IIndividual> Recombine(IEnumerable<IIndividual> parents) {
            var p = parents.ToList();

            var i = Create();
            Enumerable.Range(0, p[0].NumberOfObjectParams).ToList().ForEach(x => i.GetObjectParams(x).Val = p.Average(y => y.GetObjectParams(x).Val));
            yield return i;
        }

    }

}
