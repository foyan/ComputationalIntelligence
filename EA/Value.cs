using System;
using System.Linq;

namespace EA {

    public class Value {

        public double Val { get; set; }

        public double Min { get; set; }

        public double Max { get; set; }

        public int GetBinaryEncodingLength() {
            return (int) Math.Ceiling(Math.Log(Max - Min + 1)/Math.Log(2));
        }

        public void DecodeBinary(string code) {
            Val = Min + (Max - Min)/(Math.Pow(2, GetBinaryEncodingLength()) - 1)
                  *Enumerable.Range(0, GetBinaryEncodingLength()).Sum(j => int.Parse(code[j].ToString())*Math.Pow(2, j));

        }

        public void DecodeReal(string code) {
            Val = double.Parse(code);
        }
    
    }

}
