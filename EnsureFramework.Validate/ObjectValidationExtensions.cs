namespace EnsureFramework
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using EnsureFramework.Assertions;
    using EnsureFramework.Results;

    public static class ObjectValidationExtensions
    {
        public static IValidationResult<T> IsNotNull<T>([NotNull] this IValidationResult<T> @this)
        {
            @this.AssertionResults.Add(ObjectAssertions.IsNotNull(@this.Value));
            return @this;

        }

        public static IValidationResult<T> IsNull<T>([NotNull] this IValidationResult<T> @this)
        {
            @this.AssertionResults.Add(ObjectAssertions.IsNull(@this.Value));
            return @this;

        }

        public static IValidationResult<T> IsExactTypeOf<T>([NotNull] this IValidationResult<T> @this, Type type)
        {
            @this.AssertionResults.Add(ObjectAssertions.IsExactTypeOf(typeof(T), type));
            return @this;
        }
    }
}
