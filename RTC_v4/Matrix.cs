using System;
using System.Collections.Generic;
using System.Text;

namespace RTC_v4
{
    public class Matrix
    {
        public int height {get;}
        public int width {get;}
        public double[,] matrix {get;}
        public Matrix(int height, int width)
        {
            this.height = height;
            this.width= width;
            matrix = new double[height, width];
        }
    }
}
