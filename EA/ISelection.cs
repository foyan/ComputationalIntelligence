using System.Collections.Generic;

namespace EA {

    public interface ISelection {

        IIndividual Select(IEnumerable<IIndividual> source);

    }

}