using System;

namespace EA {

    public static class SyntaxSugar {

        public static int GaussianSum(this int i) {
            return i*(i + 1)/2;
        }

        public static double StandardDistributed(this double x, double mu, double sigma) {
            return 1.0/(sigma*Math.Sqrt(2*Math.PI))*Math.Exp(-0.5*(x - mu)*(x - mu)/(sigma*sigma));
        }

    }

}
