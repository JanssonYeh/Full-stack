/*
 discription: This file aims to compare traditional types and generics 
 */

class tradition
{
    static public int IntAdd(int a, int b)
    {
        return a + b;
    }

    static public double DoubleAdd(double a, double b)
    {
        return  a + b;     
    }
}

class Generics<T>
    where T:struct
{
    static public T Add(T a, T b)
    {
        return (dynamic) a + b;
    }
}

class test
{
    static void Main()
    {
        Console.WriteLine(tradition.IntAdd(3, 4));
        Console.WriteLine(tradition.DoubleAdd(3.1, 4.1));

        Console.WriteLine(Generics<int>.Add(3,4));
    }
}