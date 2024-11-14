/* 
    理解委托的本质：普通函数传入是的参数，而委托传入的是函数指针

    知晓委托使用的场景：
        1. 回调函数 —— 读取数据文件，读取完成后调用函数
        2. 验证器  —— 委托密码验证规则，最后根据实际情况编写委托的验证规则函数
        3. 日志记录 —— 
        4. 排序策略 —— 比较规则不知道是什么，因此把比较函数委托出去，具体怎么比较根据实际情况再说
 */



/*
 *  委托是用户自定义类型，与class等级平行，且与类操作一致
 *  
 *   类的使用：
 *       1. 声明一个类
 *       2. 声明类 类型的变量，并实例化(把引用)赋值给变量
 *       3. 使用类对象
 *       
 *   委托的使用:
 *       1. 声明一个委托
 *       2. 声明委托 类型的变量，并实例化(把引用)赋值给变量
 *       3. 调用委托对象
 */




/*
    通过委托编写：回调函数 —— 读取数据文件，读取完成后调用函数
    目的：体会委托使用场景以及委托语法
 */

class DataProcessor
{
    public void ProcessDataAsyn(string data, ProcessCompletedCallback callback)
    {
        try
        {
            //进行数据处理
            string result = data.ToString();

            //数据处理完毕后，进行回调函数处理
            callback(true,result);
        }
        catch(Exception ex)
        {
            callback(false, ex.Message);
        }
    }

    public void IfSuccess(bool flag, string result)
    {
        if (flag == false)
        {
            Console.WriteLine($"处理失败：{result}");
        }
        else
        {
            Console.WriteLine($"处理成功：{result}");
        }
    }
}

//1. 声明一个委托: 访问修饰符 delegate 返回类型 方法名(签名)。    !!!切记：委托没有方法主体
public delegate void ProcessCompletedCallback(bool flag, string result);
/*
class test
{
    static void Main()
    {
        var processor = new DataProcessor();

        //2.声明委托 类型的变量，并实例化(把引用)赋值给变量
        ProcessCompletedCallback ifsuccess = processor.IfSuccess;

        //3. 调用委托对象
        processor.ProcessDataAsyn("abc", ifsuccess);
    }
}
*/