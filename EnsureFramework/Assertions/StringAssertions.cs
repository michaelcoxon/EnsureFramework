using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace EnsureFramework.Assertions
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static partial class StringAssertions
    {
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
                throw new ArgumentException(null, @this.ArgumentName);
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
            bool result;
            Exception? innerException = null;
            try
            {
                result = Regex.IsMatch(@this.Argument, regex);
            }
            catch (Exception ex)
            {
                result = false;
                innerException = ex;
            }
            if (!result)
            {
                throw new ArgumentException($"The string '{@this.Argument}' does not match the regular expression '{regex}'", @this.ArgumentName, innerException);
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
            bool result;
            Exception? innerException = null;
            try
            {
                result = Regex.IsMatch(@this.Argument, regex, regexOptions);
            }
            catch (Exception ex)
            {
                result = false;
                innerException = ex;
            }
            if (!result)
            {
                throw new ArgumentException($"The string '{@this.Argument}' does not match the regular expression '{regex}'", @this.ArgumentName, innerException);
            }
            return @this;
        }
    }
}
