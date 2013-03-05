using System;

namespace EA {

    public class VegaBarrel : IIndividual {

        public VegaBarrel() {
            D = new Value { Min = 0, Max = 31 };
            H = new Value { Min = 0, Max = 31 };

            F1 = () => Math.PI * D.Val * D.Val / 2.0 + Math.PI * D.Val * H.Val;
            F2 = () => Math.PI*D.Val*D.Val*H.Val/4;
        }

        public int IndexOfF { get; set; }

        public Value D { get; private set; }

        public Value H { get; private set; }

        public Func<double> F1 { get; private set; }

        public Func<double> F2 { get; private set; }

        public string Code { get; set; }

        public void Decode() {
            if (Code == null) {
                throw new Exception("Code is null.");
            }
            if (Code.Length != D.GetBinaryEncodingLength() + H.GetBinaryEncodingLength()) {
                throw new Exception("Code length is invalid.");
            }

            D.DecodeBinary(Code.Substring(0, D.GetBinaryEncodingLength()));
            H.DecodeBinary(Code.Substring(D.GetBinaryEncodingLength()));
        }

        public Value GetObjectParams(int index) {
            return index == 0 ? D : H;
        }

        public int NumberOfObjectParams {
            get { return 2; }
        }

        public FitResult Fit() {
            return new FitResult { IsFit = true, Value = IndexOfF == 1 ? F1() : -F2() };
        }

        public override string ToString() {
            return "d=" + D.Val + ",h=" + H.Val + ",F1(d,h)=" + F1() + ",F2(d,h)=" + F2();
        }

    }

}
