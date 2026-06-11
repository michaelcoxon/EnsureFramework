namespace EnsureFramework.Results
{
    using System.Collections.Generic;
    using System.Linq;

    public sealed class ValidationResult<T> : IValidationResult<T>
    {
        /// <inheritdoc/>
        public T? Value { get; set; }
        /// <inheritdoc/>
        public string? Name { get; set; }

        // TODO: should add the validator that was run to the result
        /// <inheritdoc/>
        public List<IAssertionResult> AssertionResults { get; } = [];
        /// <inheritdoc/>
        public bool IsError => this.AssertionResults.Any(v => !v.Success);
        /// <inheritdoc/>
        public IEnumerable<string> ErrorMessages => this.AssertionResults.Where(v => !v.Success).Select(v => v.Message!);
    }
}
