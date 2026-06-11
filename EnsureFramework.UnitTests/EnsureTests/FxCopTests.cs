using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnsureFramework;

using Xunit;

namespace EnsureFramework.UnitTests.EnsureTests
{
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
