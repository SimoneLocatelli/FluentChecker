using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentChecker.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OperatorExtensionsTest
    {
        [TestMethod]
        public void AndOperatorWithTrueInitialization()
        {
            var result = true.And();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result);
        }
        [TestMethod]
        public void AndOperatorWithFalseInitialization()
        {
            var result = false.And();

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Result);
        }
        [TestMethod]
        public void OrOperatorWithTrueInitialization()
        {
            var result = true.Or();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result);
        }
        [TestMethod]
        public void OrOperatorWithFalseInitialization()
        {
            var result = false.Or();

            Assert.IsNotNull(result);
            Assert.IsFalse(result.Result);
        }

    }
}
