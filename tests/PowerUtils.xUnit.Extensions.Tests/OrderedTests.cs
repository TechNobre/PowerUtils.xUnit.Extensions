using PowerUtils.xUnit.Extensions.OrderTests;
using Xunit;

namespace PowerUtils.xUnit.Extensions.Tests
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class OrderedTests
    {
        private static bool _test1Called;
        private static bool _test2Called;
        private static bool _test3Called;
        private static bool _test4Called;
        private static bool _test5Called;


        [Fact]
        [TestPriority(3)]
        public void Priority3_Call_ThirdCalled()
        {
            _test4Called = true;

            Assert.True(_test1Called);
            Assert.False(_test2Called);
            Assert.False(_test3Called);
            Assert.True(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact]
        [TestPriority(5)]
        public void Priority5_Call_FifthCalled()
        {
            _test3Called = true;

            Assert.True(_test1Called);
            Assert.True(_test2Called);
            Assert.True(_test3Called);
            Assert.True(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact]
        [TestPriority(2)]
        public void Priority2_Call_SecondCalled()
        {
            _test1Called = true;

            Assert.True(_test1Called);
            Assert.False(_test2Called);
            Assert.False(_test3Called);
            Assert.False(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact]
        [TestPriority(1)]
        public void Priority1_Call_FirstCalled()
        {
            _test5Called = true;

            Assert.False(_test1Called);
            Assert.False(_test2Called);
            Assert.False(_test3Called);
            Assert.False(_test4Called);
            Assert.True(_test5Called);
        }

        [Fact]
        [TestPriority(4)]
        public void Priority4_Call_FourthCalled()
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
