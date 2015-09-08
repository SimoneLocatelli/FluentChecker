namespace FluentChecker
{
    /// <summary>
    /// Extensions for the Operators
    /// </summary>
    public static class OperatorExtensions
    {
        #region Methods

        /// <summary>
        /// Concatenates an And operator to the Check chain.
        /// </summary>
        /// <param name="condition">The current value of the Check chain</param>
        /// <returns></returns>
        public static AndOperator And(this bool condition)
        {
            return new AndOperator(condition);
        }

        /// <summary>
        /// Concatenates an Or operator to the Check chain.
        /// </summary>
        /// <param name="condition">The current value of the Check chain</param>
        /// <returns></returns>
        public static OrOperator Or(this bool condition)
        {
            return new OrOperator(condition);
        }

        #endregion Methods
    }
}