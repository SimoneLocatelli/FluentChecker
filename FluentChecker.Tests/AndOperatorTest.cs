namespace FluentChecker.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AndOperatorTest
    {
        [TestMethod]
        public void InstanceWithFalseInitialization()
        {
            var andOperator = new AndOperator(false);

            Assert.IsNotNull(andOperator);
            Assert.IsFalse(andOperator.Result);
        }

        [TestMethod]
        public void InstanceWithTrueInitialization()
        {
            var andOperator = new AndOperator(true);

            Assert.IsNotNull(andOperator);
            Assert.IsTrue(andOperator.Result);
        }

        [TestMethod]
        public void PerformLogicWithFalseInitializationAndFalse()
        {
            var andOperator = new AndOperator(false);
            Assert.IsNotNull(andOperator);

            var result = andOperator.PerformLogic(false);

            Assert.IsFalse(andOperator.Result);
            Assert.AreEqual(andOperator.Result, result);
        }

        [TestMethod]
        public void PerformLogicWithFalseInitializationAndTrue()
        {
            var andOperator = new AndOperator(false);
            Assert.IsNotNull(andOperator);

            var result = andOperator.PerformLogic(true);

            Assert.IsFalse(andOperator.Result);
            Assert.AreEqual(andOperator.Result, result);
        }

        [TestMethod]
        public void PerformLogicWithTrueInitializationAndFalse()
        {
            var andOperator = new AndOperator(true);
            Assert.IsNotNull(andOperator);

            var result = andOperator.PerformLogic(false);

            Assert.IsFalse(andOperator.Result);
            Assert.AreEqual(andOperator.Result, result);
        }

        [TestMethod]
        public void PerformLogicWithTrueInitializationAndTrue()
        {
            var andOperator = new AndOperator(true);
            Assert.IsNotNull(andOperator);

            var result = andOperator.PerformLogic(true);

            Assert.IsTrue(andOperator.Result);
            Assert.AreEqual(andOperator.Result, result);
        }
    }
}