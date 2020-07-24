using System;
using System.Collections.Generic;
using System.Text;
using Numer0n.Common.Models;
using NUnit.Framework;

namespace Numer0n.Common.Test.Models
{
    class InputNumberHistoryEntityTest
    {
        [Test]
        public void InputNumberHistoryEntityTest01() 
        {
            var entity = new InputNumberHistoryEntity("1234", 1, 2);

            Assert.AreEqual(entity.Count, 1);
            Assert.AreEqual(entity.InputNumber, "1234");
            Assert.AreEqual(entity.PlaceNumberHit, 1);
            Assert.AreEqual(entity.NumberHit, 2);
        }

        [Test]
        public void InputNumberHistoryEntityTest02()
        {
            var entity = new InputNumberHistoryEntity("5678", 3, 0);

            Assert.AreEqual(entity.Count, 2);
            Assert.AreEqual(entity.InputNumber, "5678");
            Assert.AreEqual(entity.PlaceNumberHit, 3);
            Assert.AreEqual(entity.NumberHit, 0);
        }

        [Test]
        public void InputNumberHistoryEntityTest03()
        {
            InputNumberHistoryEntity.ClearCount();
            var entity = new InputNumberHistoryEntity("9012", 0, 0);

            Assert.AreEqual(entity.Count, 1);
            Assert.AreEqual(entity.InputNumber, "9012");
            Assert.AreEqual(entity.PlaceNumberHit, 0);
            Assert.AreEqual(entity.NumberHit, 0);
        }
    }
}
