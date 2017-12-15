using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> and <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class StringAssertions
    {
        /// <summary>
        /// Ensures the <see cref="string" /> argument is not <c>null</c> or empty.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<string> IsNotNullOrEmpty(this IArgumentAssertionBuilder<string> @this)
        {
            if (@this.Argument == null)
            {
                throw new ArgumentNullException(@this.ArgumentName);
            }
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
        public static IArgumentAssertionBuilder<string> Matches(this IArgumentAssertionBuilder<string> @this, string regex)
        {
            bool result;
            Exception innerException = null;
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
        public static IArgumentAssertionBuilder<string> Matches(this IArgumentAssertionBuilder<string> @this, string regex, RegexOptions regexOptions)
        {
            bool result;
            Exception innerException = null;
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
