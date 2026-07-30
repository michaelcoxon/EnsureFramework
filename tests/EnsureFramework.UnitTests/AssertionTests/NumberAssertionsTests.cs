namespace EnsureFramework.UnitTests.AssertionTests
{
    using EnsureFramework.Assertions;

    using Xunit;

    public class NumberAssertionsTests
    {
        [Fact]
        public void IsNegative_Positive_Test()
        {
            Assert.False(NumberAssertions.IsNegative(1).Success);
        }

        [Fact]
        public void IsNegative_Zero_Test()
        {
            Assert.False(NumberAssertions.IsNegative(0).Success);
        }

        [Fact]
        public void IsNegative_Negative_Test()
        {
            Assert.True(NumberAssertions.IsNegative(-1).Success);
        }

        [Fact]
        public void IsZero_Positive_Test()
        {
            Assert.False(NumberAssertions.IsZero(1).Success);
        }

        [Fact]
        public void IsZero_Zero_Test()
        {
            Assert.True(NumberAssertions.IsZero(0).Success);
        }

        [Fact]
        public void IsZero_Negative_Test()
        {
            Assert.False(NumberAssertions.IsZero(-1).Success);
        }
    }
}