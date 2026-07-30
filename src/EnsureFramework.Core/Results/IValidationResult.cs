namespace EnsureFramework.Results
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// Represents the result of validating a value of type T, including assertion outcomes and error information.
    /// </summary>
    /// <remarks>Use this interface to access the outcome of validation operations, including the validated
    /// value, assertion results, and any associated error messages. The interface provides properties to determine
    /// whether validation succeeded, to enumerate assertion outcomes, and to retrieve error details. The order of
    /// assertion results matches the order in which assertions were evaluated.</remarks>
    /// <typeparam name="T">The type of the value being validated.</typeparam>
    public interface IValidationResult<out T>
    {
        /// <summary>
        /// Gets the current value held by the <see cref="IValidationResult{T}"/>, or null if no value is present.
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Gets the name associated with the <see cref="IValidationResult{T}"/>.
        /// </summary>
        string? Name { get; }

        /// <summary>
        /// Gets the collection of results from executed assertions.
        /// </summary>
        /// <remarks>The collection contains the outcome of each assertion that has been evaluated. The
        /// order of results corresponds to the order in which assertions were executed.</remarks>
        List<IAssertionResult> AssertionResults { get; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="IValidationResult{T}"/> represents an error condition.
        /// </summary>
        bool IsError => this.AssertionResults.Any(v => !v.Success);

        /// <summary>
        /// Gets the collection of error messages associated with the <see cref="IValidationResult{T}"/>.
        /// </summary>
        IEnumerable<string> ErrorMessages => this.AssertionResults.Where(v => !v.Success).Select(v => v.Message!);

        /// <summary>
        /// Gets a value indicating whether the current instance has a non-null value assigned.
        /// </summary>
        /// <remarks>When this property returns <see langword="true"/>, the <see cref="Value"/> property is
        /// guaranteed to be non-null. Use this property to check for the presence of a value before accessing
        /// <see cref="Value"/> to avoid exceptions.</remarks>
        [MemberNotNullWhen(true, nameof(Value))]
        bool HasValue => this.Value is not null;
    }
}
