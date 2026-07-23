namespace EnsureFramework.Results
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the result of validating a value, including the value itself, its name, and the results of all
    /// validation assertions.
    /// </summary>
    /// <remarks>A <see cref="ValidationResult{T}"/> contains the outcome of running one or more validation assertions
    /// against a value. It provides access to the original value, its associated name, the results of each assertion,
    /// and a summary of error messages if any assertions failed. This type is typically used to communicate validation
    /// outcomes in a structured and extensible way.</remarks>
    /// <typeparam name="T">The type of the value being validated.</typeparam>
    public sealed record ValidationResult<T> : IValidationResult<T>
    {
        /// <inheritdoc/>
        public required T? Value { get; init; }

        /// <inheritdoc/>
        public required string? Name { get; init; }

        // TODO: should add the name of validator that was run to the result
        /// <inheritdoc/>
        public List<IAssertionResult> AssertionResults { get; } = [];
    }
}
