namespace EnsureFramework.UnitTests.AssertionTests
{
    using System.Text.RegularExpressions;

    using EnsureFramework.Assertions;

    using Xunit;

    public class StringAssertionsTests
    {
        [Fact]
        public void IsNotEmpty_Default()
        {
            Assert.True(StringAssertions.IsNotEmpty("asdf").Success);
        }

        [Fact]
        public void IsNotEmpty_Empty_Error()
        {
            Assert.False(StringAssertions.IsNotEmpty(string.Empty).Success);
        }

        [Fact]
        public void IsNotEmptyOrWhiteSpace_Default()
        {
            Assert.True(StringAssertions.IsNotEmptyOrWhiteSpace("asdf").Success);
        }

        [Fact]
        public void IsNotEmptyOrWhiteSpace_Empty_Error()
        {
            Assert.False(StringAssertions.IsNotEmptyOrWhiteSpace(string.Empty).Success);
        }

        [Fact]
        public void IsNotEmptyOrWhiteSpace_WhiteSpace_Error()
        {
            Assert.False(StringAssertions.IsNotEmptyOrWhiteSpace(" ").Success);
        }

        [Fact]
        public void Matches_FourLetters()
        {
            Assert.True(StringAssertions.Matches("asdf", "^[a-z]{4}$").Success);
        }

        [Fact]
        public void Matches_FourLetters_Error()
        {
            Assert.False(StringAssertions.Matches("asdfg", "^[a-z]{4}$").Success);
        }

        [Fact]
        public void Matches_FourLettersFourNumbers()
        {
            Assert.True(StringAssertions.Matches("asdf1234", "^[a-z]{4}\\d{4}$").Success);
        }

        [Fact]
        public void Matches_FourLettersFourNumbers_Error()
        {
            Assert.False(StringAssertions.Matches("asdf12345", "^[a-z]{4}\\d{4}$").Success);
        }

        [Fact]
        public void Matches_REO_FourLetters()
        {
            Assert.True(StringAssertions.Matches("aSdf", "^[a-z]{4}$", RegexOptions.IgnoreCase).Success);
        }

        [Fact]
        public void Matches_REO_FourLetters_Error()
        {
            Assert.False(StringAssertions.Matches("aSdfg", "^[a-z]{4}$", RegexOptions.IgnoreCase).Success);
        }

        [Fact]
        public void Matches_REO_FourLettersFourNumbers()
        {
            Assert.True(StringAssertions.Matches("aSdf1234", "^[a-z]{4}\\d{4}$", RegexOptions.IgnoreCase).Success);
        }

        [Fact]
        public void Matches_REO_FourLettersFourNumbers_Error()
        {
            Assert.False(StringAssertions.Matches("asdf12345", "^[a-z]{4}\\d{4}$", RegexOptions.IgnoreCase).Success);
        }
    }
}
