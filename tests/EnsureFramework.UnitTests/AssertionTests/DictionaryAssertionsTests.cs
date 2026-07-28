using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnsureFramework;
using EnsureFramework.Assertions;

using Xunit;

namespace EnsureFramework.UnitTests.AssertionTests
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
            Assert.True(DictionaryAssertions.HasKey(dictionary, "key").Success);
        }

        [Fact]
        public void HasKeyFailTest()
        {
            var dictionary = new Dictionary<string, string>
            {
                ["key"] = "value",
            };
            Assert.False(DictionaryAssertions.HasKey(dictionary, "notkey").Success);
        }
    }
}
