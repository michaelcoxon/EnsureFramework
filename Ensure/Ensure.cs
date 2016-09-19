using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework
{
    /// <summary>
    /// The root of the <seealso cref="EnsureFramework"/>. This is where it all begins. 
    /// Add Extension methods that have the `this` parameter of the type 
    /// <seealso cref="Ensurable{T}"/> to make your own.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors")]
    public sealed partial class Ensure
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ensure"/> class.
        /// </summary>
        public Ensure() { }

        private class EnsurableExpression<T> : Ensurable<T>
        {
            public EnsurableExpression(Expression<Func<T>> expression) : base(expression) { }

            [DebuggerNonUserCode]
            protected override void Ensure()
            {
                // this is intentionally left empty
            }
        }

        /// <summary>
        /// This is the initial step of the ensureable. This collections the expression to be ensured.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [DebuggerNonUserCode]
        public static Ensurable<T> That<T>(Expression<Func<T>> expression)
        {
            return new EnsurableExpression<T>(expression);
        }
    }
}
