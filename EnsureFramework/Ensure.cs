using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection;
using EnsureFramework.Assertions;
using EnsureFramework.Resources;

namespace EnsureFramework
{
    /// <summary>
    /// The core assertion entry point
    /// </summary>
    [DebuggerNonUserCode]
    public sealed class Ensure
    {
        [DebuggerNonUserCode]
        private class ArgumentAssertionBuilder<T> : IArgumentAssertionBuilder<T>
        {
            public T Argument { get; set; }

            public string ArgumentName { get; set; }

            object IArgumentAssertionBuilder.Argument => this.Argument;
        }

        [DebuggerNonUserCode]
        private class NestedArgumentAssertionBuilder<TParentAssertion, T> : INestedArgumentAssertionBuilder<TParentAssertion, T>
            where TParentAssertion : IArgumentAssertionBuilder
        {
            private readonly TParentAssertion _parent;

            public T Argument { get; set; }

            public string ArgumentName { get; set; }

            object INestedArgumentAssertionBuilder<TParentAssertion>.Argument => this.Argument;

            public NestedArgumentAssertionBuilder(TParentAssertion parent)
            {
                this._parent = parent;
            }

            public TParentAssertion Pop()
            {
                return this._parent;
            }
        }

        /// <summary>
        /// Provides the helpers for validation
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>(T arg, string argName)
        {
            if (arg is object obj && obj is null)
            {
                throw new ArgumentNullException(argName);
            }

            return new ArgumentAssertionBuilder<T>
            {
                Argument = arg,
                ArgumentName = argName,
            };
        }

        /// <summary>
        /// Provides the helpers for validation
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>(T? arg, string argName)
            where T : struct
        {
            if (!arg.HasValue)
            {
                throw new ArgumentNullException(argName);
            }

            return new ArgumentAssertionBuilder<T>
            {
                Argument = arg.Value,
                ArgumentName = argName,
            };
        }

        /// <summary>
        /// Arguments the specified argument expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argExpression">The argument expression. in form of `() => arg`</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">argExpression</exception>
        //[DebuggerNonUserCode]
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>(Expression<Func<T>> argExpression)
        {
            if (argExpression is null)
            {
                throw new ArgumentNullException(nameof(argExpression));
            }
            var exceptionMessage = string.Format(Strings.ExpressionMustContainAnArgument_Format, nameof(argExpression));

            var body = argExpression.Body as MemberExpression ?? throw new NotSupportedException(exceptionMessage);
            var constant = body.Expression as ConstantExpression ?? throw new NotSupportedException(exceptionMessage);
            var field = body.Member as FieldInfo ?? throw new NotSupportedException(exceptionMessage);

            var argument = (T)field.GetValue(constant.Value);
            var argumentName = field.Name;

            return Arg(argument, argumentName);
        }

        /// <summary>
        /// Provides the helpers for validation
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentAssertion, T> Nested<TParentAssertion, T>(TParentAssertion parent, T arg, string argName)
            where TParentAssertion : IArgumentAssertionBuilder
        {
            if (arg is object obj && obj is null)
            {
                throw new ArgumentNullException(argName);
            }

            return new NestedArgumentAssertionBuilder<TParentAssertion, T>(parent)
            {
                Argument = arg,
                ArgumentName = argName,
            };
        }

        /// <summary>
        /// Arguments the specified argument expression.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argExpression">The argument expression. in form of `() => arg`</param>
        /// <returns></returns>
        /// <exception cref="System.NotSupportedException">argExpression</exception>
        //[DebuggerNonUserCode]
        [DebuggerNonUserCode]
        public static INestedArgumentAssertionBuilder<TParentAssertion, T> Nested<TParentAssertion, T>(TParentAssertion parent, Expression<Func<T>> argExpression)
            where TParentAssertion : IArgumentAssertionBuilder
        {
            if (argExpression is null)
            {
                throw new ArgumentNullException(nameof(argExpression));
            }
            var exceptionMessage = string.Format(Strings.ExpressionMustContainAnArgument_Format, nameof(argExpression));

            var body = argExpression.Body as MemberExpression ?? throw new NotSupportedException(exceptionMessage);
            var constant = body.Expression as ConstantExpression ?? throw new NotSupportedException(exceptionMessage);
            var field = body.Member as FieldInfo ?? throw new NotSupportedException(exceptionMessage);

            var argument = (T)field.GetValue(constant.Value);
            var argumentName = field.Name;

            return Nested(parent, argument, argumentName);
        }

    }
}
