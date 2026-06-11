namespace EnsureFramework.UnitTests.ValidateTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xunit;

    public class ValidateThatTests
    {
        [Fact]
        public void ValidateThat_IsNotNull_Default()
        {
            var subject = (string?)null;
            var result = Validate.That(subject).IsNotNull();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsExactTypeOf_Default()
        {
            var subject = (string?)null;
            var result = Validate.That(subject).IsExactTypeOf(typeof(string));
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsExactTypeOf_NotExactType()
        {
            var subject = (string?)null;
            var result = Validate.That(subject).IsExactTypeOf(typeof(int));
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_Chained_IsNotNull_IsExactTypeOf_Default()
        {
            var subject = (string?)null;
            var result = Validate.That(subject).IsNotNull().IsExactTypeOf(typeof(string));
            Assert.True(result.IsError);
            Assert.Single(result.AssertionResults, a => !a.Success);
        }

        [Fact]
        public void ValidateThat_Chained_IsNotNull_IsExactTypeOf_NotExactType()
        {
            var subject = (string?)null;
            var result = Validate.That(subject).IsNotNull().IsExactTypeOf(typeof(int));
            Assert.True(result.IsError);
            Assert.Equal(2, result.AssertionResults.Where(a => !a.Success).Count());
        }
    }
}
