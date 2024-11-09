using System;

namespace Lambda
{
    class Program
    {
        static void Main()
        {
            Action f1 = delegate ()
            {
                Console.WriteLine("我是一条无参数无返回值的匿名委托");
            };
            f1();


            Action<string, int> f2 = delegate (string n, int i)
            {
                Console.WriteLine($"n={n},i={i},我是一条有参数无返回值的Action匿名委托");
            };
            f2("hello", 10);

            Func<int, int, int> f3 = delegate (int i, int j)
            {
                Console.WriteLine("我是一条有参数有返回值的匿名委托");
                return i + j;
            };
            f3(1, 2);

        }
    }
}
