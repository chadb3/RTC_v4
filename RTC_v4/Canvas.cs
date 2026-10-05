using System;
using System.Collections.Generic;
using System.Text;

namespace RTC_v4
{
    public class Canvas
    {
        public int height, width;
        public RTTuple[,] CanvasImage;

        public readonly string ppmHeader;

        /// <summary>
        /// Initializes a new Canvas
        /// </summary>
        /// <param name="height">Int: Height</param>
        /// <param name="width">Int: Width</param>
        public Canvas(int width, int height)
        {
            this.height= height;
            this.width= width;
            CanvasImage = new RTTuple[height, width];
            ppmHeader = $"P3\n{width} {height}\n255\n";
        }

        public void WritePixle(RTTuple colorIn,int x, int y)
        {
            CanvasImage[y,x] = colorIn;
        }

        public RTTuple PixelAt(int x, int y)
        {
            return CanvasImage[y,x];
        }

        public void CanvasToPPM()
        {
            // WIP
            // Will Write to the file
        }
        // Previously I streamed PPM values straight to the file in my old project.
        // This rewrite follows The Ray Tracer Challenge specification more closely,
        // making the output fully testable with unit tests.
        // AI helped me reorganize the output logic.
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public string StringCanvasToPPM()
        {
            var retString = new StringBuilder(width * height * 12);
            retString.Append(ppmHeader);
            for(int y = 0; y < height;y++)
            {
                int ll = 0;
                for (int x = 0; x < width; x++)
                {
                    RTTuple color = PixelAt(x,y);
                    int r = ClampColor(color.R);
                    int g = ClampColor(color.G);
                    int b = ClampColor(color.B);
                    string colorString=$"{r} {g} {b}";
                    if((ll+colorString.Length+1)+1>70)
                    {
                        // ai suggestion when debugging 
                        retString.Length--;
                        retString.AppendLine();
                        ll = 0;
                    }
                    retString.Append(colorString).Append(" ");
                    ll += colorString.Length + 1;
                }
                // ai suggestion when debugging 
                retString.Length--;
                retString.AppendLine();
            }
            return retString.ToString();
        }


        /// <summary>
        /// Private
        /// Clamps colors to 0-255
        /// </summary>
        /// <param name="colorIn"></param>
        /// <returns>Returns the Rounded Color</returns>
        public static int ClampColor(double colorIn)
        {
            // in my review, the below was found to be not optimal by ai, and I can confirm I was getting the
            // Wrong value (127) in the first canvas test rather then the correct 128
            // I just never ran unit tests until now, and only eyeballed values.
            // Former function
            //return Math.Max(Math.Min((int)(colorIn * 255), 255), 0);

            // scale fraction value to 0-255
            double scaledColor = colorIn * 255;
            // round it, and using "AwayFromZero" to round up to 1
            double rounded = Math.Round(scaledColor, MidpointRounding.AwayFromZero);
            // clamp between 0 and 255 then I can cast to int
            // using clamp function rather then using nested min and max i used before
            int RoundedColor = (int)Math.Clamp(rounded, 0, 255);
            return RoundedColor;
        }

    }
}
