using System;
using System.Collections.Generic;
using FluentChecker.Fakes;
using UnitTestInjector;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace FluentChecker.Tests
{

    [TestClass]
    public class BaseOperatorTest : BaseTestClass
    {
        #region Properties

        private readonly BaseOperator baseOperator = new StubBaseOperator()
        {
            PerformLogicBoolean = condition => condition
        };

        #endregion Properties

        #region If

        [TestMethod]
        public void IfWithFalse()
        {
            var result = baseOperator.If(false);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfWithTrue()
        {
            var result = baseOperator.If(true);

            Assert.IsTrue(result);
        }

        #endregion If

        #region IfAreNotEquals

        [TestMethod]
        public void IfAreNotEquals()
        {
            var obj = new object();

            var result = baseOperator.IfAreNotEquals(obj, obj);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfAreNotEqualsWithBothNull()
        {
            var result = baseOperator.IfAreNotEquals(null, null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfAreNotEqualsWithFirstObjectNull()
        {
            var result = baseOperator.IfAreNotEquals(null, new object());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfAreNotEqualsWithSecondObjectNull()
        {
            var result = baseOperator.IfAreNotEquals(new object(), null);

            Assert.IsTrue(result);
        }

        #endregion IfAreNotEquals

        #region IfHasValue

        [TestMethod]
        public void IfHasValue()
        {
            var result = baseOperator.IfHasValue((int?)1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfHasValueWithDefaultValue()
        {
            var result = baseOperator.IfHasValue(default(int?));

            Assert.IsFalse(result);
        }

        #endregion IfHasValue

        #region IfIsEmpty

        [TestMethod]
        public void IfIsEmptyWithCollectionEmpty()
        {
            var result = baseOperator.IfIsEmpty(new List<object>());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsEmptyWithCollectionFilled()
        {
            var result = baseOperator.IfIsEmpty(new List<object> { new object() });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsEmptyWithCollectionNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => baseOperator.IfIsEmpty(default(List<object>)), "collection");
        }

        #endregion IfIsEmpty

        #region IfIsNull

        [TestMethod]
        public void IfIsNullWithNullObject()
        {
            var result = baseOperator.IfIsNull(null);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNullWithObjectInstance()
        {
            var result = baseOperator.IfIsNull(new object());
            Assert.IsFalse(result);
        }

        #endregion IfIsNull

        #region IfIsNullOrWhiteSpace

        [TestMethod]
        public void IfIsNullOrWhiteSpace()
        {
            var result = baseOperator.IfIsNullOrWhiteSpace("Test");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNullOrWhiteSpaceWithEmptyString()
        {
            var result = baseOperator.IfIsNullOrWhiteSpace("");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNullOrWhiteSpaceWithNullString()
        {
            var result = baseOperator.IfIsNullOrWhiteSpace(null);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNullOrWhiteSpaceWithWhiteSpaceString()
        {
            var result = baseOperator.IfIsNullOrWhiteSpace("  ");
            Assert.IsTrue(result);
        }

        #endregion IfIsNullOrWhiteSpace

        #region IfIsNotNull

        [TestMethod]
        public void IfIsNotNullWithNullObject()
        {
            var result = baseOperator.IfIsNotNull(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotNullWithObjectInstance()
        {
            var result = baseOperator.IfIsNotNull(new object());
            Assert.IsTrue(result);
        }

        #endregion IfIsNotNull

        #region IfIsNotOfType

        [TestMethod]
        public void IfIsNotOfTypeWithDifferentTypes()
        {
            var result = baseOperator.IfIsNotOfType<string>(typeof(int));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithDifferentTypesWithInstance()
        {
            var result = baseOperator.IfIsNotOfType<string>(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithGenericsTypes()
        {
            Assert.IsTrue(baseOperator.IfIsNotOfType<string, object>());
        }
        [TestMethod]
        public void IfIsNotOfTypeWithSameTypes()
        {
            var result = baseOperator.IfIsNotOfType<string>(typeof(string));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithSameTypesAndInstance()
        {
            var result = baseOperator.IfIsNotOfType<string>("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndDifferentTypes()
        {
            var result = baseOperator.IfIsNotOfType(typeof(string), typeof(int));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndFirstIsNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => baseOperator.IfIsNotOfType(null, typeof(string)), "inheritingType");
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndSameTypes()
        {
            var result = baseOperator.IfIsNotOfType(typeof(string), typeof(string));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndSecondIsNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => baseOperator.IfIsNotOfType(typeof(string), null), "parentType");
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTypeNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => baseOperator.IfIsNotOfType<object>(default(Type)), "inheritingType");
        }

        #endregion IfIsNotOfType

        #region IfIsNotPositive

        [TestMethod]
        public void IfIsNotPositiveWithNegativeNumber()
        {
            var result = baseOperator.IfIsNotPositive(-1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotPositiveWithPositiveNumber()
        {
            var result = baseOperator.IfIsNotPositive(1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotPositiveWithZero()
        {
            var result = baseOperator.IfIsNotPositive(0);

            Assert.IsTrue(result);
        }

        #endregion IfIsNotPositive
    }
}