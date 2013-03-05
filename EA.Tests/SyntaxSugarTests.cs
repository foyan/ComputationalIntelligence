using System;
using System.Linq;
using NUnit.Framework;

namespace EA.Tests {

    public class SyntaxSugarTests {

        [Test]
        public void StandardDistribution01ShouldWorkWith0() {
            Assert.That(0d.StandardDistributed(0, 1), Is.EqualTo(1.0/(Math.Sqrt(2*Math.PI))));
        }

        [Test]
        public void StandardDistribution02ShouldWorkWith0() {
            Assert.That(0d.StandardDistributed(0, 2), Is.EqualTo(0.5 / (Math.Sqrt(2 * Math.PI))));
        }

        [Test]
        public void StandardDistribution11ShouldWorkWith1() {
            Assert.That(1d.StandardDistributed(1, 1), Is.EqualTo(1.0 / (Math.Sqrt(2 * Math.PI))));
        }

        [Test]
        public void StandardDistribution02ShouldWorkWith1() {
            Assert.That(1d.StandardDistributed(0, 2), Is.EqualTo(0.5 / (Math.Sqrt(2 * Math.PI)) * Math.Exp(-1d/8d)));
        }

        [Test]
        public void StandardDistribution01ShouldHaveIntegralOf1() {
            var integral = Enumerable.Range(0, 20).Select(i => -10 + i/1d).Sum(x => x.StandardDistributed(0, 1));
            Assert.That(integral, Is.EqualTo(1.0).Within(0.00000001));
        }

        [Test]
        public void StandardDistributionShouldBeABell() {
            var rnd = new RandomNumberGenerator();
            var distribution = Enumerable.Range(0, 1000000).Select(x => rnd.StandardDistributed(0, 1)).GroupBy(x => (int)(x / 6d * 100d)).OrderBy(x => x.Key).Select(x => (double)x.Count() / 10000d).ToList();
        }

    }

}
