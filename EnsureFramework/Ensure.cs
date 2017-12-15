﻿using EnsureFramework.Assertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework
{
    /// <summary>
    /// A simple helper for validation
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

        /// <summary>
        /// Provides the helpers for validation
        /// </summary>
        /// <param name="arg">The argument.</param>
        /// <param name="argName">Name of the argument.</param>
        /// <returns></returns>
        [DebuggerNonUserCode]
        public static IArgumentAssertionBuilder<T> Arg<T>(T arg, string argName)
        {
            return new ArgumentAssertionBuilder<T>
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
        public static IArgumentAssertionBuilder<T> Arg<T>(Expression<Func<T>> argExpression)
        {
            var body = argExpression.Body as MemberExpression ?? throw new NotSupportedException($"Expression '{nameof(argExpression)}' must contain an argument");
            var constant = body.Expression as ConstantExpression ?? throw new NotSupportedException($"Expression '{nameof(argExpression)}' must contain an argument");
            var field = body.Member as FieldInfo ?? throw new NotSupportedException($"Expression '{nameof(argExpression)}' must contain an argument");

            var argument = (T)field.GetValue(constant.Value);
            var argumentName = field.Name;

            return Arg(argument, argumentName);
        }
    }
}