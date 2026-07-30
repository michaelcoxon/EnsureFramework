namespace EnsureFramework.UnitTests.AssertionTests
{
    using System.Collections.Generic;

    using EnsureFramework.Assertions;

    using Xunit;

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
