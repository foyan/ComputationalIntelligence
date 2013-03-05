using System;

namespace EA {

    public class IsotropicMutator : IMutator {

        public double Probability { get; set; }

        public Func<double, double> Tau { get; set; }

        public Func<IIndividual, Value> GetSigma { get; set; }

        private readonly IRandomNumberGenerator _random;

        public IsotropicMutator(IRandomNumberGenerator random) {
            _random = random;
        }

        public void Mutate(IIndividual individual) {

            if (_random.GetDouble(0, 1) >= Probability) {
                return;
            }

            var u = individual.NumberOfObjectParams;
            var sigma = GetSigma(individual);

            individual.ForEachObjectParam(o => o.Val += _random.StandardDistributed(0, sigma.Val));

        }

    }

}
