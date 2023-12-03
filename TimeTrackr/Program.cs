using TimeTrackr.Interfaces;
using TimeTrackr.Services;
using TimeTrackr.Utilities;

namespace TimeTrackr;

internal static class Program
{
    private static void Main()
    {
        IDateTimeValidator dateTimeValidator = new DateTimeValidator();
        IConsole systemConsole = new SystemConsole();
        IInputService inputService = new InputService(systemConsole, dateTimeValidator);

        while (true) // Infinite loop
        {
            systemConsole.WriteLine(
                "\nEnter 'start' to input times, 'exit' to quit, or anything else to continue running.");

            string? command = systemConsole.ReadLine();

            if (command != null && command.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                systemConsole.WriteLine("See you later!");
                break;
            }

            if (command != null && command.Equals("start", StringComparison.OrdinalIgnoreCase))
            {
                inputService.ProcessTimeInput();
            }
        }
    }
}