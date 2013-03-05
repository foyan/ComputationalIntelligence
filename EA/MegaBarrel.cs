using System;

namespace EA {

    public class MegaBarrel : IIndividual {

        public MegaBarrel() {
            D = new Value { Min = 0, Max = 31 };
            H = new Value { Min = 0, Max = 31 };

            F = () => Math.PI * D.Val * D.Val / 2.0 + Math.PI * D.Val * H.Val;
            G = () => Math.PI * D.Val * D.Val * H.Val / 4 >= 300;
        }

        public Value D { get; private set; }

        public Value H { get; private set; }

        public Func<double> F { get; private set; }

        public Func<bool> G { get; private set; }

        public string Code { get; set; }

        public void Decode() {
            var code = Code.Split('|');
            D.DecodeReal(code[0]);
            H.DecodeReal(code[1]);
        }

        public FitResult Fit() {
            return new FitResult { IsFit = G(), Value = F() };
        }

        public Value GetObjectParams(int index) {
            return index == 0 ? D : H;
        }

        public int NumberOfObjectParams {
            get { return 2; }
        }

        public override string ToString() {
            return "d=" + D.Val + ",h=" + H.Val + ",F(d,h)=" + F() + ",G(d,h)=" + G();
        }

    }

}
