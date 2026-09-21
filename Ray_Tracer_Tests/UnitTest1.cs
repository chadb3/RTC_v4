using System.IO.Pipelines;
using RTC_v4;

namespace Ray_Tracer_Tests
{
    public class UnitTest_RTTuple
    {
        [Fact]
        public void Test1()
        {
            var a = new RTTuple(4.3, -4.2, 3.1, 1.0);
            Assert.Equal(4.3, a.x);
            Assert.Equal(-4.2, a.y);
            Assert.Equal(3.1, a.z);
            Assert.Equal(1.0, a.w);
        }

        [Fact]
        public void Test1_2()
        {
            var a = new RTTuple(8.3, 4.2, 3, 1.0);
            Assert.Equal(8.3, a.x);
            Assert.Equal(4.2, a.y);
            Assert.Equal(3, a.z);
            Assert.Equal(1.0, a.w);
        }
    }
}
