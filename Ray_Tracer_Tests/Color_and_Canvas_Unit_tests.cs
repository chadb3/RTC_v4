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
            double r = 0.5;
            double g = 0.4;
            double b = 1.7;
            RTTuple c = RTTuple.color(r, g, b);
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

        [Fact]
        public void Test_3_Adding_colors()
        {
            RTTuple c1 = RTTuple.color(0.9, 0.6, 0.75);
            RTTuple c2 = RTTuple.color(0.7, 0.1, 0.25);
            RTTuple c1plusc2 = RTTuple.color(1.6, 0.7, 1.0);
            Assert.Equal(c1plusc2, c1 + c2);
        }

        [Fact]
        public void Test_4_subtracting_colors()
        {
            RTTuple c1 = RTTuple.color(0.9, 0.6, 0.75);
            RTTuple c2 = RTTuple.color(0.7, 0.1, 0.25);
            RTTuple c1minusc2 = RTTuple.color(0.2, 0.5, 0.5);
            Assert.Equal(c1minusc2, c1 - c2);
        }

        [Fact]
        public void Test_5_multiplying_a_scalar()
        {
            RTTuple c = RTTuple.color(0.2, 0.3, 0.4);
            Assert.Equal(RTTuple.color(0.4, 0.6, 0.8), c * 2);
        }

        [Fact]
        public void Test_6_multiplying_colors()
        {
            RTTuple c1 = RTTuple.color(1, 0.2, 0.4);
            RTTuple c2 = RTTuple.color(0.9, 1, 0.1);
            RTTuple c1xc2 = RTTuple.color(0.9, 0.2, 0.04);
            Assert.Equal(c1xc2, c1 * c2);
        }

        [Fact]
        public void Test_7_Creating_a_Canvas()
        {
            Canvas c = new Canvas(10, 20);
            Assert.Equal(10, c.width);
            Assert.Equal(20, c.height);
            // Loop checking color
            // All colors should be 0,0,0
            for (int i = 0; i < c.height; i++)
            {
                for (int j = 0; j < c.width; j++)
                {
                    Assert.Equal(RTTuple.color(0,0,0),c.CanvasImage[i,j]);
                }
            }
        }

        [Fact]
        public void Test_8_Writing_Pixles_to_a_Canvas()
        {
            Canvas c = new Canvas(10, 20);
            RTTuple red = RTTuple.color(1, 0, 0);
            c.WritePixle(red, 2, 3);
            Assert.Equal(red, c.PixelAt(2, 3));
            Assert.Equal(RTTuple.color(0,0,0), c.PixelAt(3,2));
        }

        [Fact]
        public void Test_9_Construct_A_PPM_Header()
        {
            Canvas c= new Canvas(5, 3);
            var ppm = c.StringCanvasToPPM();
            Assert.Contains("P3", ppm);
            Assert.Contains("5 3", ppm);
            Assert.Contains("255", ppm);
        }

        /// <summary>
        /// This test isn't in the book but is helpful to check if your ClampColor is correct
        /// as my old one was off by one, but I didn't notice in the past because I didn't
        /// unit test this part of the chapter, and just eyeballed the image, and briefly scanning the text of the output file.
        /// </summary>
        [Fact]
        public void Test_9p5_Testing_color_clamping()
        {
            int c1 = Canvas.ClampColor(1.5);
            int c2= Canvas.ClampColor(0.5);
            int c3 = Canvas.ClampColor(1);
            Assert.Equal(255, c1);
            Assert.Equal(128, c2);
            Assert.Equal(255, c3);
        }

        [Fact]
        public void Test_10_constructing_the_PPM_pixel_data()
        {
            Canvas c = new Canvas(5,3);
            RTTuple c1 = RTTuple.color(1.5, 0, 0);
            RTTuple c2 = RTTuple.color(0, 0.5, 0);
            RTTuple c3 = RTTuple.color(-0.5, 0, 1);
            c.WritePixle(c1, 0, 0);
            c.WritePixle(c2, 2, 1);
            c.WritePixle(c3, 4, 2);
            var ppm = c.StringCanvasToPPM();
            // Asked AI to help me create this string based off my console output
            string expectedPixels =
                "255 0 0 0 0 0 0 0 0 0 0 0 0 0 0\n" +
                "0 0 0 0 0 0 0 128 0 0 0 0 0 0 0\n" +
                "0 0 0 0 0 0 0 0 0 0 0 0 0 0 255\n";
            var ppmNormalized = ppm.Replace("\r\n", "\n");
            Assert.Contains(expectedPixels, ppmNormalized);
            Assert.Contains(expectedPixels, ppm);
        }

        [Fact]
        public void Test_11_splitting_long_lines_in_PPM_files()
        {
            Canvas c = new Canvas(10, 2);
            RTTuple oneColor = RTTuple.color(1, 0.8, 0.6);
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    c.WritePixle(oneColor, x, y);
                }
            }
            // Asked AI to help me create this string based off my console output
            // I asked as I was looking for a way similar to python's """..."""
            string expectedPixels =
                                    "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153\n" +
                                    "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153\n" +
                                    "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153\n" +
                                    "255 204 153 255 204 153 255 204 153 255 204 153 255 204 153\n";
            Assert.Contains(expectedPixels, c.StringCanvasToPPM().Replace("\r\n","\n"));
            Assert.Contains(expectedPixels, c.StringCanvasToPPM());
        }
     }
        
   }

