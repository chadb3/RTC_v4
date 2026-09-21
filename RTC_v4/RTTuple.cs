using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RTC_v4
{
    /// <summary>
    /// Custom tuple struct for vectors, points, and colors in 3D space.
    /// </summary>
    public struct RTTuple
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double w { get; set; }

        public RTTuple(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public static RTTuple point(double x, double y, double z)
        {
            return new RTTuple(x, y, z, 1);
        }

        public static RTTuple vector(double x, double y, double z)
        {
            return new RTTuple(x, y, z, 0);
        }

        public static RTTuple color(double r, double g, double b)
        {
            return new RTTuple(r, g, b, 0);
        }

        // Code based off AI Answer
        // I know this code is largley not used after unit tests in chapter 1.
        public bool IsPoint=>Math.Abs(w - 1.0) < 0.00001;
        public bool IsVector => Math.Abs(w-0.0) < 0.00001;
    }
}
