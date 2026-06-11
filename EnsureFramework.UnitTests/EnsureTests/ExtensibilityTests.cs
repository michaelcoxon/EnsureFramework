using EnsureFramework.UnitTests.EnsureTests;

namespace EnsureFramework.UnitTests.EnsureTests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Xunit;

    using static EnsureFramework.UnitTests.EnsureTests.ExtensibilityTests;

    public class ExtensibilityTests
    {
        public record User(string Name, DateOnly DateOfBirth);


        [Fact]
        public void Today()
        {
            var user = new User("TestUser", DateOnly.FromDateTime(DateTime.Today.AddYears(-18)));
            Ensure.Arg(user).IsAnAdult();
        }

        [Fact]
        public void Yesterday()
        {
            var user = new User("TestUser", DateOnly.FromDateTime(DateTime.Today.AddYears(-18).AddDays(-1)));
            Ensure.Arg(user).IsAnAdult();
        }

        [Fact]
        public void Tomorrow()
        {
            var user = new User("TestUser", DateOnly.FromDateTime(DateTime.Today.AddYears(-18).AddDays(1)));
            Assert.Throws<ArgumentException>(() => Ensure.Arg(user).IsAnAdult());
        }
    }

    public static class ExtensibilityAssertions
    {
        public static IArgumentAssertionBuilder<User> IsAnAdult([NotNull]this IArgumentAssertionBuilder<User> @this)
        {
            if (@this.Argument.DateOfBirth > DateOnly.FromDateTime(DateTime.Today.AddYears(-18)))
            {
                throw new ArgumentException("User is underage", @this.ArgumentName);
            }
            return @this;
        }
    }
}
