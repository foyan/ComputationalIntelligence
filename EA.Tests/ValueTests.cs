using NUnit.Framework;

namespace EA.Tests {

    public class ValueTests {

        private Value _instance;

        [SetUp]
        public void SetUp() {
            _instance = new Value();
        }

        [Test]
        public void BinaryEncodingLengthShouldBeFive() {
            _instance.Min = 0;
            _instance.Max = 31;

            var length = _instance.GetBinaryEncodingLength();

            Assert.That(length, Is.EqualTo(5));
        }

        [Test]
        public void ValueShouldDecodeCorrectly1() {
            _instance.Min = 0;
            _instance.Max = 31;

            _instance.DecodeBinary("01000");
            
            Assert.That(_instance.Val, Is.EqualTo(2));
        }

        [Test]
        public void ValueShouldDecodeCorrectly2() {
            _instance.Min = 0;
            _instance.Max = 31;

            _instance.DecodeBinary("11000");

            Assert.That(_instance.Val, Is.EqualTo(3));
        }

        [Test]
        public void ValueShouldDecodeCorrectly3() {
            _instance.Min = 0;
            _instance.Max = 31;

            _instance.DecodeBinary("11111");

            Assert.That(_instance.Val, Is.EqualTo(31));
        }

    }

}
