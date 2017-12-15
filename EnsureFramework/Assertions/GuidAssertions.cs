using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="IArgumentAssertionBuilder"/> that provide assertions in the <see cref="Ensure.Arg{T}(System.Linq.Expressions.Expression{Func{T}})"/> and <see cref="Ensure.Arg{T}(T, string)"/> helpers
    /// </summary>
    public static class GuidAssertions
    {
        /// <summary>
        /// Ensures the <see cref="Guid" /> argument is not equal to <see cref="Guid.Empty" />.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Guid> IsValidGuid(this IArgumentAssertionBuilder<Guid> @this)
        {
            if (@this.Argument == Guid.Empty)
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }

        /// <summary>
        /// Ensures the <see cref="Guid" /> argument is not equal to <see cref="Guid.Empty" /> and is not <c>null</c>.
        /// </summary>
        /// <param name="this">The this.</param>
        /// <exception cref="System.ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<Guid?> IsValidGuid(this IArgumentAssertionBuilder<Guid?> @this)
        {
            if (!@this.Argument.HasValue)
            {
                throw new ArgumentNullException(@this.ArgumentName);
            }
            if (@this.Argument.Value == Guid.Empty)
            {
                throw new ArgumentException(null, @this.ArgumentName);
            }
            return @this;
        }
    }
}
