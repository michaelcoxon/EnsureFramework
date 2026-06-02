using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

using EnsureFramework.ArgumentAssertionBuilder;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class StringAssertionExtensions
    {
        private readonly static ConcurrentDictionary<(string regex, RegexOptions options), Regex> _regexCache = new();

        /// <summary>
        /// Ensures the <see cref="string" /> argument is not empty.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> IsNotEmpty([NotNull] this IArgumentAssertionBuilder<string> @this)
        {
            if (@this.Argument == string.Empty)
            {
                throw new ArgumentException(Resources.Strings.The_string_is_empty, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }

        /// <summary>
        /// Ensures the <see cref="string" /> argument is not empty or only whitespace.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> IsNotEmptyOrWhiteSpace([NotNull] this IArgumentAssertionBuilder<string> @this)
        {
            if (@this.Argument == string.Empty)
            {
                throw new ArgumentException(Resources.Strings.The_string_is_empty, @this.ArgumentName);
            }

            for (int i = 0; i < @this.Argument.Length; i++)
            {
                if (!char.IsWhiteSpace(@this.Argument[i]))
                {
                    return @this.AssertionPassed();
                }
            }

            throw new ArgumentException(Resources.Strings.The_string_is_whitespace, @this.ArgumentName);
        }

        /// <summary>
        /// Ensures the argument matches the specified regex.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="regex">The regex.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> Matches([NotNull] this IArgumentAssertionBuilder<string> @this, string regex)
        {
            var regexEngine = _regexCache.GetOrAdd((regex, RegexOptions.Compiled), (regexTuple) => new Regex(regexTuple.regex, regexTuple.options));
            var result = regexEngine.IsMatch(@this.Argument);

            if (!result)
            {
                throw new ArgumentException(string.Format(Resources.Strings.The_string_does_not_match_the_regex_Format, regex), @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }

        /// <summary>
        /// Ensures the argument matches the specified regex.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <param name="regex">The regex.</param>
        /// <param name="regexOptions">The regex options.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> Matches([NotNull] this IArgumentAssertionBuilder<string> @this, string regex, RegexOptions regexOptions)
        {
            var regexEngine = _regexCache.GetOrAdd((regex, regexOptions | RegexOptions.Compiled), (regexTuple) => new Regex(regexTuple.regex, regexTuple.options));
            var result = regexEngine.IsMatch(@this.Argument);

            if (!result)
            {
                throw new ArgumentException(string.Format(Resources.Strings.The_string_does_not_match_the_regex_Format, regex), @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }
    }
}
