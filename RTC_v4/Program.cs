using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");
test();

static void test()
{
    Console.WriteLine("dsfg !");
    Tuple<int, int> tuple = new Tuple<int, int>(1, 2);
    Console.WriteLine($"Tuple values: {tuple.Item1}, {tuple.Item2}");
}

return 0;