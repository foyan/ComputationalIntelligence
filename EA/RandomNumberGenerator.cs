using System;

namespace EA {

    public class RandomNumberGenerator : IRandomNumberGenerator {

        private readonly Random _random = new Random();

        public int GetInt(int start, int end) {
            return _random.Next(start, end);
        }

        public double GetDouble(double start, double end) {
            return _random.NextDouble()*(end - start) + start;
        }

    }

}
