using TimeTrackr.Interfaces;

namespace TimeTrackr.Services;

public class DateTimeValidator : IDateTimeValidator
{
    public bool ValidateInput(string start, string end, out DateTime startTime, out DateTime endTime)
    {
        bool isStartValid = DateTime.TryParse(start, out startTime);
        bool isEndValid = DateTime.TryParse(end, out endTime);

        return isStartValid && isEndValid;
    }
}
