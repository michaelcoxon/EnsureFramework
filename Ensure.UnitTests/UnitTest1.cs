using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnsureFramework.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnsureNotNull_Local_Test()
        {
            string str = null;
            try
            {
                Ensure.That(() => str).IsNotNull();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(nameof(str), ex.ParamName);
            }
        }

        [TestMethod]
        public void EnsureNotNull_Argument_Test()
        {
            Action<string> method = (string str) =>
            {
                Ensure.That(() => str).IsNotNull();
            };

            try
            {
                method(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("str", ex.ParamName);
            }

            method("");
        }

        [TestMethod]
        public void EnsureNotNullOrNotEmpty_Local_Test()
        {
            string str = null;
            try
            {
                Ensure.That(() => str).IsNotNullOrEmpty();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual(nameof(str), ex.ParamName);
            }

            string str2 = string.Empty;
            try
            {
                Ensure.That(() => str2).IsNotNullOrEmpty();
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual(nameof(str2), ex.ParamName);
            }

            str2 = "hello";
            Ensure.That(() => str2).IsNotNullOrEmpty();
        }


        [TestMethod]
        public void EnsureEmailAddress_Argument_Test()
        {
            Action<string> method = (string str) =>
            {
                Ensure.That(() => str).IsEmailAddress();
            };

            try
            {
                method(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("str", ex.ParamName);
            }

            try
            {
                method("pants");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("str", ex.ParamName);
            }

            method("pants@domain.com");
        }

        public void MyMethod(string argument)
        {
            Ensure.That(() => argument).IsNotNull();
        }
    }
}
