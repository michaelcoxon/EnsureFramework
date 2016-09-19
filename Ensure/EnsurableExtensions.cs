using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework
{
    /// <summary>
    /// The default ensurables
    /// </summary>
    public static class EnsurableExtensions
    {
        /// <summary>
        /// Ensures the value is not null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Ensurable<T> IsNotNull<T>(this Ensurable<T> source)
        {
            return new EnsurableNotNull<T>(source);
        }

        /// <summary>
        /// Ensures the value is not null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Ensurable<T> IsNotNullOrEmpty<T>(this Ensurable<T> source)
            where T : IEnumerable
        {
            return new EnsurableNotEmpty<T>(source.IsNotNull());
        }

        /// <summary>
        /// Ensures the value is not null, not empty and is an email address.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Ensurable<string> IsEmailAddress(this Ensurable<string> source)
        {
            return new EnsurableEmailAddress(source.IsNotNullOrEmpty());
        }

    }
}
