using System;

namespace EA {

    public interface IIndividual {

        Func<double> F { get; }
        
        Func<bool> G { get; }
        
        string Code { get; set; }
        
        void Decode();

        FitResult Fit();

    }

}