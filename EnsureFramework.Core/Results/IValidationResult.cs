namespace EnsureFramework.Results
{
    using System.Collections.Generic;

    public interface IValidationResult<T>
    {
        T? Value { get; }
        string? Name { get; }
        List<IAssertionResult> AssertionResults { get; }
        bool IsError { get; }
        IEnumerable<string> ErrorMessages { get; }
    }
}
