

// 委托场景使用2： 密码规则验证，具体规则晚点来定

//1. 申明一个密码规则的委托
public delegate bool PasswordRule(string str);
class Rules
{
    public bool Validate(string passwords, params PasswordRule[] rules)
    {
        foreach(var rule in rules)
        {
            if (!rule(passwords))
            {
                return false;
            }
        }
        return true;
    }
}

//class test
//{
//    static void Main()
//    {
//        var rules = new Rules();

//        //2.声明委托 类型的变量，并实例化(把引用)赋值给变量
//        PasswordRule notEmpty = (password) =>!string.IsNullOrEmpty(password);
//        PasswordRule LimitedLength = (password) => password.Length >= 6 && password.Length <= 10 ;

//        string password = "abcefgh";

//        Console.WriteLine(rules.Validate(password, notEmpty, LimitedLength));
//    }

//}