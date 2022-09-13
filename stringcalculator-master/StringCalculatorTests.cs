
using System.ComponentModel.DataAnnotations;
using System.Runtime.ExceptionServices;

namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(-3)]
    public void StringWithOneNumber(int num)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(num.ToString());
        Assert.Equal(num, result);
    }
    [Theory]
    [InlineData("1\n4",5)]
    [InlineData("2\n-8",-6)]
    [InlineData("-3\n6969",6966)]
    [InlineData("1,4", 5)]
    [InlineData("2,-8", -6)]
    [InlineData("-3,6969", 6966)]
    [InlineData("1\n4\n4\n7\n8\n2\n8", 34)]
    [InlineData("2\n-8,-9,2,2", -11)]
    [InlineData("-3\n6969,5\n8,4", 6983)]
    public void TwoPlusNumberWithCorrectDelim(string inputStr,int answer)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(inputStr);
        Assert.Equal(answer, result);
    }
    [Theory]
    [InlineData("1.4")]
    [InlineData("2;-8")]
    [InlineData("-3/6969")]
    [InlineData("1|4")]
    [InlineData("2{}-8")]
    [InlineData("-3 6969")]
    [InlineData("1 4 4 7 8 2 8")]
    [InlineData("2 -8,-9,2,2")]
    [InlineData("-3\n6969}5\n8,4")]
    public void IncorrectDelimeterReturnsZero(string inputStr)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(inputStr);
        Assert.Equal(0, result);
    }
    [Theory]
    [InlineData("//n\n1n4", 5)]
    [InlineData("//abc\n2\n-8", 0)]
    [InlineData("//a\n-3\n6969", 6966)]
    [InlineData("//,\n1,4", 5)]
    [InlineData("//7\n27-8", -6)]
    [InlineData("//;\n-3;6969", 6966)]
    [InlineData("//\n\n1\n4\n4\n7\n8\n2\n8", 34)]
    public void SupportCustomDelimeters(string inputStr, int answer)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(inputStr);
        Assert.Equal(answer, result);
    }
}