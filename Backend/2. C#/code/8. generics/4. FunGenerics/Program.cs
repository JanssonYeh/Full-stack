// 泛型方法可以声明在泛型和非泛型类以及结构和接口

class FunGenerics
{
    public void PrintDatas<T1, T2>(T1 a, T2 b)
        where T1 :struct
        where T2 :class
    {
        Console.WriteLine($"{a}");
        Console.WriteLine($"{b}");
    }
}

class test
{
    static void Main()
    {
        var functionA = new FunGenerics();
        functionA.PrintDatas<int, int[]>(10, new int[] {1,2,3});
        functionA.PrintDatas<int, string>(10,  "hello");

        //编译器会根据输入的参数自动推断类型
        functionA.PrintDatas(20, "helloboy");
        functionA.PrintDatas(20, new int[] { 1, 2, 4 });
    }
}

