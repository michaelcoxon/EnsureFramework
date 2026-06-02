using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

using EnsureFramework.ArgumentAssertionBuilder;
using EnsureFramework.Assertions;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class StringAssertionExtensions
    {
        /// <summary>
        /// Ensures the <see cref="string" /> argument is not empty.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> IsNotEmpty([NotNull] this IArgumentAssertionBuilder<string> @this)
        {
            var result = StringAssertions.IsNotEmpty(@this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
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
            var result = StringAssertions.IsNotEmptyOrWhiteSpace(@this.Argument);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
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
            var result = StringAssertions.Matches(@this.Argument, regex);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
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
            var result = StringAssertions.Matches(@this.Argument, regex, regexOptions);
            if (!result.Success)
            {
                throw new ArgumentException(result.Message, @this.ArgumentName);
            }
            return @this.AssertionPassed();
        }
    }
}
