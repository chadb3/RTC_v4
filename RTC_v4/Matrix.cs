using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace RTC_v4
{
    public class Matrix
    {
        public int height { get; }
        public int width { get; }
        public double[,] matrix { get; }
        public Matrix(int height, int width)
        {
            this.height = height;
            this.width = width;
            matrix = new double[height, width];
        }
        public Matrix(double[,] matrixIn)
        {
            matrix=matrixIn;
            this.height=matrixIn.GetLength(0);
            this.width=matrixIn.GetLength(1);
        }

        /// <summary>
        /// This should make my class addressable like a 2d array
        /// </summary>
        /// <param name="heightIn"></param>
        /// <param name="widthIn"></param>
        /// <returns></returns>
        public double this[int heightIn,int widthIn]
        {
            get => matrix[heightIn,widthIn];
            set => matrix[heightIn, widthIn] = value;
        }

        public static Matrix operator *(Matrix lMatrix, Matrix rMatrix)
        {
            // ret matrix needs to be the same as the r matrix if their dimensions match (l.columns==r.rows)
            Matrix RetMatrix=new Matrix(lMatrix.height,lMatrix.width);
            if (lMatrix.height  == rMatrix.width && rMatrix.width==4)
            {
                for (int row = 0; row < lMatrix.height; row++)
                {
                    for (int col = 0; col < lMatrix.width; col++)
                    {
                        RetMatrix[row,col]=lMatrix[row,0]*rMatrix[0,col]+lMatrix[row,1]*rMatrix[1,col]+lMatrix[row,2]*rMatrix[2,col]+lMatrix[row,3]*rMatrix[3,col];
                    }
                }
            }
            
            return RetMatrix;
        }

        /// <summary>
        /// Returns a new 4x4 Identity Matrix
        /// </summary>
        /// <returns>Returns a new 4x4 Identity Matrix: A Matrix with ones across the diagnal starting from top left.</returns>
        public static Matrix Identity()
        {
            return new Matrix(new double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } });
        }

        private static bool _TestMatrixHeightWidth(Matrix lMatrix, Matrix rMatrix)
        {
            if (lMatrix.height == rMatrix.height && lMatrix.width == rMatrix.width)
            {
                return true;
            }
                return false;
        }

        /// <summary>
        /// * summary was ai generated *
        /// * asked ai for advise as "if (!(Math.Abs(lMatrix[i, j] - rMatrix[i, j]) <= 0.00001))" was ugly *
        /// Determines whether two matrices have the same dimensions and element-wise values within an absolute
        /// tolerance of 1e-5.
        /// </summary>
        /// <remarks>Comparison uses an absolute tolerance of 1e-5 for element equality;</remarks>
        /// <param name="lMatrix">Left-hand matrix to compare.</param>
        /// <param name="rMatrix">Right-hand matrix to compare.</param>
        /// <returns>true if matrices have identical dimensions and all corresponding elements differ by at most 1e-5; otherwise
        /// false.</returns>
        public static bool operator ==(Matrix lMatrix, Matrix rMatrix)
        {
            if(_TestMatrixHeightWidth(lMatrix,rMatrix))
            {
                for (int i = 0; i < lMatrix.height; i++)
                {
                    for (int j = 0; j < rMatrix.width; j++)
                    {
                        if (Math.Abs(lMatrix[i, j] - rMatrix[i, j]) > 0.00001)
                        {
                            //lMatrix[i,j]!=rMatrix[i,j]
                            //Math.abs(lMatrix[i,j]-rMatrix[i,j])<=0.00001
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        public static bool operator !=(Matrix lMatrix, Matrix rMatrix)
        {

            return !(lMatrix == rMatrix);
        }
        public override bool Equals(object? obj)
        {
            if(obj is Matrix other)
            {
                return this == other;
            }
            return false;
        }

        /// <summary>
        /// * Implimented to silence warnings *
        /// * AI generated documentation *
        /// * Asked AI for assistence *
        /// Returns a hash code for the current instance using the base class implementation.
        /// </summary>
        /// <remarks>Relies on the base class implementation. Equal objects must return the same hash
        /// code; the value is not guaranteed to remain the same across process executions.</remarks>
        /// <returns>A 32-bit signed integer hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(matrix.GetLength(0), matrix.GetLength(1));
            //return base.GetHashCode();
        }
    }
}
