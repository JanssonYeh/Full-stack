/*
 * 在定义上，结构和类都是数据类型，但是结构往往用于封装小型数据
 * 
 * 区别：
 *      1. 结构是赋值型，类是引用类型
 *      2. 结构是隐式密封的，不能被派生；类可以派生
 * 
 */

// 1. struct的声明语法：
/*  
 *  struct 结构名
 *  {
 *      field1;     //不能赋值
 *      field2;
 *  }
 */

struct Point
{
    public int X;
    public int Y;
}

class test
{
    static void Main()
    {
        var point = new Point();
        point.X = 10;
        point.Y = 20;
        Console.WriteLine($"X:{point.X}, Y:{point.Y}");
    }
}