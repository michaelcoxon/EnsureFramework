namespace EnsureFramework.UnitTests.ValidateTests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using Xunit;

    public class ValidateEnumerableTests
    {
        [Fact]
        public void ValidateThat_IsNotNullOrEmpty_Default()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).IsNotNullOrEmpty();
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNotNullOrEmpty_Empty_Fail()
        {
            var subject = new List<string>();
            var result = Validate.That(subject).IsNotNullOrEmpty();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNotNullOrEmpty_Null_Fail()
        {
            List<string>? subject = null;
            var result = Validate.That(subject).IsNotNullOrEmpty();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNotEmpty_Default()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).IsNotEmpty();
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_IsNotEmpty_Empty_Fail()
        {
            var subject = new List<string>();
            var result = Validate.That(subject).IsNotEmpty();
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_Contains_Generic_Default()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).Contains("asdf");
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_Contains_Generic_Fail()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).Contains("asdfs");
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_Contains_Default()
        {
            var subject = new List<string>() { "asdf" } as IEnumerable;
            var result = Validate.That(subject).Contains("asdf");
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_Contains_Fail()
        {
            var subject = new List<string>() { "asdf" } as IEnumerable;
            var result = Validate.That(subject).Contains(2);
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_Any_Generic_Default()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).Any(i => i == "asdf");
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_Any_Generic_Fail()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).Any(i => i == "asdfs");
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_Any_Default()
        {
            var subject = new List<string>() { "asdf" } as IEnumerable;
            var result = Validate.That(subject).Any((object i) => Equals(i, "asdf"));
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_Any_Fail()
        {
            var subject = new List<string>() { "asdf" } as IEnumerable;
            var result = Validate.That(subject).Any((object i) => Equals(i, 2));
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_All_Generic_Default()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).All(i => i == "asdf");
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_All_Generic_Fail()
        {
            var subject = new List<string>() { "asdf" };
            var result = Validate.That(subject).All(i => i == "asdfs");
            Assert.True(result.IsError);
        }

        [Fact]
        public void ValidateThat_All_Default()
        {
            var subject = new List<string>() { "asdf" } as IEnumerable;
            var result = Validate.That(subject).All((object i) => Equals(i, "asdf"));
            Assert.False(result.IsError);
        }

        [Fact]
        public void ValidateThat_All_Fail()
        {
            var subject = new List<string>() { "asdf" } as IEnumerable;
            var result = Validate.That(subject).All((object i) => Equals(i, 2));
            Assert.True(result.IsError);
        }
    }
}
