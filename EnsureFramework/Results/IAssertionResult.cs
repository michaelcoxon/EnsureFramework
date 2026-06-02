namespace EnsureFramework.Results
{
    public interface IAssertionResult
    {
        string? Message { get; init; }
        bool Success { get; init; }

        string ToString();
    }
}