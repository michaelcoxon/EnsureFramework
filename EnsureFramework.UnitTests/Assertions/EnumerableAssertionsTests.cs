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
    public class EnumerableAssertionsTests
    {
        [TestMethod()]
        public void IsNotNullOrEmptyTest()
        {
            Ensure.Arg(new int[] { 1, 2, 3 }, "value").IsNotNullOrEmpty();
        }

        [TestMethod()]
        public void IsNotNullOrEmpty_Empty_Test()
        {
            try
            {
                Ensure.Arg(new int[] { }, "value").IsNotNullOrEmpty();
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod()]
        public void IsNotNullOrEmpty_Null_Test()
        {
            try
            {
                Ensure.Arg<int[]>(null, "value").IsNotNullOrEmpty();
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}