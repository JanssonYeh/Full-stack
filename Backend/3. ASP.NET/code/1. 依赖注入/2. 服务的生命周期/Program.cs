using Microsoft.Extensions.DependencyInjection;

public interface IMessageWrite
{
    void Write(string message);
}

public class MessageWrite:IMessageWrite
{
    public void Write(string message)
    {
        Console.WriteLine($"this is {message}");
    }
}

class program
{
    static void Main()
    {
        var services = new ServiceCollection();
        services.AddTransient<IMessageWrite, MessageWrite>();

        var serviceProvide = services.BuildServiceProvider();

       
    }
}
