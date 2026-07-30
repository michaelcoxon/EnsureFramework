namespace EnsureFramework.UnitTests.EnsureTests
{
    using System;

    using EnsureFramework;

    using Xunit;

    public class FxCopTests
    {
        internal static void Method(object? obj, string? str)
        {
            Ensure.Arg(obj);
            Ensure.Arg(str).IsNotEmpty();

            // we shouldn't get any green squiggles cause Ensure.Arg() should imply that 
            // nullability has been checked.
            _ = obj.ToString();
            _ = str.ToString();
        }

        [Fact]
        public void Test()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Method(null, null);
            });
        }
    }
}
