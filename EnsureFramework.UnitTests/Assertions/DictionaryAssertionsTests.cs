using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
