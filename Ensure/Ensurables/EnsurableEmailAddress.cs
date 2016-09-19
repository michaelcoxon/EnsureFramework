using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq.Expressions;

namespace EnsureFramework
{
    /// <summary>
    /// Create a new ensurable that ensure that the previous ensurable is an 
    /// email address. Internally uses the <seealso cref="EmailAddressAttribute"/> 
    /// for validation.
    /// </summary>
    /// <seealso cref="Ensurable{T}" />
    internal class EnsurableEmailAddress : Ensurable<string>
    {
        private static EmailAddressAttribute _emailAddressAttribute = new EmailAddressAttribute();

        /// <summary>
        /// Initializes a new instance of the <see cref="EnsurableEmailAddress"/> class.
        /// </summary>
        /// <param name="ensurable">The ensurable.</param>
        public EnsurableEmailAddress(Ensurable<string> ensurable) : base(ensurable) { }

        /// <summary>
        /// Executes the ensurable.
        /// </summary>
        /// <exception cref="ArgumentException">Not an email address</exception>
        [DebuggerNonUserCode]
        protected override void Ensure()
        {
            if (!_emailAddressAttribute.IsValid(this.ExpressionValue))
            {
                throw new ArgumentException("Not an email address", this.ExpressionName);
            }
        }
    }
}