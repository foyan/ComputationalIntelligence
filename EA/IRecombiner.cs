using System.Collections.Generic;

namespace EA {

    public interface IRecombiner {
        IEnumerable<IIndividual> Recombine(IEnumerable<IIndividual> parents);
    }

}