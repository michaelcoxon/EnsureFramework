using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnsureFramework.Assertions;

using Xunit;

namespace EnsureFramework.UnitTests.Assertions
{
    public class StringAssertionsTests
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
            Ensure.Arg(arg).IsNotEmptyOrWhiteSpace();
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
            Ensure.Arg(arg).Matches("^\\w{4}$");
        }

        [Fact]
        public void Matches_FourLetters_Error()
        {
            var arg = "asdfg";
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Matches("^\\w{4}$"));
        }

        [Fact]
        public void Matches_FourLettersFourNumbers()
        {
            var arg = "asdf1234";
            Ensure.Arg(arg).Matches("^\\w{4}\\d{4}$");
        }

        [Fact]
        public void Matches_FourLettersFourNumbers_Error()
        {
            var arg = "asdf12345";
            Assert.Throws<ArgumentException>(() => Ensure.Arg(arg).Matches("^\\w{4}\\d{4}$"));
        }
    }
}
