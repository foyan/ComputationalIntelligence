using System.Linq;

namespace EA {

    public class BinaryMutator : IMutator {

        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public double Probability { get; set; }

        public BinaryMutator(IRandomNumberGenerator randomNumberGenerator) {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public void Mutate(IIndividual individual) {

            var code = individual.Code;

            code = code.Select(ch => {
                                   var z = _randomNumberGenerator.GetDouble(0, 1);
                                   if (z < Probability) {
                                       return ch == '0' ? '1' : '0';
                                   }
                                   return ch;
                               }).Aggregate("", (s, c) => s + c);

            individual.Code = code;

        }

    }

}
