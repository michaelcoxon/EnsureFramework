using Microsoft.VisualStudio.TestTools.UnitTesting;
using EnsureFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsureFramework.Tests
{
    [TestClass()]
    public class CompareAssertionsTests
    {
        [TestMethod()]
        public void IsGreaterThanOrEqualToTest()
        {
            Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(2);
            Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(3);
        }

        [TestMethod()]
        public void IsLessThanOrEqualToTest()
        {
            Ensure.Arg(3, "value").IsLessThanOrEqualTo(4);
            Ensure.Arg(3, "value").IsLessThanOrEqualTo(3);
        }

        [TestMethod()]
        public void IsLessThanTest()
        {
            Ensure.Arg(3, "value").IsLessThan(4);
        }

        [TestMethod()]
        public void IsGreaterThanTest()
        {
            Ensure.Arg(3, "value").IsGreaterThan(2);
        }

        [TestMethod()]
        public void IsEqualToTest()
        {
            Ensure.Arg(3, "value").IsEqualTo(3);
        }
    }
}