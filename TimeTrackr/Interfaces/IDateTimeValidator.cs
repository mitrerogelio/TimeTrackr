namespace TimeTrackr.Interfaces;

public interface IDateTimeValidator
{
    public bool ValidateInput(string start, string end, out DateTime startTime, out DateTime endTime);
}
