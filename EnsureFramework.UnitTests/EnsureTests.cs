using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.UnitTests
{
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
    }
}
