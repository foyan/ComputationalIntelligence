using System;
using System.Globalization;
using System.Linq;

namespace EA.Tests {

    class RandomizedBinaryEncoder {

        private readonly Random _random = new Random();

        public string GetCode(int length) {
            return string.Join("", Enumerable.Range(0, length).Select(i => _random.Next(2).ToString(CultureInfo.InvariantCulture)));
        }

    }

}
