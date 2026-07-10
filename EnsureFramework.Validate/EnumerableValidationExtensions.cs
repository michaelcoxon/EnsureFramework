using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

using EnsureFramework;
using EnsureFramework.Assertions;
using EnsureFramework.Results;

namespace EnsureFramework
{
    public static class EnumerableValidationExtensions
    {
        public static IValidationResult<IEnumerable> IsNotEmpty([NotNull] this IValidationResult<IEnumerable> @this)
        {
            @this.AssertionResults.Add(EnumerableAssertions.IsNotEmpty(@this.Value));
            return @this;
        }

        public static IValidationResult<IEnumerable<T>> IsNotEmpty<T>([NotNull] this IValidationResult<IEnumerable<T>> @this)
        {
            @this.AssertionResults.Add(EnumerableAssertions.IsNotEmpty(@this.Value));
            return @this;
        }

        public static IValidationResult<IEnumerable<T>> Contains<T>([NotNull] this IValidationResult<IEnumerable<T>> @this, T item)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Contains(@this.Value, item));
            return @this;
        }

        public static IValidationResult<IEnumerable> Contains([NotNull] this IValidationResult<IEnumerable> @this, object item)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Contains(@this.Value, item));
            return @this;
        }

        public static IValidationResult<IEnumerable<T>> Any<T>([NotNull] this IValidationResult<IEnumerable<T>> @this, Func<T, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Any(@this.Value, predicate));
            return @this;
        }

        public static IValidationResult<IEnumerable> Any([NotNull] this IValidationResult<IEnumerable> @this, Func<object, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.Any(@this.Value, predicate));
            return @this;
        }

        public static IValidationResult<IEnumerable<T>> All<T>([NotNull] this IValidationResult<IEnumerable<T>> @this, Func<T, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.All(@this.Value, predicate));
            return @this;
        }

        public static IValidationResult<IEnumerable> All([NotNull] this IValidationResult<IEnumerable> @this, Func<object, bool> predicate)
        {
            @this.AssertionResults.Add(EnumerableAssertions.All(@this.Value, predicate));
            return @this;
        }
    }
}
