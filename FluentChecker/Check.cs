namespace FluentChecker
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion Usings

    /// <summary>
    /// Container for basic validation methods.
    /// The purpose of this class is to be used with the
    /// <see cref="FluentCheckerExtensions"/> class, to provide
    /// a Fluent syntax for the validation.
    /// <example>
    /// Check.IfIsNull(obj).Throw{NullArgumentException}();
    /// </example>
    /// </summary>
    public static class Check
    {
        #region Methods

        public static bool If(bool condition)
        {
            return condition;
        }

        public static bool IfAreNotEquals(object valueA, object valueB)
        {
            return !Equals(valueA, valueB);
        }

        public static bool IfEnumIsNotDefined<TEnum>(object value)
        {
            return !Enum.IsDefined(typeof(TEnum), value);
        }

        public static bool IfHasValue<T>(T? nullable) where T : struct
        {
            return nullable.HasValue;
        }

        public static bool IfIsEmpty<TSource>(IEnumerable<TSource> collection)
        {
            IfIsNull(collection).Throw<ArgumentNullException>(() => collection);

            return !collection.Any();
        }

        public static bool IfIsNotNull(object value)
        {
            return value != null;
        }

        public static bool IfIsNotOfType<TParent>(Type inheritingType)
        {
            IfIsNull(inheritingType).Throw<ArgumentNullException>(() => inheritingType);

            return IfIsNotOfType(inheritingType, typeof(TParent));
        }

        public static bool IfIsNotOfType<TInheriting, TParent>() where TInheriting : TParent
        {
            // This method will always return true because
            // the check is made during compile time

            return true;
        }

        public static bool IfIsNotOfType<TParent>(object value)
        {
            IfIsNull(value).Throw<ArgumentNullException>(() => value);

            return IfIsNotOfType<TParent>(value.GetType());
        }
 
        public static bool IfIsNotOfType(Type inheritingType, Type parentType)
        {
            IfIsNull(inheritingType).Throw<ArgumentNullException>((() => inheritingType));
            IfIsNull(parentType).Throw<ArgumentNullException>(() => parentType);

            return inheritingType != parentType && !(inheritingType.IsSubclassOf(parentType) || parentType.IsAssignableFrom(inheritingType));
        }

        public static bool IfIsNotPositive(double number)
        {
            return number < 1;
        }

        public static bool IfIsNull(object value)
        {
            return value == null;
        }

        public static bool IfIsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        #endregion Methods
    }
}