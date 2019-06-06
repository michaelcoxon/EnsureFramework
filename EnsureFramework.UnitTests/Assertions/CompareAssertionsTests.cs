using EnsureFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EnsureFramework.UnitTests
{
    public class CompareAssertionsTests
    {
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsGreaterThanOrEqualToTest(bool expressionTest)
        {
            if (expressionTest)
            {
                void test(int value)
                {
                    Ensure.Arg(() => value).IsGreaterThanOrEqualTo(2);
                    Ensure.Arg(() => value).IsGreaterThanOrEqualTo(3);
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsGreaterThanOrEqualTo(4);
                    });
                }

                test(3);
            }
            else
            {
                Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(2);
                Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(3);
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsGreaterThanOrEqualTo(4);
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsGreaterThanOrEqualTo_Nested_Test(bool expressionTest)
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            if (expressionTest)
            {
                void test(Dictionary<int, int> value)
                {
                    Ensure.Arg(() => value).WithKey(3).IsGreaterThanOrEqualTo(2).Pop();
                    Ensure.Arg(() => value).WithKey(3).IsGreaterThanOrEqualTo(3).Pop();
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsGreaterThanOrEqualTo(4).Pop();
                    });
                }

                test(subject);
            }
            else
            {
                Ensure.Arg(subject, "value").WithKey(3).IsGreaterThanOrEqualTo(2).Pop();
                Ensure.Arg(subject, "value").WithKey(3).IsGreaterThanOrEqualTo(3).Pop();
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsGreaterThanOrEqualTo(4).Pop();
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsLessThanOrEqualToTest(bool expressionTest)
        {
            if (expressionTest)
            {
                void test(int value)
                {
                    Ensure.Arg(() => value).IsLessThanOrEqualTo(4);
                    Ensure.Arg(() => value).IsLessThanOrEqualTo(3);
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsLessThanOrEqualTo(2);
                    });
                }

                test(3);
            }
            else
            {
                Ensure.Arg(3, "value").IsLessThanOrEqualTo(4);
                Ensure.Arg(3, "value").IsLessThanOrEqualTo(3);
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsLessThanOrEqualTo(2);
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsLessThanOrEqualTo_Nested_Test(bool expressionTest)
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            if (expressionTest)
            {
                void test(Dictionary<int, int> value)
                {
                    Ensure.Arg(() => value).WithKey(3).IsLessThanOrEqualTo(4).Pop();
                    Ensure.Arg(() => value).WithKey(3).IsLessThanOrEqualTo(3).Pop();
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsLessThanOrEqualTo(2).Pop();
                    });
                }

                test(subject);
            }
            else
            {
                Ensure.Arg(subject, "value").WithKey(3).IsLessThanOrEqualTo(4).Pop();
                Ensure.Arg(subject, "value").WithKey(3).IsLessThanOrEqualTo(3).Pop();
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsLessThanOrEqualTo(2).Pop();
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsLessThanTest(bool expressionTest)
        {
            if (expressionTest)
            {
                void test(int value)
                {
                    Ensure.Arg(() => value).IsLessThan(4);
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsLessThan(3);
                    });
                }

                test(3);
            }
            else
            {
                Ensure.Arg(3, "value").IsLessThan(4);
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsLessThan(3);
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsLessThan_Nested_Test(bool expressionTest)
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            if (expressionTest)
            {
                void test(Dictionary<int, int> value)
                {
                    Ensure.Arg(() => value).WithKey(3).IsLessThan(4).Pop();
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsLessThan(3).Pop();
                    });
                }

                test(subject);
            }
            else
            {
                Ensure.Arg(subject, "value").WithKey(3).IsLessThan(4).Pop();
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsLessThan(3).Pop();
                });
            }
        }


        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsGreaterThanTest(bool expressionTest)
        {
            if (expressionTest)
            {
                void test(int value)
                {
                    Ensure.Arg(() => value).IsGreaterThan(2);
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsGreaterThan(3);
                    });
                }

                test(3);
            }
            else
            {
                Ensure.Arg(3, "value").IsGreaterThan(2);
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsGreaterThan(3);
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsGreaterThan_Nested_Test(bool expressionTest)
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            if (expressionTest)
            {
                void test(Dictionary<int, int> value)
                {
                    Ensure.Arg(() => value).WithKey(3).IsGreaterThan(2).Pop();
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsGreaterThan(3).Pop();
                    });
                }

                test(subject);
            }
            else
            {
                Ensure.Arg(subject, "value").WithKey(3).IsGreaterThan(2).Pop();
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsGreaterThan(3).Pop();
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsEqualToTest(bool expressionTest)
        {
            if (expressionTest)
            {
                void test(int value)
                {
                    Ensure.Arg(() => value).IsEqualTo(3);
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsEqualTo(2);
                    });
                }

                test(3);
            }
            else
            {
                Ensure.Arg(3, "value").IsEqualTo(3);
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsEqualTo(2);
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsEqualTo_Nested_Test(bool expressionTest)
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            if (expressionTest)
            {
                void test(Dictionary<int, int> value)
                {
                    Ensure.Arg(() => value).WithKey(3).IsEqualTo(3).Pop();
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsEqualTo(2).Pop();
                    });
                }

                test(subject);
            }
            else
            {
                Ensure.Arg(subject, "value").WithKey(3).IsEqualTo(3).Pop();
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsEqualTo(2).Pop();
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsWithinRangeTest(bool expressionTest)
        {
            if (expressionTest)
            {
                void test(int value)
                {
                    Ensure.Arg(() => value).IsWithinRange(2, 4);
                    Ensure.Arg(() => value).IsWithinRange(-3, 100);
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsWithinRange(4, 4);
                    });

                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsWithinRange(3, 4);
                    });

                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsWithinRange(2, 3);
                    });
                }

                test(3);
            }
            else
            {
                Ensure.Arg(3, "value").IsWithinRange(2, 4);
                Ensure.Arg(3, "value").IsWithinRange(-3, 100);
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsWithinRange(4, 4);
                });

                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsWithinRange(3, 4);
                });

                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsWithinRange(2, 3);
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsWithinRange_Nested_Test(bool expressionTest)
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };

            if (expressionTest)
            {
                void test(Dictionary<int, int> value)
                {
                    Ensure.Arg(() => value).WithKey(3).IsWithinRange(2, 4).Pop();
                    Ensure.Arg(() => value).WithKey(3).IsWithinRange(-3, 100).Pop();
                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsWithinRange(4, 4).Pop();
                    });

                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsWithinRange(3, 4).Pop();
                    });

                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsWithinRange(2, 3).Pop();
                    });
                }

                test(subject);
            }
            else
            {
                Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(2, 4).Pop();
                Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(-3, 100).Pop();
                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(4, 4).Pop();
                });

                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(3, 4).Pop();
                });

                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsWithinRange(2, 3).Pop();
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsWithinAndIncludingRangeTest(bool expressionTest)
        {
            if (expressionTest)
            {
                void test(int value)
                {
                    Ensure.Arg(() => value).IsWithinAndIncludingRange(2, 4);
                    Ensure.Arg(() => value).IsWithinAndIncludingRange(-3, 100);

                    Ensure.Arg(() => value).IsWithinAndIncludingRange(3, 4);
                    Ensure.Arg(() => value).IsWithinAndIncludingRange(2, 3);

                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).IsWithinAndIncludingRange(4, 4);
                    });
                }

                test(3);
            }
            else
            {
                Ensure.Arg(3, "value").IsWithinAndIncludingRange(2, 4);
                Ensure.Arg(3, "value").IsWithinAndIncludingRange(-3, 100);

                Ensure.Arg(3, "value").IsWithinAndIncludingRange(3, 4);
                Ensure.Arg(3, "value").IsWithinAndIncludingRange(2, 3);

                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(3, "value").IsWithinAndIncludingRange(4, 4);
                });
            }
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsWithinAndIncludingRange_Nested_Test(bool expressionTest)
        {
            var subject = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2,
                [3] = 3,
                [4] = 4,
            };
            if (expressionTest)
            {
                void test(Dictionary<int, int> value)
                {
                    Ensure.Arg(() => value).WithKey(3).IsWithinAndIncludingRange(2, 4).Pop();
                    Ensure.Arg(() => value).WithKey(3).IsWithinAndIncludingRange(-3, 100).Pop();

                    Ensure.Arg(() => value).WithKey(3).IsWithinAndIncludingRange(3, 4).Pop();
                    Ensure.Arg(() => value).WithKey(3).IsWithinAndIncludingRange(2, 3).Pop();

                    Assert.Throws<ArgumentException>(() =>
                    {
                        Ensure.Arg(() => value).WithKey(3).IsWithinAndIncludingRange(4, 4).Pop();
                    });
                }

                test(subject);
            }
            else
            {
                Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(2, 4).Pop();
                Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(-3, 100).Pop();

                Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(3, 4).Pop();
                Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(2, 3).Pop();

                Assert.Throws<ArgumentException>(() =>
                {
                    Ensure.Arg(subject, "value").WithKey(3).IsWithinAndIncludingRange(4, 4).Pop();
                });
            }
        }
    }
}