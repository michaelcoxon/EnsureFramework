using System;
using System.Collections.Generic;

using Xunit;

namespace EnsureFramework.UnitTests.EnsureTests
{
    public class EnsureDictionaryTests
    {
        private readonly static Dictionary<string, string> dictionary = new()
        {
            ["key"] = "value",
        };

        [Fact]
        public void HasKey_Default()
        {
            Ensure.Arg(dictionary, "dictionary").HasKey("key");
        }

        [Fact]
        public void HasKey_Throws()
        {
            Assert.Throws<ArgumentException>(() => Ensure.Arg(dictionary, "dictionary").HasKey("notkey"));
        }
    }
}
