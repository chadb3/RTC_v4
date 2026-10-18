using RTC_v4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ray_Tracer_Tests
{
    public class Matrix_Unit_tests
    {
        [Fact]
        public void test_00_test_matrix_unit_tests()
        {
            Assert.Equal(0, 0);
        }

        [Fact]
        public void test_01_test_matrix_unit_tests()
        {
            Matrix m = new Matrix(3, 2);
            //Console.WriteLine("Matrix Test");
            //Console.WriteLine(m.matrix[0, 0]);
            //Console.WriteLine(m.matrix[1, 0]);
            //Console.WriteLine(m.matrix[2, 0]);
            Assert.Equal(0,m.matrix[0, 0]);
            for(int i =0;i<m.height;i++)
            {
                for(int j=0;j<m.width;j++)
                {
                    Assert.Equal(0, m.matrix[i, j]);
                }
            }
        }
    }
}
