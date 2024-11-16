/*
 * 事件是函数成员的一种，因此要定义在类里
  
 * 理解委托与事件之间的关系：
 *      事件是只管因为什么会触发，而委托是管具体发生什么行为
 */

// 事件使用的场景：简单的按钮点击、股票价格变化通知、下载进度通知

/*      
 * 事件有哪些组件：
 *      1. 委托类型声明
       
 *      发布者：创建事件并编写触发逻辑
              
 *      订阅者：1. 订阅事件
 *             2. 事件处理函数
 */

/*  以简单的按钮点击为例
 *      1. 委托类型声明： 声明一个委托，在按钮点击后要做什么做事情
 
 *      2. 发布者： 创建一个事件，如果有人点击，则触发这个事件
       
 *      3. 订阅者：订阅触发事件; 按钮点击，弹出“按钮被点击了”；
 */

// 委托类型声明
public delegate void ClickEventHandler();

//发布者： 创建一个事件，如果有人点击，则触发这个事件
class Publisher
{
    //事件声明的语法：限制修饰词  event 委托类型 事件名;
    public event ClickEventHandler Button;

    //如果有人点击就触发事件, 具体事件给委托处理
    public void Onclick()
    {
        Button?.Invoke();
    }
}

class describer
{
    // 订阅触发事件
    public describer(Publisher publisher)
    {
        publisher.Button += ButtonOnclick;
    }

    //按钮点击，弹出“按钮被点击了”
    public void ButtonOnclick()
    {
        Console.WriteLine("按钮被点击了");
    }
}

class test
{
    static void Main()
    {
       var publisher = new Publisher();
       var describer = new describer(publisher);
        describer.ButtonOnclick();
    }
}