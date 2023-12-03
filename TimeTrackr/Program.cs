using TimeTrackr;

while (true) // Infinite loop
{
    Console.WriteLine("\nEnter 'start' to input times, 'exit' to quit, or anything else to continue running.");

    string? command = Console.ReadLine();

    if (command != null && command.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("See you later!");
        break;
    }

    if (command != null && command.Equals("start", StringComparison.OrdinalIgnoreCase))
    {
        InputService.ProcessTimeInput();
    }
}