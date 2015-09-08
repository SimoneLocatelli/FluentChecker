using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestInjector;

namespace FluentChecker.Tests
{

    [TestClass]
    public class CheckTest : BaseTestClass
    {
        private enum FunkyEnum
        {
            Foo = 0,
            Bar
        }

        #region If

        [TestMethod]
        public void IfWithFalse()
        {
            var result = Check.If(false);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfWithTrue()
        {
            var result = Check.If(true);

            Assert.IsTrue(result);
        }

        #endregion If

        #region IfAreNotEquals

        [TestMethod]
        public void IfAreNotEquals()
        {
            var obj = new object();

            var result = Check.IfAreNotEquals(obj, obj);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfAreNotEqualsWithBothNull()
        {
            var result = Check.IfAreNotEquals(null, null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfAreNotEqualsWithFirstObjectNull()
        {
            var result = Check.IfAreNotEquals(null, new object());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfAreNotEqualsWithSecondObjectNull()
        {
            var result = Check.IfAreNotEquals(new object(), null);

            Assert.IsTrue(result);
        }

        #endregion IfAreNotEquals

        #region IfHasValue

        [TestMethod]
        public void IfHasValue()
        {
            var result = Check.IfHasValue((int?)1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfHasValueWithDefaultValue()
        {
            var result = Check.IfHasValue(default(int?));

            Assert.IsFalse(result);
        }

        #endregion IfHasValue

        #region IfIsEmpty

        [TestMethod]
        public void IfIsEmptyWithCollectionEmpty()
        {
            var result = Check.IfIsEmpty(new List<object>());

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsEmptyWithCollectionFilled()
        {
            var result = Check.IfIsEmpty(new List<object> { new object() });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsEmptyWithCollectionNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Check.IfIsEmpty(default(List<object>)), "collection");
        }

        #endregion IfIsEmpty

        #region IfIsNull

        [TestMethod]
        public void IfIsNullWithNullObject()
        {
            var result = Check.IfIsNull(null);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNullWithObjectInstance()
        {
            var result = Check.IfIsNull(new object());
            Assert.IsFalse(result);
        }

        #endregion IfIsNull

        #region IfEnumIsNotDefined

        [TestMethod]
        public void IfEnumIsNotDefinedWithInvalidEnum()
        {
            var result = Check.IfEnumIsNotDefined<FunkyEnum>(10);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfEnumIsNotDefinedWithValidEnum()
        {
            var result = Check.IfEnumIsNotDefined<FunkyEnum>(0);

            Assert.IsFalse(result);
        }

        #endregion IfEnumIsNotDefined

        #region IfIsNullOrWhiteSpace

        [TestMethod]
        public void IfIsNullOrWhiteSpace()
        {
            var result = Check.IfIsNullOrWhiteSpace("Test");
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNullOrWhiteSpaceWithEmptyString()
        {
            var result = Check.IfIsNullOrWhiteSpace("");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNullOrWhiteSpaceWithNullString()
        {
            var result = Check.IfIsNullOrWhiteSpace(null);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNullOrWhiteSpaceWithWhiteSpaceString()
        {
            var result = Check.IfIsNullOrWhiteSpace("  ");
            Assert.IsTrue(result);
        }

        #endregion IfIsNullOrWhiteSpace

        #region IfIsNotNull

        [TestMethod]
        public void IfIsNotNullWithNullObject()
        {
            var result = Check.IfIsNotNull(null);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotNullWithObjectInstance()
        {
            var result = Check.IfIsNotNull(new object());
            Assert.IsTrue(result);
        }

        #endregion IfIsNotNull

        #region IfIsNotOfType

        [TestMethod]
        public void IfIsNotOfTypeWithDifferentTypes()
        {
            var result = Check.IfIsNotOfType<string>(typeof(int));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithDifferentTypesAndInstance()
        {
            var result = Check.IfIsNotOfType<string>(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithGenericsTypes()
        {
            Assert.IsTrue(Check.IfIsNotOfType<string, object>());
        }

        [TestMethod]
        public void IfIsNotOfTypeWithSameTypes()
        {
            var result = Check.IfIsNotOfType<string>(typeof(string));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithSameTypesWithInstance()
        {
            var result = Check.IfIsNotOfType<string>("");

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndDifferentTypes()
        {
            var result = Check.IfIsNotOfType(typeof(string), typeof(int));

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndFirstIsNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Check.IfIsNotOfType(null, typeof(string)), "inheritingType");
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndSameTypes()
        {
            var result = Check.IfIsNotOfType(typeof(string), typeof(string));

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTwoTypesAndSecondIsNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Check.IfIsNotOfType(typeof(string), null), "parentType");
        }

        [TestMethod]
        public void IfIsNotOfTypeWithTypeNull()
        {
            TestExpectedArgumentException<ArgumentNullException>(() => Check.IfIsNotOfType<object>(default(Type)), "inheritingType");
        }

        #endregion IfIsNotOfType

        #region IfIsNotPositive

        [TestMethod]
        public void IfIsNotPositiveWithNegativeNumber()
        {
            var result = Check.IfIsNotPositive(-1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IfIsNotPositiveWithPositiveNumber()
        {
            var result = Check.IfIsNotPositive(1);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IfIsNotPositiveWithZero()
        {
            var result = Check.IfIsNotPositive(0);

            Assert.IsTrue(result);
        }

        #endregion IfIsNotPositive
    }
}