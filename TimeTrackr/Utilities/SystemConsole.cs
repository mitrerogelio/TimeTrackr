using TimeTrackr.Interfaces;

namespace TimeTrackr.Utilities;

public class SystemConsole : IConsole
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }
}