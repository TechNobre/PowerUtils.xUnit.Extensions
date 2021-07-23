using PowerUtils.xUnit.Extensions.OrderTests;
using Xunit;

namespace PowerUtils.xUnit.Extensions.Tests
{
    [TestCaseOrderer("PowerUtils.xUnit.Extensions.OrderTests.PriorityOrderer", "PowerUtils.xUnit.Extensions")]
    public class OrderedTests
    {
        private static bool _test1Called;
        private static bool _test2Called;
        private static bool _test3Called;
        private static bool _test4Called;
        private static bool _test5Called;


        [Fact(DisplayName = "Test case 4 - Priority 3")]
        [TestPriority(3)]
        [Trait("Category", "Test ordering")]
        public void Test4()
        {
            _test4Called = true;

            Assert.True(_test1Called);
            Assert.False(_test2Called);
            Assert.False(_test3Called);
            Assert.True(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact(DisplayName = "Test case 3 - Priority 5")]
        [TestPriority(5)]
        [Trait("Category", "Test ordering")]
        public void Test3()
        {
            _test3Called = true;

            Assert.True(_test1Called);
            Assert.True(_test2Called);
            Assert.True(_test3Called);
            Assert.True(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact(DisplayName = "Test case 1 - Priority 2")]
        [TestPriority(2)]
        [Trait("Category", "Test ordering")]
        public void Test1()
        {
            _test1Called = true;

            Assert.True(_test1Called);
            Assert.False(_test2Called);
            Assert.False(_test3Called);
            Assert.False(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact(DisplayName = "Test case 5 - Priority 1")]
        [TestPriority(1)]
        [Trait("Category", "Test ordering")]
        public void Test5()
        {
            _test5Called = true;

            Assert.False(_test1Called);
            Assert.False(_test2Called);
            Assert.False(_test3Called);
            Assert.False(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact(DisplayName = "Test case 2 - Priority 4")]
        [TestPriority(4)]
        [Trait("Category", "Test ordering")]
        public void Test2()
        {
            _test2Called = true;

            Assert.True(_test1Called);
            Assert.True(_test2Called);
            Assert.False(_test3Called);
            Assert.True(_test4Called);
            Assert.True(_test5Called);
        }
    }
}