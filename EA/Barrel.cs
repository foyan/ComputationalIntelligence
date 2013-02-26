using System;

namespace EA {

    public class Barrel : IIndividual {

        public Barrel() {
            D = new Value {Min = 0, Max = 31};
            H = new Value {Min = 0, Max = 31};

            F = () => Math.PI * D.Val * D.Val / 2.0 + Math.PI * D.Val * H.Val;
            G = () => Math.PI * D.Val * D.Val * H.Val / 4 >= 300;
        }

        public Value D { get; private set; }

        public Value H { get; private set; }

        public Func<double> F { get; private set; }

        public Func<bool> G { get; private set; }

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

        public FitResult Fit() {
            return new FitResult { IsFit = G(), Value = F() };
        }

        public override string ToString() {
            return "d=" + D.Val + ",h=" + H.Val + ",F(d,h)=" + F() + ",G(d,h)=" + G();
        }

    }

}
