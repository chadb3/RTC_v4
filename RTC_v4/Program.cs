using RTC_v4;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
test();
norm_test_point();
testing_dot();
basic_canvas_test();
loop_and_array_behavior_testing();
Canvas2();
ClampColor(0.5);

return 0;
static void test()
{
    Console.WriteLine("TEST!");
    Tuple<int, int> tuple = new Tuple<int, int>(1, 2);
    Console.WriteLine($"Tuple values: {tuple.Item1}, {tuple.Item2}");
    Console.WriteLine(Math.Pow(2, 9));
}

// Function designed to test what a normalized "point" looks like as the book says it is for vectors
// This is just a test to see if it is difference between a point.normalize and vector.normalize that have the same values (minus w=1 of the point)
// This test proves they are different.
static void norm_test_point()
{
    RTTuple test = RTTuple.point(5, 4, 5);
    RTTuple control = RTTuple.vector(5, 4, 5);
    Console.WriteLine($"test: {test.normalize()}");
    Console.WriteLine($"control: {control.normalize()}");
}
// quick teste to remember how to do left and right vals.
static void testing_dot()
{
    Console.WriteLine("Quick dot test!\n");
    RTTuple vec1 = RTTuple.vector(1, 2, 3);
    RTTuple vec2 = RTTuple.vector(2, 3, 4);
    Console.WriteLine(vec1.Zdot(vec2));
}

static void basic_canvas_test()
{
    Console.WriteLine("COLOR");
    Canvas c = new Canvas(5, 3);
    Console.WriteLine(c.CanvasImage[0, 0]);
    Console.Write(c.StringCanvasToPPM());
    Console.WriteLine("\n\nEnd canvas");
}

static void loop_and_array_behavior_testing()
{
    printl("\nArray and Loop testing");
    int[,] a = new int[22, 3];
    printl(a[0, 0].ToString());
    for(int i =0;i<22;i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"{a[i, j]} ");
            //Console.Write($"{i},{j} ");
        }
        Console.WriteLine("\n");
    }
}

static void Canvas2()
{
    Console.WriteLine("------------");
    Canvas c = new Canvas(5, 3);
    var ppm = c.StringCanvasToPPM();
    RTTuple c1 = RTTuple.color(1.5, 0, 0);
    RTTuple c2 = RTTuple.color(0, 0.5, 0);
    RTTuple c3 = RTTuple.color(-0.5, 0, 1);
    c.WritePixle(c1, 0, 0);
    c.WritePixle(c2, 2, 1);
    c.WritePixle(c3, 4, 2);
    Console.WriteLine(c.StringCanvasToPPM());
    Console.WriteLine("------------");
}

static void printl(string msg)
{
    Console.WriteLine(msg);
}

static void ClampColor(double colorIn)
{
    // scale fraction value to 0-255
    double scaledColor = colorIn * 255;
    // round it, and using "AwayFromZero" to round up to 1
    double rounded = Math.Round(scaledColor, MidpointRounding.AwayFromZero);
    // clamp between 0 and 255 then I can cast to int
    // using clamp function rather then using nested min and max i used before
    int RoundedColor=(int)Math.Clamp(rounded, 0, 255);
    Console.WriteLine($"colorIn: {colorIn}\nrounded: {rounded}\nRoundedColor: {RoundedColor}");
}