using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace EnsureFramework
{
    /// <summary>
    /// Create a new ensurable that ensure that the previous ensurable is not null
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="EnsureFramework.Ensurable{T}" />
    internal class EnsurableNotNull<T> : Ensurable<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnsurableNotNull{T}"/> class.
        /// </summary>
        /// <param name="ensurable">The ensurable.</param>
        public EnsurableNotNull(Ensurable<T> ensurable) : base(ensurable) { }

        /// <summary>
        /// Executes the ensurable.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        [DebuggerNonUserCode]
        protected override void Ensure()
        {
            if (this.ExpressionValue == null)
            {
                throw new ArgumentNullException(this.ExpressionName);
            }
        }
    }
}