using System;
using System.Linq;

namespace EA {

    public static class SyntaxSugar {

        public static int GaussianSum(this int i) {
            return i*(i + 1)/2;
        }

        public static double StandardDistributed(this double x, double mu, double sigma) {
            return 1.0/(sigma*Math.Sqrt(2*Math.PI))*Math.Exp(-0.5*(x - mu)*(x - mu)/(sigma*sigma));
        }

        public static double StandardDistributed(this IRandomNumberGenerator generator, double mu, double sigma) {
            while (true) {
                var x = generator.GetDouble(-10 * sigma, +10 * sigma);
                var z = generator.GetDouble(0, 1);
                if (z < x.StandardDistributed(mu, sigma)) {
                    return x;
                }
            }
        }

        public static void ForEachObjectParam(this IIndividual self, Action<Value> code) {
            Enumerable.Range(0, self.NumberOfObjectParams).ToList().ForEach(i => code(self.GetObjectParams(i)));
        }

    }

}
