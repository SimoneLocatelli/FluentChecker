using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using UnitTestInjector;

namespace FluentChecker.Tests
{
    [TestClass]
    public class ExceptionGeneratorTest : BaseTestClass
    {
        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void Throw()
        {
            ExceptionGenerator.Throw<InvalidCastException>();
        }

        [SuppressMessage("Microsoft.Globalization",
            "CA1303:Do not pass literals as localized parameters",
            MessageId = "FluentChecker.ExceptionGenerator.Throw<System.InvalidCastException>(System.String)"),
        TestMethod]
        public void ThrowWithMessage()
        {
            TestExpectedException<InvalidCastException>(() => ExceptionGenerator.Throw<InvalidCastException>("Test"), "Test");
        }
    }
}