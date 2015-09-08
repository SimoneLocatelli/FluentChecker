using System;

namespace FluentChecker
{
    using CommonExtensions;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq.Expressions;

    public static class FluentCheckerExtensions
    {
        #region Methods

        public static void Throw<TException>(this bool condition) where TException : Exception, new()
        {
            if (condition) { ExceptionGenerator.Throw<TException>(); }
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "In this case a specific type for the generic Expression would add just useless complexity")]
        public static void Throw<TException>(this bool condition, Expression<Func<object>> message) where TException : Exception, new()
        {
            if (condition)
            {
                ExceptionGenerator.Throw<TException>(message.GetMemberName());
            }
        }

        public static void Throw<TException>(this bool condition, string message) where TException : Exception, new()
        {
            if (condition)
            {
                ExceptionGenerator.Throw<TException>(message);
            }
        }

        #endregion Methods
    }
}