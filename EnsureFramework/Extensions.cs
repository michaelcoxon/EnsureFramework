using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ST = System.Text;

namespace EnsureFramework
{
    /// <summary>
    /// Extensions for <see cref="string"/>
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Determines whether the <see cref="IEnumerable{T}"/> is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>True if null or empty</returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || source.Count() == 0;
        }

        /// <summary>
        /// Determines whether the <see cref="string"/> is null or empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>True if null or empty</returns>
        public static bool IsNullOrEmpty<T>(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

    }
}
