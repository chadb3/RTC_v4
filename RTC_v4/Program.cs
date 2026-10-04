using RTC_v4;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");
test();
norm_test_point();
testing_dot();
basic_canvas_test();
loop_and_array_behavior_testing();

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
    Canvas c = new Canvas(2, 2);
    Console.WriteLine(c.CanvasImage[0, 0]);
}

static void loop_and_array_behavior_testing()
{
    printl("\nArray and Loop testing");
    int[,] a = new int[2, 3];
    printl(a[0, 0].ToString());
    for(int i =0;i<2;i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"{a[i, j]} ");
            //Console.Write($"{i},{j} ");
        }
        Console.WriteLine("\n");
    }
}

static void printl(string msg)
{
    Console.WriteLine(msg);
}