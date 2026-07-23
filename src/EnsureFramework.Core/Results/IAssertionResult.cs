namespace EnsureFramework.Results
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Represents the result of an assertion, including its success status and an optional message describing the
    /// outcome if not successful.
    /// </summary>
    /// <remarks>Use this interface to inspect the outcome of an assertion operation. The <see
    /// cref="Success"/> property indicates whether the assertion passed, and the <see cref="Message"/> property
    /// provides error information when the assertion fails.</remarks>
    public interface IAssertionResult
    {
        /// <summary>
        /// Gets the message associated with this instance when it is unsuccessful.
        /// </summary>
        string? Message { get; init; }

        /// <summary>
        /// Gets a value indicating whether the operation completed successfully.
        /// </summary>
        /// <remarks>If the value is <see langword="false"/>, additional information about the failure may
        /// be available in the <c>Message</c> property.</remarks>
        [MemberNotNullWhen(false, nameof(Message))]
        bool Success { get; init; }
    }
}