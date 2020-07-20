using Numer0n.Common.Services;
using NUnit.Framework;

namespace Numer0nCommonTest.Services
{
    class Numer0nServiceTest
    {
        private INumer0nService _numer0nService;
        [SetUp]
        public void Setup()
        {
            _numer0nService = new Numer0nService();
        }

        /// <summary>
        /// インスタンス生成時のテスト
        /// </summary>
        [Test]
        public void ConstructorTest1()
        {
            var numer0nService = new Numer0nService();
            Assert.AreEqual(numer0nService.Numer0nDigit, 4);
        }

        [Test]
        public void ConstructorTest2()
        {
            var numer0nService = new Numer0nService(5);
            Assert.AreEqual(numer0nService.Numer0nDigit, 5);
        }


        /// <summary>
        /// バリデーションのテスト
        /// </summary>
        [Test]
        public void TryValidationInputValueTest1()
        {
            var isValidate = _numer0nService.TryValidationInputValue("1234", out char[] validationedValue);
            
            Assert.IsTrue(isValidate);
            Assert.AreEqual(validationedValue, new char[]{'1','2','3','4'});
        }

        [Test]
        public void TryValidationInputValueTest2()
        {
            var isValidate = _numer0nService.TryValidationInputValue("123", out char[] validationedValue);

            Assert.IsFalse(isValidate);
            Assert.IsNull(validationedValue);
        }

        [Test]
        public void TryValidationInputValueTest3()
        {
            var isValidate = _numer0nService.TryValidationInputValue("12345", out char[] validationedValue);

            Assert.IsFalse(isValidate);
            Assert.IsNull(validationedValue);
        }

        [Test]
        public void TryValidationInputValueTest4()
        {
            var isValidate = _numer0nService.TryValidationInputValue("abcd", out char[] validationedValue);

            Assert.IsFalse(isValidate);
            Assert.IsNull(validationedValue);
        }

        [Test]
        public void TryValidationInputValueTest5()
        {
            var isValidate = _numer0nService.TryValidationInputValue("", out char[] validationedValue);

            Assert.IsFalse(isValidate);
            Assert.IsNull(validationedValue);
        }

        /// <summary>
        /// 判定処理のテスト
        /// </summary>
        [Test]
        public void JudgmentTest01()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '2', '3', '4' }, new char[] { '1', '2', '3', '4' });
            
            Assert.IsTrue(isCurrent);
            Assert.AreEqual(pnh, 4);
            Assert.AreEqual(nh, 0);
        }

        [Test]
        public void JudgmentTest02()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '2', '3', '5' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 3);
            Assert.AreEqual(nh, 0);
        }

        [Test]
        public void JudgmentTest03()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '2', '6', '7' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 2);
            Assert.AreEqual(nh, 0);
        }

        [Test]
        public void JudgmentTest04()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '5', '6', '7' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 1);
            Assert.AreEqual(nh, 0);
        }

        [Test]
        public void JudgmentTest05()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '2', '3', '4', '1' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 0);
            Assert.AreEqual(nh, 4);
        }

        [Test]
        public void JudgmentTest06()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '0', '3', '4', '1' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 0);
            Assert.AreEqual(nh, 3);
        }

        [Test]
        public void JudgmentTest07()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '9', '1', '2', '7' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 0);
            Assert.AreEqual(nh, 2);
        }

        [Test]
        public void JudgmentTest08()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '9', '1', '6', '7' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 0);
            Assert.AreEqual(nh, 1);
        }

        [Test]
        public void JudgmentTest09()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '5', '6', '7', '8' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 0);
            Assert.AreEqual(nh, 0);
        }

        [Test]
        public void JudgmentTest10()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '5', '6', '2' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 1);
            Assert.AreEqual(nh, 1);
        }

        [Test]
        public void JudgmentTest11()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '5', '3', '2' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 2);
            Assert.AreEqual(nh, 1);
        }

        [Test]
        public void JudgmentTest12()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '3', '0', '2' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 1);
            Assert.AreEqual(nh, 2);
        }

        [Test]
        public void JudgmentTest13()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '2', '4', '3' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 2);
            Assert.AreEqual(nh, 2);
        }

        [Test]
        public void JudgmentTest14()
        {
            (int pnh, int nh, bool isCurrent) = _numer0nService.Judgment(new char[] { '1', '4', '2', '3' }, new char[] { '1', '2', '3', '4' });

            Assert.IsFalse(isCurrent);
            Assert.AreEqual(pnh, 1);
            Assert.AreEqual(nh, 3);
        }
    }
}
