using System.Drawing;
using System.IO.Pipelines;
using RTC_v4;

namespace Ray_Tracer_Tests
{
    public class UnitTest_RTTuple
    {
        [Fact]
        public void Test_1_point()
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
        public void Test_1_2_point2()
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
        public void Test_2_vector()
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
        public void Test_3_point_test()
        {
            RTTuple p = RTTuple.point(4, -4, 3);
            var tuple = new RTTuple(4, -4, 3, 1);
            Assert.Equal(tuple, p);
            Assert.True(p.IsPoint);
            Assert.False(p.IsVector);
        }

        [Fact]
        public void Test_4_vector_test()
        {
            RTTuple v = RTTuple.vector(4, -4, 3);
            var tuple = new RTTuple(4, -4, 3, 0);
            Assert.Equal(tuple, v);
            Assert.True(v.IsVector);
            Assert.False(v.IsPoint);
        }

        [Fact]
        public void Test_5_vector_equality()
        {
            RTTuple v = RTTuple.vector(4, -4, 3);
            var tuple = new RTTuple(4, -4, 3, 0);
            Assert.True(v.Equals(tuple));
        }
        [Fact]
        public void Test_6_hash()
        {
            object t1 = new RTTuple(4, -4, 3, 0);
            object t2 = new RTTuple(0, 3, -4, 4);
            Assert.False(t1.GetHashCode() == t2.GetHashCode());
        }

        [Fact]
        public void Test_8_add()
        {
            object a1 = new RTTuple(3, -2, 5, 1);
            object a2 = new RTTuple(-2, 3, 1, 0);
            RTTuple ans = new RTTuple(1, 1, 6, 1);
            Assert.Equal(ans, (RTTuple)a1 + (RTTuple)a2);
        }

        [Fact]
        public void Test_9_subtract_points()
        {
            RTTuple p1 =  RTTuple.point(3, 2, 1);
            RTTuple p2 =  RTTuple.point(5, 6, 7);
            RTTuple ans = RTTuple.vector(-2, -4, -6);
            Assert.Equal(ans, p1 - p2);
        }
        [Fact]
        public void Test_10_Subtract_vector_from_point()
        {
            RTTuple p = RTTuple.point(3, 2, 1);
            RTTuple v = RTTuple.vector(5, 6, 7);
            RTTuple ans = RTTuple.point(-2, -4, -6);
            Assert.Equal(ans, p - v);
        }
        [Fact]
        public void Test_11_Subtract_2_vectors()
        {
            RTTuple v1 = RTTuple.vector(3, 2, 1);
            RTTuple v2 = RTTuple.vector(5, 6, 7);
            RTTuple ans = RTTuple.vector(-2,-4, -6);
        }
        [Fact]
        public void Test_12_zero_minus_a_vector()
        {
            RTTuple zero_vec = RTTuple.vector(0, 0, 0);
            RTTuple v = RTTuple.vector(-1, 2, -3);
            RTTuple ans = RTTuple.vector(1, -2, 3);
            Assert.Equal(zero_vec-v,ans);
        }

        [Fact]
        public void Test_13_negate_tuple()
        {
            RTTuple a = new RTTuple(1, -2, 3, -4);
            RTTuple na = new RTTuple(-1, 2, -3, 4);
            Assert.Equal(na,-a);
        }

        [Fact]
        public void Test_14_mult_a_tuple_by_a_scalar()
        {
            RTTuple a = new RTTuple(1, -2, 3, -4);
            RTTuple ans = new RTTuple(3.5, -7, 10.5, -14);
            Assert.Equal(ans, a * 3.5);
        }

        [Fact]
        public void Test_15_mult_a_tuple_by_a_fraction()
        {
            RTTuple a = new RTTuple(1, -2, 3, -4);
            RTTuple ans = new RTTuple(0.5, -1, 1.5, -2);
            Assert.Equal(ans, a * 0.5);
        }

        [Fact]
        public void Test_16_divide_a_tuple_by_a_sclar()
        {
            RTTuple a = new RTTuple(1, -2, 3, -4);
            RTTuple ans = new RTTuple(0.5, -1, 1.5, -2);
            Assert.Equal(ans, a / 2);
        }
    }
}