using RTC_v4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ray_Tracer_Tests
{
    public class Color_and_Canvas_Unit_tests
    {
        [Fact]
        public void Test_1_colors_are_Tuples()
        {
            RTTuple c = RTTuple.color(0.5, 0.4, 1.7);
            double r = 0.5;
            double g = 0.4;
            double b = 1.7;
            Assert.Equal(r, c.x);
            Assert.Equal(g, c.y);
            Assert.Equal(b, c.z);
        }
        [Fact]
        public void Test_2_Colors_are_Tuples_with_RGB()
        {
            RTTuple c = RTTuple.color(0.5, 0.4, 1.7);
            double r = 0.5;
            double g = 0.4;
            double b = 1.7;
            Assert.Equal(r, c.R);
            Assert.Equal(g, c.G);
            Assert.Equal(b, c.B);
        }
    }
}
