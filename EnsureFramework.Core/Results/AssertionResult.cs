namespace EnsureFramework.Results
{
    /// <summary>
    /// Represents the result of an assertion, indicating whether the assertion succeeded and providing an optional
    /// message describing the outcome.
    /// </summary>
    /// <param name="Success">A value indicating whether the assertion was successful. Set to <see langword="true"/> if the assertion passed;
    /// otherwise, <see langword="false"/>.</param>
    /// <param name="Message">An optional message that describes the result of the assertion. May be <see langword="null"/> if no message is
    /// provided.</param>
    public record AssertionResult(bool Success, string? Message = null) : IAssertionResult
    {
        /// <summary>
        /// Creates an assertion result that indicates a successful outcome.
        /// </summary>
        /// <returns>An <see cref="IAssertionResult"/> representing a successful assertion.</returns>
        public static IAssertionResult Ok = new AssertionResult(true);

        /// <summary>
        /// Creates a failed assertion result with the specified failure message.
        /// </summary>
        /// <param name="message">The message that describes the reason for the assertion failure. Cannot be null.</param>
        /// <returns>An <see cref="IAssertionResult"/> representing a failed assertion with the provided message.</returns>
        public static IAssertionResult Fail(string message)
        {
            return new AssertionResult(false, message);
        }
    }
}
