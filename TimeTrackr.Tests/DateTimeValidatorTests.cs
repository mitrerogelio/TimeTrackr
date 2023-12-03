using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeTrackr.Services;

namespace TimeTrackr.Tests;

[TestClass]
public class DateTimeValidatorTests
{
    private DateTimeValidator _validator;

    [TestInitialize]
    public void Setup()
    {
        _validator = new DateTimeValidator();
    }

    [TestMethod]
    public void ValidateInput_ValidTimes_ReturnsTrue()
    {
        // Arrange
        const string startTime = "10:00 AM";
        const string endTime = "11:00 AM";
        
        // Act
        bool result = _validator.ValidateInput(startTime, endTime, out DateTime startDateTime, out DateTime endDateTime);
        
        // Assert
        Assert.IsTrue(result);
        Assert.AreEqual(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 10, 0, 0), startDateTime);
        Assert.AreEqual(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 0, 0), endDateTime);
    }
}