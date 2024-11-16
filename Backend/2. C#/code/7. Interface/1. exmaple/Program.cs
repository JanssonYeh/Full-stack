interface IInfo
{
    string GetName();
    string GetAge();
}

class CA : IInfo
{
    public string Name;
    public int Age;

    public string GetAge()
    {
        return Age.ToString();
    }

    public string GetName()
    {
        return Name;
    }
}

class test
{
    static void PrintInfo(IInfo item)
    {
        Console.WriteLine("Name:{0},Age:{1}");
    }
    static void Main()
     
}