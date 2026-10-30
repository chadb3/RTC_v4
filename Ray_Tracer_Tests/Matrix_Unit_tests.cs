using RTC_v4;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Sdk;

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

        [Fact]
        public void Test_1_Constructing_and_Inspeting_a_4x4_Matrix()
        {
            double[,] mat = new double[,] { { 1, 2, 3, 4 }, { 5.5,6.5,7.5,8.5},{9,10,11,12},{13.5,14.5,15.5,16.5} };
            Matrix M = new Matrix(mat);
            Assert.Equal(1, M[0, 0]);
            Assert.Equal(4, M[0, 3]);
            Assert.Equal(5.5, M[1, 0]);
            Assert.Equal(7.5, M[1, 2]);
            Assert.Equal(11, M[2, 2]);
            Assert.Equal(13.5, M[3, 0]);
            Assert.Equal(15.5, M[3, 2]);
        }

        [Fact]
        public void Test_2_a_2x2_matrix_aught_to_be_representable()
        {
            double[,] mat = new double[,] { { -3, 5 }, { 1, -2 } };
            Matrix M = new Matrix(mat);
            Assert.Equal(-3, M[0, 0]);
            Assert.Equal(5, M[0,1]);
            Assert.Equal(1,M[1,0]);
            Assert.Equal(-2, M[1, 1]);
        }

        [Fact]
        public void Test_3_a_3x3_matrix_ought_to_e_representable()
        {
            double[,] mat = new double[,] { { -3, 5, 0 }, { 1, -2, -7 }, { 0, 1, 1 } };
            Matrix M = new Matrix(mat);
            Assert.Equal(-3,M[0, 0]);
            Assert.Equal(-2, M[1, 1]);
            Assert.Equal(1, M[2, 2]);
            Assert.Equal(5, M[0, 1]);
        }

        [Fact]
        public void Test_4_Matrix_equality_with_identical_matrices()
        {
            double[,] mat1 = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };
            double[,] mat2 = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };
            Matrix A = new Matrix(mat1);
            Matrix B= new Matrix(mat2);
            Assert.Equal(A,B);
        }

        [Fact]
        public void Test_5_Matrix_equality_with_different_matrices()
        {
            double[,] mat1 = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };
            double[,] mat2 = new double[,] { { 2, 3, 4, 5 }, { 6, 7, 8, 9 }, { 8, 7, 6, 5 }, { 4, 3, 2, 1 } };
            Matrix M1= new Matrix(mat1);
            Matrix M2= new Matrix(mat2);
            Assert.NotEqual(M1, M2);
        }

        [Fact]
        public void Test_6_AxB_is_the_following_4x4_matrix()
        {
            double[,] mat1 = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 8, 7, 6 }, { 5, 4, 3, 2 } };
            double[,] mat2 = new double[,] { { -2, 1, 2, 3 }, { 3, 2, 1, -1 }, { 4, 3, 6, 5 }, { 1, 2, 7, 8 } };
            double[,] answer = new double[,] { { 20, 22, 50, 48 }, { 44, 54, 114, 108 }, { 40, 58, 110, 102 }, { 16, 26, 46, 42 } };
            Matrix M1 = new Matrix(mat1);
            Matrix M2 = new Matrix(mat2);
            Matrix Answer = new Matrix(answer);
            // Temp Not Equal to test helper function
            Assert.Equal(Answer, M1 * M2);
        }

        [Fact]
        public void Test_7_Multiplying_a_matrix_by_the_identity_matrix()
        {
            Matrix identiy_matrix = Matrix.Identity();
            Matrix A = new Matrix(new double[,] { { 0, 1, 2, 4 }, { 1, 2, 4, 8 }, { 2, 4, 8, 16 }, { 4, 8, 16, 32 } });
            Assert.Equal(A, A * identiy_matrix);
        }

        [Fact]
        public void test_8_transposing_a_matrix()
        {
            Matrix A = new Matrix(new double[,] { { 0, 9, 3, 0 }, { 9, 8, 0, 8 }, { 1, 8, 5, 3 }, { 0, 0, 5, 8 } });
            Matrix result = new Matrix(new double[,] { { 0, 9, 1, 0 }, { 9, 8, 8, 0 }, { 3, 0, 5, 5 }, { 0, 8, 3, 8 } });
            Assert.Equal(result, Matrix.Transpose(A));
        }
    }
}
