namespace EnsureFramework.UnitTests.EnsureTests
{
    using System;

    using Xunit;

    public class EnsureTests
    {
        [Fact]
        public void EnsureArgument_WithName()
        {
            var arg = Guid.NewGuid();
            var name = Guid.NewGuid().ToString();

            var assertionBuilder = Ensure.Arg(arg, name);

            Assert.Equal(arg, assertionBuilder.Argument);
            Assert.Equal(name, assertionBuilder.ArgumentName);
        }

        [Fact]
        public void EnsureArgument_WithoutName()
        {
            var arg = Guid.NewGuid();

            var assertionBuilder = Ensure.Arg(arg);

            Assert.Equal(arg, assertionBuilder.Argument);
            Assert.Equal(nameof(arg), assertionBuilder.ArgumentName);
        }

        [Fact]
        public void EnsureArgument_WithName_Fail()
        {
            Guid? arg = null;
            var name = Guid.NewGuid().ToString();

            Assert.Throws<ArgumentNullException>(() =>
            {
                Ensure.Arg(arg, name);
            });
        }

        [Fact]
        public void EnsureArgument_WithoutName_Fail()
        {
            Guid? arg = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                Ensure.Arg(arg);
            });
        }

        [Fact]
        public void EnsureArgument_IsNull_WithName()
        {
            Guid? arg = null;
            var name = Guid.NewGuid().ToString();

            Ensure.ArgIsNull(arg, name);
        }

        [Fact]
        public void EnsureArgument_IsNull_WithoutName()
        {
            Guid? arg = null;

            Ensure.ArgIsNull(arg);
        }


        [Fact]
        public void EnsureArgument_IsNull_WithName_Fail()
        {
            var arg = Guid.NewGuid();
            var name = Guid.NewGuid().ToString();

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.ArgIsNull(arg, name);
            });
        }

        [Fact]
        public void EnsureArgument_IsNull_WithoutName_Fail()
        {
            var arg = Guid.NewGuid();

            Assert.Throws<ArgumentException>(() =>
            {
                Ensure.ArgIsNull(arg);
            });
        }
    }
}
