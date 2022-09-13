using System.Security.Cryptography.X509Certificates;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        string[] splitNums;
        // check for custom delimeter
        if (numbers.StartsWith("//") && numbers.Length >= 4
            && numbers.ElementAt(3) == '\n') 
        {
            //split by normal and custom delimeters
            char newDelim = numbers.ElementAt(2);
            numbers = numbers.Remove(0, 4);
            splitNums = numbers.Split(',','\n',newDelim);
        }
        //otherwise splite by normal delimeters
        else splitNums = numbers.Split(',', '\n');
        var total = 0;
        // add up each number and return zero if you encounter non int
        foreach(var strNum in splitNums)
        {
            if(int.TryParse(strNum,out var intNum))
            {
                total += intNum;
            }
            else return 0;
        }
        return total;
    }
}
