using EnsureFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.Tests
{
    public class EnumerableAssertionsTests
    {
        [Fact]
        public void IsNotNullOrEmptyTest()
        {
            Ensure.Arg(new int[] { 1, 2, 3 }, "value").IsNotNullOrEmpty();
        }

        [Fact]
        public void IsNotNullOrEmpty_Empty_Test()
        {
            Assert.Throws<ArgumentException>(() => Ensure.Arg(new int[] { }, "value").IsNotNullOrEmpty());
        }

        [Fact]
        public void IsNotNullOrEmpty_Null_Test()
        {
            Assert.Throws<ArgumentNullException>(() => Ensure.Arg<int[]>(null, "value").IsNotNullOrEmpty());
        }

        [Fact]
        public void IsNotNullOrEmpty_Nested_Test()
        {
            var subject = new Dictionary<int, int[]>
            {
                [1] = new[] { 1 }
            };

            Ensure.Arg(subject, "value")
                .WithKey(1)
                    .IsNotNullOrEmpty()
                    .Pop()
                .HasKey(1)
                ;
        }

        [Fact]
        public void Contains_Nested_Test()
        {
            var subject = new Dictionary<int, int[]>
            {
                [1] = new[] { 1 }
            };

            Ensure.Arg(subject, "value")
                .WithKey(1)
                    .Contains(1)
                    .Pop()
                .HasKey(1)
                ;
        }
    }
}