namespace EnsureFramework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using EnsureFramework.Assertions;
    using EnsureFramework.Results;

    /// <summary>
    /// Provides extension methods for type validation on <see cref="IValidationResult{T}"/>.
    /// </summary>
    public static class TypeValidationExtensions
    {

        /// <summary>
        /// Adds a validation assertion that the validated object is exactly of the specified type.
        /// </summary>
        /// <remarks>This method checks for an exact type match and does not consider derived types. Use
        /// this when the validated object must not be a subclass or implementer of the specified type.</remarks>
        /// <typeparam name="T">The type of the object being validated.</typeparam>
        /// <param name="this">The validation result to which the type assertion is added. Cannot be null.</param>
        /// <param name="type">The type to compare against the validated object's type. Cannot be null.</param>
        /// <returns>The same validation result instance with the type assertion added.</returns>
        public static IValidationResult<T> IsExactTypeOf<T>(this IValidationResult<T> @this, Type type)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(TypeAssertions.Is<T>(type));
            return @this;
        }

        /// <summary>
        /// Adds a validation assertion that the type parameter inherits from or implements the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the object being validated.</typeparam>
        /// <param name="this">The validation result to which the inheritance assertion is added.</param>
        /// <param name="type">The type that the type parameter must inherit from or implement. Cannot be null.</param>
        /// <returns>The same validation result instance with the inheritance assertion added.</returns>
        public static IValidationResult<T> InheritsTypeOf<T>(this IValidationResult<T> @this, Type type)
        {
            ArgumentNullException.ThrowIfNull(@this);

            @this.AssertionResults.Add(TypeAssertions.IsAssignableFrom<T>(type));
            return @this;
        }
    }
}
