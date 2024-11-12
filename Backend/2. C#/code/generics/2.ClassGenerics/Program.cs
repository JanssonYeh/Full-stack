
/*
    声明泛型类：
        1.在类名之后放置一组尖括号
        2.尖括号里用占位符字符串(type parameter)来表示希望占位的类型，用逗号分割
        3. 在泛型类声明的主体中使用类型参数表示应该替代的类型
 */

class ClassGenerics<T1,T2>
{
    public T1 name;
    public T2 age;
}

class test
{
    static void Main()
    {
        /*
            创建构造类型与实例：
                1. 创建构造类型时，尖括号中提供真实类型[类型实参(type argument)]代替类型参数

                2. 创建实例和类的实例化一模一样，不过我们可以通过var关键字让编译器自动识别类型引用
         */

        ClassGenerics<string, int> a = new ClassGenerics<string, int>();

        var b = new ClassGenerics<string, double>();


        a.name = "J";
        a.age = 18;
        

        b.name = "X";
        b.age = 24.5;

        Console.WriteLine($"a的名字是{a.name},a的年龄是{a.age}");

        Console.WriteLine($"b的名字是{b.name},b的年龄是{b.age}");
    }
}