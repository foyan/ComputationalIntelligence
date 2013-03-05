namespace EA {

    public interface IIndividual {
        
        string Code { get; set; }
        
        void Decode();

        FitResult Fit();

        Value GetObjectParams(int index);

        int NumberOfObjectParams { get; }

    }

}