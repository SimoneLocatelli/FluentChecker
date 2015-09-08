#region Usings

using System.Linq;

#endregion Usings

namespace FluentChecker
{
    public sealed class OrOperator : BaseOperator
    {
        #region Properties

        public bool Result { get; private set; }

        #endregion Properties

        #region Constructors

        public OrOperator(bool condition)
        {
            Result = condition;
        }

        #endregion Constructors

        #region Methods
         
        public override bool PerformLogic(bool condition)
        {
            return ( Result = Result || condition);
        }

        #endregion Methods
    }
}