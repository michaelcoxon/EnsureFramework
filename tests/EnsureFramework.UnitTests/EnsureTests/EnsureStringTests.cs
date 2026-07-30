namespace EnsureFramework.UnitTests.EnsureTests
{
    using System;
    using System.Text.RegularExpressions;

    using EnsureFramework;

    using Xunit;

    public class EnsureStringTests
    {
        [Fact]
        public void IsNotEmpty_Default()
        {
            var arg = "asdf";
            Ensure.Arg(arg).IsNotEmpty();
        }

        [Fact]
        public void IsNotEmpty_Empty_Error()
        {
            var arg = string.Empty;
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotEmpty());
        }


        [Fact]
        public void IsNotEmptyOrWhiteSpace_Default()
        {
            var arg = "asdf";
            var result = Ensure.Arg(arg).IsNotEmptyOrWhiteSpace();
        }

        [Fact]
        public void IsNotEmptyOrWhiteSpace_Empty_Error()
        {
            var arg = string.Empty;
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotEmptyOrWhiteSpace());
        }

        [Fact]
        public void IsNotEmptyOrWhiteSpace_WhiteSpace_Error()
        {
            var arg = " ";
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).IsNotEmptyOrWhiteSpace());
        }


        [Fact]
        public void Matches_FourLetters()
        {
            var arg = "asdf";
            Ensure.Arg(arg).Matches("^[a-z]{4}$");
        }

        [Fact]
        public void Matches_FourLetters_Error()
        {
            var arg = "asdfg";
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Matches("^[a-z]{4}$"));
        }

        [Fact]
        public void Matches_FourLettersFourNumbers()
        {
            var arg = "asdf1234";
            Ensure.Arg(arg).Matches("^[a-z]{4}\\d{4}$");
        }

        [Fact]
        public void Matches_FourLettersFourNumbers_Error()
        {
            var arg = "asdf12345";
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Matches("^[a-z]{4}\\d{4}$"));
        }


        [Fact]
        public void Matches_REO_FourLetters()
        {
            var arg = "aSdf";
            Ensure.Arg(arg).Matches("^[a-z]{4}$", RegexOptions.IgnoreCase);
        }

        [Fact]
        public void Matches_REO_FourLetters_Error()
        {
            var arg = "aSdfg";
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Matches("^[a-z]{4}$", RegexOptions.IgnoreCase));
        }

        [Fact]
        public void Matches_REO_FourLettersFourNumbers()
        {
            var arg = "aSdf1234";
            Ensure.Arg(arg).Matches("^[a-z]{4}\\d{4}$", RegexOptions.IgnoreCase);
        }

        [Fact]
        public void Matches_REO_FourLettersFourNumbers_Error()
        {
            var arg = "asdf12345";
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Matches("^[a-z]{4}\\d{4}$", RegexOptions.IgnoreCase));
        }
    }
}
