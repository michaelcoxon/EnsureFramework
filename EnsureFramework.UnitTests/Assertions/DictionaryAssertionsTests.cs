using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnsureFramework.Assertions;

using Xunit;

namespace EnsureFramework.UnitTests.Assertions
{
    public class DictionaryAssertionsTests
    {
        [Fact]
        public void HasKeyTest()
        {
            var dictionary = new Dictionary<string, string>
            {
                ["key"] = "value",
            };

            Ensure.Arg(dictionary, "dictionary").HasKey("key");
        }

        [Fact]
        public void HasKeyFailTest()
        {
            var dictionary = new Dictionary<string, string>
            {
                ["key"] = "value",
            };

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.Arg(dictionary, "dictionary").HasKey("notkey");
            });
        }

        [Fact]
        public void WithKeyTest()
        {
            var dictionary = new Dictionary<string, string>
            {
                ["key"] = "value",
            };

            Ensure.Arg(dictionary["key"]);
        }

        [Fact]
        public void WithKey_NullableValue_Test()
        {
            var dictionary = new Dictionary<string, int?>
            {
                ["key"] = 1,
            };

            Ensure.Arg(dictionary["key"]);
        }

        [Fact]
        public void WithKey_NullableValue_2_Test()
        {
            var dictionary = new Dictionary<string, int?>
            {
                ["key"] = 1,
            };

            Ensure.Arg(dictionary["key"]).IsTypeOf(typeof(int));
        }

        [Fact]
        public void WithKeyFailTest()
        {
            var dictionary = new Dictionary<string, string?>
            {
                ["key"] = null,
            };

            Assert.Throws<ArgumentNullException>(() =>
            {
                Ensure.Arg(dictionary["key"]);
            });
        }
    }
}
