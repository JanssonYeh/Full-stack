using System;

static class ExtendedMethods
{
    public static T GetElement<T>(this Method<T> method, int index)
    {
        if (index < 0 || index >= method.Length)
            throw new IndexOutOfRangeException();
        return method.Array[index];
    }
}

class Method<T>
{
    static private T[] arr = new T[10];
    static private int i;
    internal T[] Array => arr;
    internal int Length => arr.Length;

    public void addArr(T a)
    {
        if(i >= arr.Length)
        {
            Console.WriteLine("Array is full");
        }
        arr[i] = a;
        Console.WriteLine($"Added element at position {i} :{arr[i]}");
        i++;
    }
}

class test
{
    static void Main()
    {
        Method<int> a = new Method<int>();

        a.addArr(5);
        a.addArr(3);
        a.addArr(4);

        ExtendedMethods.GetElement
    }
}