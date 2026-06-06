namespace EnsureFramework
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using EnsureFramework.Results;

    public static class Validate
    {
        public static IValidationResult<T> That<T>(T? source, [CallerArgumentExpression(nameof(source))] string? sourceName = null)
        {
            return new ValidationResult<T>
            {
                Name = sourceName,
                Value = source
            };
        }
    }

    public interface IValidationResult<T>
    {
        T? Value { get; }
        string? Name { get; }
        List<IAssertionResult> AssertionResults { get; }
        bool IsError { get; }
        IEnumerable<string> ErrorMessages { get; }
    }

    public sealed class ValidationResult<T> : IValidationResult<T>
    {
        public T? Value { get; set; }
        public string? Name { get; set; }

        // TODO: should add the validator that was run to the result
        public List<IAssertionResult> AssertionResults { get; } = [];
        public bool IsError => this.AssertionResults.Any(v => !v.Success);
        public IEnumerable<string> ErrorMessages => this.AssertionResults.Where(v => !v.Success).Select(v => v.Message!);
    }

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
    }
}
