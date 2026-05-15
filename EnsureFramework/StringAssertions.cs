using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class StringAssertions
    {
        private readonly static ConcurrentDictionary<(string, RegexOptions?), Regex> _regexCache = new();

        /// <summary>
        /// Ensures the <see cref="string" /> argument is not <c>null</c> or empty.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> IsNotEmpty([NotNull] this IArgumentAssertionBuilder<string> @this)
        {
            if (@this.Argument == string.Empty)
            {
                throw new ArgumentException("IsEmpty", @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the <see cref="string" /> argument is not <c>null</c> or empty.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> IsNotEmptyOrWhiteSpace([NotNull] this IArgumentAssertionBuilder<string> @this)
        {
            @this.IsNotEmpty();

            if (char.IsWhiteSpace(@this.Argument[0]))
            {
                throw new ArgumentException("IsWhiteSpace", @this.ArgumentName);
            }
            return @this;
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
            var regexEngine = _regexCache.GetOrAdd((regex, null), (regexTuple) => new Regex(regexTuple.Item1, RegexOptions.Compiled));
            var result = regexEngine.IsMatch(@this.Argument);

            if (!result)
            {
                throw new ArgumentException($"The string '{@this.Argument}' does not match the regular expression '{regex}'", @this.ArgumentName);
            }
            return @this;
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
            var regexEngine = _regexCache.GetOrAdd((regex, regexOptions), (regexTuple) => new Regex(regexTuple.Item1, regexTuple.Item2!.Value | RegexOptions.Compiled));
            var result = regexEngine.IsMatch(@this.Argument);

            if (!result)
            {
                throw new ArgumentException($"The string '{@this.Argument}' does not match the regular expression '{regex}'", @this.ArgumentName);
            }
            return @this;
        }
    }
}
