using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

using EnsureFramework.Assertions;
using EnsureFramework.Results;

namespace EnsureFramework
{
    /// <summary>
    /// Provides extension methods for validating <see cref="Guid"/> values.
    /// </summary>
    public static partial class GuidValidationExtenstions
    {
        /// <summary>
        /// Validates that the Guid value is not equal to Guid.Empty.
        /// </summary>
        /// <param name="this">The validation result to validate.</param>
        /// <returns>The validation result for method chaining.</returns>
        public static IValidationResult<Guid> IsValidGuid([NotNull] this IValidationResult<Guid> @this)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(GuidAssertions.IsValidGuid(@this.Value));
            return @this;
        }
    }
}
