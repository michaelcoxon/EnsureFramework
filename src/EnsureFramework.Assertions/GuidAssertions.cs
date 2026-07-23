namespace EnsureFramework.Assertions
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using EnsureFramework.Results;

    /// <summary>
    /// Provides assertion methods for validating <see cref="System.Guid"/> values.
    /// </summary>
    public static class GuidAssertions
    {
        /// <summary>
        /// Determines whether the specified <see cref="Guid"/> value is not empty.
        /// </summary>
        /// <param name="this">The <see cref="Guid"/> value to validate.</param>
        /// <returns><see langword="true"/> if the specified <see cref="Guid"/> is not <see cref="Guid.Empty"/>; otherwise, <see
        /// langword="false"/>.</returns>
        public static IAssertionResult IsValidGuid(Guid @this)
        {
            if (@this == Guid.Empty)
            {
                return AssertionResult.Fail(Resources.Strings.The_value_is_not_a_vaild_guid);
            }
            return AssertionResult.Ok;
        }
    }
}
