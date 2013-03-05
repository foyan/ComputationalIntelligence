using System.Collections.Generic;
using System.Linq;

namespace EA {

    public class MeanRecombiner : IRecombiner {

        public IEnumerable<IIndividual> Recombine(IEnumerable<IIndividual> parents) {
            var p = parents.ToList();
            yield return p.
        }

    }

}
