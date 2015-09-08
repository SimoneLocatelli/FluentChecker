namespace FluentChecker.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class OrOperatorTest
    {
        [TestMethod]
        public void InstanceWithFalseInitialization()
        {
            var orOperator = new OrOperator(false);

            Assert.IsNotNull(orOperator);
            Assert.IsFalse(orOperator.Result);
        }

        [TestMethod]
        public void InstanceWithTrueInitialization()
        {
            var orOperator = new OrOperator(true);

            Assert.IsNotNull(orOperator);
            Assert.IsTrue(orOperator.Result);
        }

        [TestMethod]
        public void PerformLogicWithFalseInitializationAndFalse()
        {
            var orOperator = new OrOperator(false);
            Assert.IsNotNull(orOperator);

            var result = orOperator.PerformLogic(false);

            Assert.IsFalse(orOperator.Result);
            Assert.AreEqual(orOperator.Result, result);
        }

        [TestMethod]
        public void PerformLogicWithFalseInitializationAndTrue()
        {
            var orOperator = new OrOperator(false);
            Assert.IsNotNull(orOperator);

            var result = orOperator.PerformLogic(true);

            Assert.IsTrue(orOperator.Result);
            Assert.AreEqual(orOperator.Result, result);
        }

        [TestMethod]
        public void PerformLogicWithTrueInitializationAndFalse()
        {
            var orOperator = new OrOperator(true);
            Assert.IsNotNull(orOperator);

            var result = orOperator.PerformLogic(false);

            Assert.IsTrue(orOperator.Result);
            Assert.AreEqual(orOperator.Result, result);
        }

        [TestMethod]
        public void PerformLogicWithTrueInitializationAndTrue()
        {
            var orOperator = new OrOperator(true);
            Assert.IsNotNull(orOperator);

            var result = orOperator.PerformLogic(true);

            Assert.IsTrue(orOperator.Result);
            Assert.AreEqual(orOperator.Result, result);
        }
    }
}