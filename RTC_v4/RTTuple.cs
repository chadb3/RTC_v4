using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace RTC_v4
{
    /// <summary>
    /// Custom tuple struct for vectors, points, and colors in 3D space.
    /// </summary>
    public readonly struct RTTuple
    {
        public double x {get;}
        public double y {get;}
        public double z {get;}
        public double w {get;}


        public  RTTuple(double x, double y, double z, double w)
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

        public readonly double magnitude()
        {
            // Math.pow(2,9) == 2^9 == 512
            // Math.pow(9,2) == 9^2 == 81
            return Math.Sqrt(Math.Pow(x,2) + Math.Pow(y,2)+ Math.Pow(z,2)+ Math.Pow(w,2));
        }

        public static RTTuple operator +(RTTuple a, RTTuple b)
        {
            return new RTTuple(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        }

        public static RTTuple operator -(RTTuple a, RTTuple b)
        {
            return new RTTuple(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        }

        public static RTTuple operator-(RTTuple a)
        {
            return new RTTuple(-a.x, -a.y, -a.z, -a.w);
        }

        /*public static RTTuple operator *(RTTuple a, RTTuple b)
        {
            return new RTTuple(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        }*/

        /// <summary>
        /// Scalar multiplication
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns> a new RTTuple</returns>
        public static RTTuple operator *(RTTuple a, double x)
        {
            return new RTTuple(a.x*x, a.y*x, a.z*x, a.w*x);
        }
        /// <summary>
        /// Scalar division
        /// </summary>
        /// <param name="a"></param>
        /// <param name="x"></param>
        /// <returns>a new RTTuple</returns>

        public static RTTuple operator /(RTTuple a, double x)
        {
            return new RTTuple(a.x/x, a.y/x, a.z/x, a.w/x);
        }

        public static bool operator ==(RTTuple a, RTTuple b)
        {
            return Math.Abs(a.x - b.x) < 0.00001 &&
                   Math.Abs(a.y - b.y) < 0.00001 &&
                   Math.Abs(a.z - b.z) < 0.00001 &&
                   Math.Abs(a.w - b.w) < 0.00001;
        }

        public static bool operator !=(RTTuple a, RTTuple b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Checks if two RTTuple instances are equal based on their components.
        /// Notes: AI help (9/21/2026): helped with adding readonly and adding the question mark to clear green squggle lines. I think I would have tried readonly as it was in the highlight message, but the question mark was new to me.
        /// The ? on object? means the parameter is allowed to be null, matching the base Equals(object?) contract so the override doesn’t illegally narrow its nullability. Even though a struct itself can never be null, the Equals method must still accept a nullable object because callers are allowed to pass null into the base API.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public readonly override bool Equals(object? obj)
        {
            if (obj is RTTuple other)
            {
                return this == other;
            }
            return false;
        }
        /// <summary>
        /// Generates a hash code for the RTTuple instance based on its components.
        /// Tab generated
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y, z, w);
        }

        // Code based off AI Answer (9/21/2026)
        // I know both checks are largely not used after unit tests in chapter 1. 
        // checks if a tuple is a point
        public bool IsPoint=>Math.Abs(w - 1.0) < 0.00001;
        // checks if a tuple is a vector
        public bool IsVector => Math.Abs(w) < 0.00001;
    }
}
