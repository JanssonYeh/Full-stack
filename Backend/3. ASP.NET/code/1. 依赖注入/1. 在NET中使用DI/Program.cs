using Microsoft.Extensions.DependencyInjection;

public interface IMessageWrite
{
    void Write(string message);
}

public class MessageWrite: IMessageWrite
{
    public void Write(string message)
    {
        Console.WriteLine($"The message is {message}");
    }
}

class program
{
    static void Main()
    {
        var service = new ServiceCollection();
        service.AddTransient<IMessageWrite, MessageWrite>();

        using (var serviceProvider = service.BuildServiceProvider())
        {
            var user = serviceProvider.GetService<IMessageWrite>();
            user.Write("124153");
        }
    }
}