namespace TimeTrackr;

public static class InputService
{
    private static bool ValidateInput(string start, string end, out DateTime startTime, out DateTime endTime)
    {
        bool isStartValid = DateTime.TryParse(start, out startTime);
        bool isEndValid = DateTime.TryParse(end, out endTime);

        return isStartValid && isEndValid;
    }

    public static void ProcessTimeInput()
    {
        bool isValidInput = false;
        while (!isValidInput)
        {
            Console.WriteLine("Start Time: ");
            string? startTimeInput = Console.ReadLine();
            Console.WriteLine("End Time: ");
            string? endTimeInput = Console.ReadLine();

            if (startTimeInput == null || endTimeInput == null) continue;

            isValidInput = ValidateInput(startTimeInput, endTimeInput, out DateTime startTime,
                out DateTime endTime);
            if (!isValidInput)
            {
                Console.WriteLine("Invalid input. Please enter the time in a valid format.");
            }
            else
            {
                TimeSpan timeDifference = endTime - startTime;
                Console.WriteLine(
                    $"Time Difference: {timeDifference.Hours} hours and {timeDifference.Minutes} minutes");
            }
        }
    }
}