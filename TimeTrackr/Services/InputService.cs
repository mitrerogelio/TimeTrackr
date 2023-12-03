using TimeTrackr.Interfaces;

namespace TimeTrackr.Services;

public class InputService : IInputService
{
    private readonly IConsole _console;
    private readonly IDateTimeValidator _dateTimeValidator;

    public InputService(IConsole systemConsole, IDateTimeValidator dateTimeValidator)
    {
        _console = systemConsole;
        _dateTimeValidator = dateTimeValidator;
    }

    public void ProcessTimeInput()
    {
        bool isValidInput = false;
        while (!isValidInput)
        {
            _console.WriteLine("Start Time: ");
            string? startTimeInput = _console.ReadLine();
            _console.WriteLine("End Time: ");
            string? endTimeInput = _console.ReadLine();

            if (startTimeInput == null || endTimeInput == null) continue;

            isValidInput = _dateTimeValidator.ValidateInput(startTimeInput, endTimeInput, out DateTime startTime,
                out DateTime endTime);
            if (!isValidInput)
            {
                _console.WriteLine("Invalid input. Please enter the time in a valid format.");
            }
            else
            {
                TimeSpan timeDifference = endTime - startTime;
                _console.WriteLine(
                    $"Time Difference: {timeDifference.Hours} hours and {timeDifference.Minutes} minutes");
            }
        }
    }
}