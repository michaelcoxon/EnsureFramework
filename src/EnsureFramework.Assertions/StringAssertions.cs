using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;

using EnsureFramework.Results;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Provides assertion methods for validating string values, including checks for emptiness, whitespace, and regular
    /// expression matching.
    /// </summary>
    /// <remarks>This static class offers a set of common string assertions that return assertion results
    /// rather than throwing exceptions. These methods are intended for use in validation scenarios where fluent or
    /// composable assertion logic is required. All methods are thread-safe and optimized for repeated use, including
    /// internal caching of regular expressions for performance.</remarks>
    public static class StringAssertions
    {
        private readonly static ConcurrentDictionary<(string regex, RegexOptions options), Regex> _regexCache = new();

        /// <summary>
        /// Determines whether the specified string is not empty.
        /// </summary>
        /// <remarks>This method does not check for null values. To ensure the string is not null or
        /// empty, use an appropriate null check before calling this method.</remarks>
        /// <param name="source">The string to validate. Cannot be null.</param>
        /// <returns>An assertion result indicating success if the string is not empty; otherwise, a failure result.</returns>
        public static IAssertionResult IsNotEmpty(string source)
        {
            if (source == string.Empty)
            {
                return AssertionResult.Fail(Resources.Strings.The_string_is_empty);
            }
            return AssertionResult.Ok;
        }

        /// <summary>
        /// Determines whether the specified string is not empty and is not whitespace
        /// </summary>
        /// <remarks>A string consisting solely of white-space characters is considered invalid. If the
        /// input is an empty string, the result indicates failure due to emptiness. If the input contains only
        /// white-space, the result indicates failure due to white-space content.</remarks>
        /// <param name="source">The string to validate. Can be null, empty, or contain white-space characters.</param>
        /// <returns>An assertion result indicating success if the string is not empty and contains at least one non-white-space
        /// character; otherwise, a failure result.</returns>
        public static IAssertionResult IsNotEmptyOrWhiteSpace(string source)
        {
            ArgumentNullException.ThrowIfNull(source);

            if (source == string.Empty)
            {
                return AssertionResult.Fail(Resources.Strings.The_string_is_empty);
            }

            for (int i = 0; i < source.Length; i++)
            {
                if (!char.IsWhiteSpace(source[i]))
                {
                    return AssertionResult.Ok;
                }
            }

            return AssertionResult.Fail(Resources.Strings.The_string_is_whitespace);
        }

        /// <summary>
        /// Determines whether the specified source string matches the given regular expression pattern.
        /// </summary>
        /// <remarks>The regular expression is compiled and may be cached for improved performance on
        /// repeated calls with the same pattern.</remarks>
        /// <param name="source">The string to test against the regular expression pattern.</param>
        /// <param name="regex">The regular expression pattern to match. Must be a valid .NET regular expression.</param>
        /// <returns>An <see cref="IAssertionResult"/> indicating whether the source string matches the regular expression
        /// pattern. Returns a failure result if the string does not match; otherwise, returns a success result.</returns>
        public static IAssertionResult Matches(string source, string regex)
        {
            var regexEngine = _regexCache.GetOrAdd((regex, RegexOptions.Compiled), (regexTuple) => new Regex(regexTuple.regex, regexTuple.options));
            return Matches(source, regexEngine);
        }

        /// <summary>
        /// Determines whether the specified source string matches the given regular expression pattern using the
        /// provided options.
        /// </summary>
        /// <remarks>The regular expression engine is cached for performance. The method uses compiled
        /// regular expressions to improve matching speed for repeated patterns.</remarks>
        /// <param name="source">The input string to test against the regular expression pattern.</param>
        /// <param name="regex">The regular expression pattern to match against the source string.</param>
        /// <param name="regexOptions">A bitwise combination of enumeration values that specify options for the regular expression.</param>
        /// <returns>An object that indicates whether the source string matches the regular expression pattern. Returns a
        /// successful result if the match is found; otherwise, a failure result with an appropriate message.</returns>
        public static IAssertionResult Matches(string source, string regex, RegexOptions regexOptions)
        {
            var regexEngine = _regexCache.GetOrAdd((regex, regexOptions | RegexOptions.Compiled), (regexTuple) => new Regex(regexTuple.regex, regexTuple.options));
            return Matches(source, regexEngine);
        }

        /// <summary>
        /// Determines whether the specified string matches the given regular expression pattern.
        /// </summary>
        /// <param name="source">The string to test against the regular expression.</param>
        /// <param name="regex">The regular expression to match against the source string. Cannot be null.</param>
        /// <returns>An <see cref="IAssertionResult"/> indicating whether the source string matches the regular expression.
        /// Returns a failure result if the string does not match.</returns>
        public static IAssertionResult Matches(string source, Regex regex)
        {
            ArgumentNullException.ThrowIfNull(regex);

            var result = regex.IsMatch(source);

            if (!result)
            {
                return AssertionResult.Fail(string.Format(Resources.Strings.The_string_does_not_match_the_regex_Format, regex));
            }
            return AssertionResult.Ok;
        }
    }
}
