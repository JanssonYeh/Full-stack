/* .NET事件的标准用法包含以下几点(此委托系统已经定义好了)：
 *      public delegate void EventHandler(object sender, EventArgs e); 
 *      
 *      第一个参数sender： 用于保存触发事件的对象，类型为object，可以匹配任何类型的实例
 *      
 *      第二个参数EventArgs：用于传递事件相关的数据
 *              1. 如果不需要传递数据，可以使用普通的EventArgs类
 *              
 *              2. 如果需要传递特定数据，需要创建EventArgs的子类来存储所需数据
 *      
 *      返回类型：void        
*/


/*
 * 股票价格变化监控系统：
 *      1. 监控股票价格的变化
 *      2. 当价格发生变化的时候通知订阅者
 *      3. 提供新旧价格的对比信息：
 * 
 * 具体要实现的组件：
 *      1. 股票价格变化的事件参数类(StockPriceEventArgs)：
            存储股票代码(Symbol)
            存储旧价格(OldPrice)
            存储新价格(NewPrice)

        2.股票类(Stock)：
            维护股票基本信息(代码、价格)
            提供修改价格的方法
            实现价格变化的事件通知机制
 */

/*
 * 编写逻辑：
 *  1. 重述需求：需要监控一个代码，当价格发生变化时，触发事件 
 *  2. 发布者： 声明一个触发事件，当价格发生变化，触发事件
 *  3. 订购者： 绑定触发事件，并编写触发事件做什么事情
 *  4. 思考要传递哪些参数：哪个代码，当前价格，以前价格
 */



class StockPriceEventArgs: EventArgs
{
    private string Id { get; }
    private decimal OldPrice { get; }

    private decimal NewPrice { get; }

    public StockPriceEventArgs(string id, decimal oldprice, decimal newprice)
    {
        this.Id = id;
        this.OldPrice = oldprice;
        this.NewPrice = newprice;
    }
}
//发布者
class Stock
{
    private string Sybmol;

    private decimal CurrentPrice;

    private decimal PreviousPrice;

    public Stock(string sybmol, decimal currentprice, decimal previousprice)
    {
        this.Sybmol = sybmol;
        this.CurrentPrice = currentprice;
        this.PreviousPrice = previousprice;
    }

    public event EventHandler<StockPriceEventArgs> OnPriceChanged;
    
    public void PriceChange()
    {
        if (true)
        {
            OnPriceChanged(this, OldPrice());
        }
    }
}

//class sendUser
//{
//    public sendUser(Stock stock)
//    {
//        stock.PriceChange += information;
//    }

//    public void information(object sender, EventArgs e)
//    {

//    }
   
//}