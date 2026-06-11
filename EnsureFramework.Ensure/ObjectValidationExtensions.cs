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
            if (@this.Value is null)
            {
                @this.AssertionResults.Add(AssertionResult.Fail("Value should not be null."));
            }
            else
            {
                @this.AssertionResults.Add(AssertionResult.Ok);
            }
            return @this;
        }

        public static IValidationResult<T> IsNull<T>([NotNull] this IValidationResult<T> @this)
        {
            if (@this.Value is not null)
            {
                @this.AssertionResults.Add(AssertionResult.Fail("Value should be null."));
            }
            else
            {
                @this.AssertionResults.Add(AssertionResult.Ok);
            }
            return @this;
        }

        public static IValidationResult<T> IsExactTypeOf<T>([NotNull] this IValidationResult<T> @this, Type type)
        {
            @this.AssertionResults.Add(ObjectAssertions.IsExactTypeOf(typeof(T), type));
            return @this;
        }
    }
}
