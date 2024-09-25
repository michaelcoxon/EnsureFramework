using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.UnitTests
{
    public class FxCopTests
    {
        public void Method(object obj, string str)
        {
            Ensure.Arg(obj, nameof(obj));
            Ensure.Arg(str, nameof(str)).IsNotEmpty();
            var strobj = obj.ToString();
            var strstr = str.ToString();
        }

        [Fact]
        public void Test()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.Method(null, null);
            });
        }
    }
}
