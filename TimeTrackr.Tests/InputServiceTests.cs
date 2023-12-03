using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using TimeTrackr.Interfaces;
using TimeTrackr.Services;

namespace TimeTrackr.Tests;

[TestClass]
public class InputServiceTests
{
    private IConsole _console = null!;
    private IDateTimeValidator _dateTimeValidator = null!;
    private InputService _inputService = null!;

    [TestInitialize]
    public void TestInitialize()
    {
        _console = Substitute.For<IConsole>();
        _dateTimeValidator = Substitute.For<IDateTimeValidator>();

        _inputService = new InputService(_console, _dateTimeValidator);
    }

    [TestMethod]
    public void ProcessTimeInput_WithValidTimes_ShouldCalculateTimeDifference()
    {
        // Arrange
        _console.ReadLine().Returns("10:00", "11:00");
        _dateTimeValidator.ValidateInput(Arg.Any<string>(), Arg.Any<string>(), out Arg.Any<DateTime>(), out Arg.Any<DateTime>())
            .Returns(x =>
            {
                x[2] = DateTime.Today.AddHours(10);
                x[3] = DateTime.Today.AddHours(11);
                return true;
            });


        // Act
        _inputService.ProcessTimeInput();

        // Assert
        _console.Received().WriteLine("Time Difference: 1 hours and 0 minutes");
    }


    [TestMethod]
    public void ProcessTimeInput_WithInvalidTimes_ShouldPromptAgain()
    {
        // Arrange
        _console.ReadLine().Returns("invalid", "invalid", "10:00", "11:00");
        _dateTimeValidator.ValidateInput(Arg.Any<string>(), Arg.Any<string>(), out Arg.Any<DateTime>(),
                out Arg.Any<DateTime>())
            .Returns(x =>
            {
                if (x.ArgAt<string>(0) == "invalid")
                {
                    return false;
                }

                x[2] = DateTime.Today.AddHours(10);
                x[3] = DateTime.Today.AddHours(11);
                return true;
            });

        // Act
        _inputService.ProcessTimeInput();

        // Assert
        _console.Received().WriteLine("Invalid input. Please enter the time in a valid format.");
    }
}