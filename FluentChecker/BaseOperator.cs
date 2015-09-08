namespace FluentChecker
{
    #region Usings

    using System;
    using System.Collections.Generic;

    #endregion Usings

    public abstract class BaseOperator
    {
        public abstract bool PerformLogic(bool condition);

        #region Check Methods

        public bool If(bool condition)
        {
            return PerformLogic(Check.If(condition));
        }

        public bool IfAreNotEquals(object valueA, object valueB)
        {
            return PerformLogic(Check.IfAreNotEquals(valueA, valueB));
        }

        public bool IfHasValue<T>(T? nullable) where T : struct
        {
            return PerformLogic(Check.IfHasValue(nullable));
        }

        public bool IfIsEmpty<TSource>(IEnumerable<TSource> collection)
        {
            return PerformLogic(Check.IfIsEmpty(collection));
        }

        public bool IfIsNotNull(object value)
        {
            return PerformLogic(Check.IfIsNotNull(value));
        }

        public bool IfIsNotOfType<TParent>(Type inheritingType)
        {
            return PerformLogic(Check.IfIsNotOfType<TParent>(inheritingType));
        }

        public bool IfIsNotOfType<TInheriting, TParent>() where TInheriting : TParent
        {
            return PerformLogic(Check.IfIsNotOfType<TInheriting, TParent>());
        }

        public bool IfIsNotOfType<TParent>(object value)
        {
            return PerformLogic(Check.IfIsNotOfType<TParent>(value));
        }
         

        public bool IfIsNotOfType(Type inheritingType, Type parentType)
        {
            return PerformLogic(Check.IfIsNotOfType(inheritingType, parentType));
        }

        public bool IfIsNotPositive(double number)
        {
            return PerformLogic(Check.IfIsNotPositive(number));
        }

        public bool IfIsNull(object value)
        {
            return PerformLogic(Check.IfIsNull(value));
        }

        public bool IfIsNullOrWhiteSpace(string value)
        {
            return PerformLogic(Check.IfIsNullOrWhiteSpace(value));
        }

        #endregion Check Methods
    }
}