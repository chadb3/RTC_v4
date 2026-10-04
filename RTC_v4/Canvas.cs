using System;
using System.Collections.Generic;
using System.Text;

namespace RTC_v4
{
    public class Canvas
    {
        public int height, width;
        public RTTuple[,] CanvasImage;

        /// <summary>
        /// Initializes a new Canvas
        /// </summary>
        /// <param name="height">Int: Height</param>
        /// <param name="width">Int: Width</param>
        public Canvas(int height, int width)
        {
            this.height= height;
            this.width= width;
            CanvasImage = new RTTuple[height, width];
        }

        public void WritePixle(RTTuple colorIn,int x,int y)
        {
            CanvasImage[x,y] = colorIn;
        }

        public RTTuple PixelAt(int x, int y)
        {
            return CanvasImage[x,y];
        }

    }
}
