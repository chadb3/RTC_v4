using System.Drawing;
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
            Assert.True(a.IsPoint);
            Assert.False(a.IsVector);
        }

        [Fact]
        public void Test1_2()
        {
            var a = new RTTuple(8.3, 4.2, 3, 1.0);
            Assert.Equal(8.3, a.x);
            Assert.Equal(4.2, a.y);
            Assert.Equal(3, a.z);
            Assert.Equal(1.0, a.w);
            Assert.False(a.IsVector);
            Assert.True(a.IsPoint);
        }

        [Fact]
        public void Test2()
        {
            var a = new RTTuple(4.3, -4.2, 3.1, 0.0);
            Assert.Equal(4.3, a.x);
            Assert.Equal(-4.2, a.y);
            Assert.Equal(3.1, a.z);
            Assert.Equal(0.0, a.w);
            Assert.False(a.IsPoint);
            Assert.True(a.IsVector);
        }

        [Fact]
        public void Test3()
        {
            RTTuple p = RTTuple.point(4, -4, 3);
            var tuple = new RTTuple(4, -4, 3, 1);
            Assert.Equal(tuple, p);
            Assert.True(p.IsPoint);
            Assert.False(p.IsVector);
        }

        [Fact]
        public void Test4()
        {
            RTTuple v = RTTuple.vector(4, -4, 3);
            var tuple = new RTTuple(4, -4, 3, 0);
            Assert.Equal(tuple, v);
            Assert.True(v.IsVector);
            Assert.False(v.IsPoint);
        }

        [Fact]
        public void Test5()
        {
            RTTuple v = RTTuple.vector(4, -4, 3);
            var tuple = new RTTuple(4, -4, 3, 0);
            Assert.True(v.Equals(tuple));
        }
        [Fact]
        public void Test6()
        {
            object t1 = new RTTuple(4, -4, 3, 0);
            object t2 = new RTTuple(0, 3, -4, 4);
            Assert.False(t1.GetHashCode() == t2.GetHashCode());
        }
        //[Fact]
        /// Test to check mutability of RTTuple. in my research, it should be immutable. It is now commented out as now it is read only / immutable.
        /*public void Test7()

        {
            RTTuple T1 = new RTTuple(1, 2, 3, 0);
            T1.w = 1;
            Assert.True(T1.IsPoint);
        }*/
    }
}