using System;
using System.Collections;
using System.Diagnostics;
using System.Linq.Expressions;

namespace EnsureFramework
{
    /// <summary>
    /// Create a new ensurable that ensure that the previous ensurable is not empty. Only works with things that inherit from <seealso cref="IEnumerable"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="EnsureFramework.Ensurable{T}" />
    internal class EnsurableNotEmpty<T> : Ensurable<T>
        where T : IEnumerable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnsurableNotEmpty{T}"/> class.
        /// </summary>
        /// <param name="ensurable">The ensurable.</param>
        public EnsurableNotEmpty(Ensurable<T> ensurable) : base(ensurable) { }

        /// <summary>
        /// Executes the ensurable.
        /// </summary>
        /// <exception cref="ArgumentException">The {typeof(T)}</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
        [DebuggerNonUserCode]
        protected override void Ensure()
        {
            var e = this.ExpressionValue.GetEnumerator();

            if (!e.MoveNext())
            {
                throw new ArgumentException($"The {typeof(T)} is empty", this.ExpressionName);
            }
        }
    }
}
