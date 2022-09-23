using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace StringCalculator;

public class StringCalculatorInterationTest
{
    [Theory]
    [InlineData("1","1")]
    [InlineData("1,2,3,4,5","15")]
    public void CalculatorWritesAnswerToTheLogger(string numbers,string expectedLoggedMessage)
    {
        var mockedLogger = new Mock<ILogger>();


        var calculator = new StringCalculator(mockedLogger.Object);

        var answer = calculator.Add(numbers);

        mockedLogger.Verify(logger => logger.Write(expectedLoggedMessage));
    }

    [Fact]
    public void WhenLoggerThrowsExceptionWebServiceIsCalled()
    {
        var stubbedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(stubbedLogger.Object);
        stubbedLogger.Setup(s => s.Write(It.IsAny<string>())).Throws(new LoggingFailed)
}
