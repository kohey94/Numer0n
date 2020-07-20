using NUnit.Framework;
using static Numer0n.Common.Utilities.Validation;

namespace Numer0nCommonTest.Utilities
{
    class ValidationTest
    {

        /// <summary>
        /// 1桁の数字のバリデーションテスト
        /// </summary>
        [Test]
        public void IsSingleDigitNumberTest01()
        {
            Assert.IsTrue(IsSingleDigitNumber("1"));
        }

        [Test]
        public void IsSingleDigitNumberTest02()
        {
            Assert.IsTrue(IsSingleDigitNumber("2"));
        }

        [Test]
        public void IsSingleDigitNumberTest03()
        {
            Assert.IsTrue(IsSingleDigitNumber("3"));
        }

        [Test]
        public void IsSingleDigitNumberTest04()
        {
            Assert.IsTrue(IsSingleDigitNumber("4"));
        }

        [Test]
        public void IsSingleDigitNumberTest05()
        {
            Assert.IsTrue(IsSingleDigitNumber("5"));
        }

        [Test]
        public void IsSingleDigitNumberTest06()
        {
            Assert.IsTrue(IsSingleDigitNumber("6"));
        }

        [Test]
        public void IsSingleDigitNumberTest07()
        {
            Assert.IsTrue(IsSingleDigitNumber("7"));
        }

        [Test]
        public void IsSingleDigitNumberTest08()
        {
            Assert.IsTrue(IsSingleDigitNumber("8"));
        }

        [Test]
        public void IsSingleDigitNumberTest09()
        {
            Assert.IsTrue(IsSingleDigitNumber("9"));
        }

        [Test]
        public void IsSingleDigitNumberTest10()
        {
            Assert.IsTrue(IsSingleDigitNumber("0"));
        }

        [Test]
        public void IsSingleDigitNumberTest11()
        {
            Assert.IsFalse(IsSingleDigitNumber("10"));
        }

        [Test]
        public void IsSingleDigitNumberTest12()
        {
            Assert.IsFalse(IsSingleDigitNumber(""));
        }

        [Test]
        public void IsSingleDigitNumberTest13()
        {
            Assert.IsFalse(IsSingleDigitNumber("a"));
        }

        [Test]
        public void IsSingleDigitNumberTest14()
        {
            Assert.IsFalse(IsSingleDigitNumber("@"));
        }
    }
}
