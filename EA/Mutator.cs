using System.Linq;

namespace EA {

    public class Mutator : IMutator {

        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public double Probability { get; set; }

        public Mutator(IRandomNumberGenerator randomNumberGenerator) {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public string MutateCode(string code) {

            return code.Select(ch => {
                                   var z = _randomNumberGenerator.GetDouble(0, 1);
                                   if (z < Probability) {
                                       return ch == '0' ? '1' : '0';
                                   }
                                   return ch;
                               }).Aggregate("", (s, c) => s + c);

        }

    }

}
