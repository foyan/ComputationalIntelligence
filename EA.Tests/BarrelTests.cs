using NUnit.Framework;

namespace EA.Tests {

    public class BarrelTests {

        private Barrel _instance;

        [SetUp]
        public void SetUp() {
            _instance = new Barrel();
        }

        [Test]
        public void ShouldDecodeToZeroZero() {
            _instance.Code = "0000000000";
            _instance.Decode();
            Assert.That(_instance.D.Val, Is.EqualTo(0));
            Assert.That(_instance.H.Val, Is.EqualTo(0));
        }

        [Test]
        public void ShouldDecodeToOneOne() {
            _instance.Code = "1000010000";
            _instance.Decode();
            Assert.That(_instance.D.Val, Is.EqualTo(1));
            Assert.That(_instance.H.Val, Is.EqualTo(1));
        }

    }

}
