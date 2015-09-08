using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentChecker
{
    public sealed class AndOperator : BaseOperator
    {
        #region Properties

        public bool Result { get; private set; }

        #endregion Properties

        #region Constructors

        public AndOperator(bool condition)
        {
            Result = condition;
        }

        #endregion Constructors

        #region Methods
         

        public override bool PerformLogic(bool condition)
        {
            return (Result = Result && condition);
        }

        #endregion Methods
    }
}