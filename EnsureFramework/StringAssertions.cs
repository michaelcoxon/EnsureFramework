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
    public static partial class StringAssertions
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
                throw new ArgumentException($"The string is empty.", @this.ArgumentName);
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
                throw new ArgumentException($"The string is empty.", @this.ArgumentName);
            }

            for (int i = 0; i < @this.Argument.Length; i++)
            {
                if (!char.IsWhiteSpace(@this.Argument[i]))
                {
                    return @this.AssertionPassed();
                }
            }

            throw new ArgumentException($"The string '{@this.Argument}' is whitespace", @this.ArgumentName);
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
                throw new ArgumentException($"The string '{@this.Argument}' does not match the regular expression '{regex}'", @this.ArgumentName);
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
                throw new ArgumentException($"The string '{@this.Argument}' does not match the regular expression '{regex}'", @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }
    }
}
