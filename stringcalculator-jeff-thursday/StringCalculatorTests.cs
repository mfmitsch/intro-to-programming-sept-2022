
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
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("982", 982)]
    public void SingleDigit(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("182,3", 185)]

    public void TwoDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData("3,3,0", 6)]
    [InlineData("3,3,1", 7)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]

    public void ArbitraryDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData("3\n1", 4)]
    [InlineData("3\n3", 6)]
    [InlineData("1\n2\n3\n4\n5\n6\n7\n8\n9", 45)]


    public void NewLineDelimeters(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData("3\n1,1", 5)]
    public void MixedDelimeters(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;2;3", 6)]

    public void CustomDelimeter(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(result, expected);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;2,3", 6)]
    [InlineData("//;\n1;2,3\n1", 7)]

    public void MixedWithCustom(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(result, expected);
    }


}
