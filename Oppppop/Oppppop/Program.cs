using System;

namespace Oppppop
{
    class Program
    {
        static int ExampleParamDefault(int x, int y, int z = 5, int s = 7)
        {
            return x + y + z + s;
        }
        static void Main(string[] args)
        {
            ExampleParamDefault(y: 2, x: 3, s: 10);
            Console.WriteLine("Hello World!");
        }
    }
}
