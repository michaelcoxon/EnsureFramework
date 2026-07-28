namespace EnsureFramework
{
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;

    using EnsureFramework.Assertions;
    using EnsureFramework.Results;

    /// <summary>
    /// Provides extension methods for performing common object validation assertions on instances of
    /// <see cref="IValidationResult{T}"/>. These methods enable fluent validation of object state within validation workflows.
    /// </summary>
    /// <remarks>These extension methods are intended to be used as part of a fluent validation chain. Each
    /// method adds an assertion result to the underlying validation result, allowing multiple validations to be
    /// composed in a readable manner. The methods do not throw exceptions for validation failures; instead, they record
    /// assertion results for later inspection.</remarks>
    public static class ObjectValidationExtensions
    {
        /// <summary>
        /// Adds a not-null assertion to the validation result for the current value.
        /// </summary>
        /// <remarks>This method is intended to be used as part of a fluent validation chain. The
        /// assertion checks whether the value contained in the validation result is not null and records the result of
        /// this check.</remarks>
        /// <typeparam name="T">The type of the value being validated.</typeparam>
        /// <param name="this">The validation result to which the not-null assertion will be added. Cannot be null.</param>
        /// <returns>The same validation result instance with the not-null assertion appended.</returns>
        public static IValidationResult<T> IsNotNull<T>(this IValidationResult<T> @this)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(ObjectAssertions.IsNotNull(@this.Value));
            return @this;
        }

        /// <summary>
        /// Adds a null-check assertion to the validation result for the specified value.
        /// </summary>
        /// <remarks>This method enables fluent chaining of validation assertions. The null-check
        /// assertion verifies that the value being validated is null.</remarks>
        /// <typeparam name="T">The type of the value being validated.</typeparam>
        /// <param name="this">The validation result to which the null-check assertion is added. Cannot be null.</param>
        /// <returns>The same validation result instance with the null-check assertion appended.</returns>
        public static IValidationResult<T> IsNull<T>(this IValidationResult<T> @this)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(ObjectAssertions.IsNull(@this.Value));
            return @this;
        }

        /// <summary>
        /// Adds a validation assertion that checks whether the value matches the specified predicate.
        /// </summary>
        /// <remarks>This method enables fluent validation by allowing additional assertions to be
        /// chained. If the predicate returns <see langword="false"/>, the assertion is considered failed and the
        /// provided message is used.</remarks>
        /// <typeparam name="T">The type of the value being validated.</typeparam>
        /// <param name="this">The validation result to which the assertion is added.</param>
        /// <param name="predicate">A function that defines the condition the value must satisfy. The predicate should return <see
        /// langword="true"/> if the value is valid; otherwise, <see langword="false"/>.</param>
        /// <param name="message">An optional message to associate with the assertion if the predicate fails. If null, a default message is
        /// used.</param>
        /// <returns>The same validation result instance, allowing for method chaining.</returns>
        public static IValidationResult<T> Matches<T>(this IValidationResult<T> @this, Func<T?, bool> predicate, string? message = null)
        {
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(@this.Value);
            // currently eating the exception here but its message will be captured by the assertion
            // TODO: consider exceptions
            @this.AssertionResults.Add(ObjectAssertions.Matches(@this.Value, predicate, message, out _));
            return @this;
        }

        /// <summary>
        /// Adds a validation assertion that the value is equal to one of the specified options.
        /// </summary>
        /// <remarks>This method is typically used in fluent validation chains to ensure that a value
        /// matches one of a predefined set of valid options. The assertion is appended to the existing validation
        /// results.</remarks>
        /// <typeparam name="T">The type of the value being validated.</typeparam>
        /// <param name="this">The validation result to which the assertion is added.</param>
        /// <param name="options">An array of valid options. The value must match one of these options to pass the assertion.</param>
        /// <returns>The original validation result with the new assertion added.</returns>
        public static IValidationResult<T> IsOneOf<T>(this IValidationResult<T> @this, params T[] options)
        {
            ArgumentNullException.ThrowIfNull(@this);
            ArgumentNullException.ThrowIfNull(@this.Value);

            @this.AssertionResults.Add(ObjectAssertions.IsOneOf(@this.Value, options));
            return @this;
        }
    }
}
