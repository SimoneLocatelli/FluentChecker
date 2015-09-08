using System;

namespace FluentChecker.Tests
{
    using System.Diagnostics.CodeAnalysis;
    using Fakes;
    using Microsoft.QualityTools.Testing.Fakes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FluentCheckerExtensionsTest
    {
        [TestMethod]
        public void ThrowWithFalseCondition()
        {
            false.Throw<Exception>();
        }

        [TestMethod]
        public void ThrowWithFalseConditionAndMessage()
        {
            const string test = "";

            false.Throw<InvalidCastException>(() => test);
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ThrowWithTrueCondition()
        {
            true.Throw<InvalidCastException>();
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "FluentChecker.FluentCheckerExtensions.Throw<System.InvalidCastException>(System.Boolean,System.String)", 
            Justification = "It's just a test"), TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ThrowWithTrueConditionAndWithMessage()
        {
            true.Throw<InvalidCastException>("test");
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ThrowWithTrueConditionAndWithMessageExpression()
        {
            var test = "";

            true.Throw<InvalidCastException>(() => test);
        }

        [TestMethod]
        public void ThrowWitShimExceptionGenerator()
        {
            using (ShimsContext.Create())
            {
                ShimExceptionGenerator.ThrowOf1<InvalidCastException>(() => { });
                true.Throw<InvalidCastException>();
            }
        }



        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "FluentChecker.FluentCheckerExtensions.Throw<System.InvalidCastException>(System.Boolean,System.String)",
            Justification = "It's just a test"), TestMethod]
        public void ThrowWitShimExceptionGeneratorAndWithMessage()
        {
            using (ShimsContext.Create())
            {
                ShimExceptionGenerator.ThrowOf1String<InvalidCastException>(_ => { });
                true.Throw<InvalidCastException>("test");
            }
        }

        [TestMethod]
        public void ThrowWitShimExceptionGeneratorAndWithMessageExpression()
        {
            var test = "";

            using (ShimsContext.Create())
            {
                ShimExceptionGenerator.ThrowOf1String<InvalidCastException>(_ => { });
                true.Throw<InvalidCastException>(() => test);
            }
        }
    }
}