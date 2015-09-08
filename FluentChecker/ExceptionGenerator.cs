using System;

namespace FluentChecker
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Generate and initialize the exception requested.
    /// </summary>
    public static class ExceptionGenerator
    {
        #region Methods

        /// <summary>
        /// Throws the specified exception.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        public static void Throw<TException>() where TException : Exception, new()
        {
            throw new TException();
        }

        /// <summary>
        /// Throws the specified exception.
        /// </summary>
        /// <typeparam name="TException">The type of the exception to throw.</typeparam>
        /// <param name="message">The message used to initialize the exception.</param>
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static void Throw<TException>(string message) where TException : Exception
        {
            throw (TException)Activator.CreateInstance(typeof(TException), message);
        }

        #endregion Methods
    }
}