namespace EnsureFramework.UnitTests.EnsureTests
{
    using System;
    using System.Collections.Generic;

    using Xunit;

    public class EnsureDictionaryTests
    {
        private static readonly Dictionary<string, string> dictionary = new()
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
