using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework
{
    /// <summary>
    /// The base clas of all ensurables. Inherit from this to make your own ensurables.
    /// </summary>
    /// <typeparam name="T">This is the type that we are ensuring in the expression (the expression return type)</typeparam>
    /// <example>
    /// <code>
    /// public class EnsurableNotNull&lt;T&gt; : Ensurable&lt;T&gt;
    /// {
    ///     public EnsurableNotNull(Ensurable&lt;T&gt; ensurable) : base(ensurable) { }
    /// 
    ///     [DebuggerNonUserCode]
    ///     protected override void Ensure()
    ///     {
    ///         if (this.ExpressionValue == null)
    ///         {
    ///             throw new ArgumentNullException(this.ExpressionName);
    ///         }
    ///     }
    /// }
    /// </code>
    /// </example>
    public abstract class Ensurable<T>
    {
        private class ExpressionEvaluator
        {
            private readonly Expression<Func<T>> _source;

            public T Value => this._source.Compile().Invoke();

            public ExpressionEvaluator(Expression<Func<T>> source)
            {
                this._source = source;
            }

            public string Name => GetName(this._source.Body);

            private static string GetName(Expression expr)
            {
                switch (expr.NodeType)
                {
                    case ExpressionType.MemberAccess:
                        return GetName((MemberExpression)expr);

                    default:
                        throw new NotSupportedException(expr.NodeType.ToString());
                }
            }

            private static string GetName(MemberExpression expr)
            {
                return expr.Member.Name;
            }
        }

        /// <summary>
        /// Gets the expression that we are ensuring.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        protected Expression<Func<T>> Expression { get; private set; }

        /// <summary>
        /// Gets the value of expression we are ensuring.
        /// </summary>
        /// <value>
        /// The expression value.
        /// </value>
        protected T ExpressionValue { get; private set; }

        /// <summary>
        /// Gets the name of the expression that we are ensuring.
        /// </summary>
        /// <value>
        /// The name of the expression.
        /// </value>
        protected string ExpressionName { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ensurable{T}"/> class.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <exception cref="ApplicationException">Expression cannot compile '{this.Expression}'</exception>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1305:SpecifyIFormatProvider", MessageId = "System.String.Format(System.String,System.Object)")]
        [DebuggerNonUserCode]
        protected internal Ensurable(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            this.Expression = expression;

            var method = this.Expression.Compile();
            if (method == null)
            {
                throw new InvalidOperationException($"Expression cannot compile '{this.Expression}'");
            }

            var eval = new ExpressionEvaluator(expression);
            this.ExpressionName = eval.Name;
            this.ExpressionValue = eval.Value;

            this.Ensure();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Ensurable{T}"/> class.
        /// </summary>
        /// <param name="ensurable">The ensurable.</param>
        protected Ensurable(Ensurable<T> ensurable)
        {
            if (ensurable == null)
            {
                throw new ArgumentNullException(nameof(ensurable));
            }
            this.Expression = ensurable.Expression;
            this.ExpressionName = ensurable.ExpressionName;
            this.ExpressionValue = ensurable.ExpressionValue;
            this.Ensure();
        }

        /// <summary>
        /// Executes the ensurable.
        /// </summary>
        [DebuggerNonUserCode]
        protected abstract void Ensure();
    }
}
