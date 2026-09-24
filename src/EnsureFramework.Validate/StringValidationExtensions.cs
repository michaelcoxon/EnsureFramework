namespace EnsureFramework
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.RegularExpressions;

    using EnsureFramework.Assertions;
    using EnsureFramework.Results;

    /// <summary>
    /// Provides extension methods for IValidationResult{string} to perform common string validations and record
    /// assertion results.
    /// </summary>
    /// <remarks>Each method validates the IValidationResult{string} argument, adds the corresponding
    /// assertion result from StringAssertions to the AssertionResults collection, and returns the same
    /// <see cref=""/> IValidationResult{string} to enable fluent chaining. Methods throw ArgumentNullException when the
    /// IValidationResult argument is null.</remarks>
    public static class StringValidationExtensions
    {
        /// <summary>
        /// Adds an assertion that the validation result's string Value is not empty.
        /// </summary>
        /// <remarks>Throws ArgumentNullException if the validation result is null. Appends the assertion
        /// result produced by StringAssertions.IsNotEmpty for the current Value.</remarks>
        /// <param name="this">The validation result whose Value is asserted to be non-empty.</param>
        /// <returns>The same validation result instance to allow fluent chaining.</returns>
        public static IValidationResult<string> IsNotEmpty([NotNull] this IValidationResult<string> @this)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(StringAssertions.IsNotEmpty(@this.Value));
            return @this;
        }

        /// <summary>
        /// Adds an assertion that the validation result's string Value is not null, empty, or composed only of
        /// white-space characters.
        /// </summary>
        /// <remarks>Throws ArgumentNullException if the validation result is null.</remarks>
        /// <param name="this">The validation result whose Value is validated and to which the assertion is added.</param>
        /// <returns>The same validation result instance to allow fluent chaining.</returns>
        public static IValidationResult<string> IsNotEmptyOrWhiteSpace([NotNull] this IValidationResult<string> @this)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(StringAssertions.IsNotEmptyOrWhiteSpace(@this.Value));
            return @this;
        }

        /// <summary>
        /// Adds a regular-expression assertion for the validation result's string value.
        /// </summary>
        /// <remarks>Throws ArgumentNullException if the validation result is null. The assertion result
        /// produced by StringAssertions.Matches is added to the validation result's AssertionResults collection;
        /// mismatches are recorded rather than thrown.</remarks>
        /// <param name="this">The validation result to which the assertion is appended.</param>
        /// <param name="regex">The regular-expression pattern to match against the validation result's value.</param>
        /// <returns>The original validation result instance for fluent chaining.</returns>
        public static IValidationResult<string> Matches([NotNull] this IValidationResult<string> @this, string regex)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(StringAssertions.Matches(@this.Value, regex));
            return @this;
        }

        /// <summary>
        /// Adds a regular-expression match assertion for the current validation result's value.
        /// </summary>
        /// <remarks>Throws ArgumentNullException if the validation result is null.</remarks>
        /// <param name="this">The validation result whose Value is tested and to which the assertion is added.</param>
        /// <param name="regex">The regular-expression pattern to match against the validation value.</param>
        /// <param name="regexOptions">Options that modify how the regular-expression is interpreted and applied.</param>
        /// <returns>The original validation result instance for fluent chaining.</returns>
        public static IValidationResult<string> Matches([NotNull] this IValidationResult<string> @this, string regex, RegexOptions regexOptions)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(StringAssertions.Matches(@this.Value, regex, regexOptions));
            return @this;
        }
    }
}
