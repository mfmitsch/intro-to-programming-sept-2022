using System.Security.Cryptography.X509Certificates;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        string[] splitNums;
        if (numbers.StartsWith("//") && numbers.Length >= 4
            && numbers.ElementAt(3) == '\n') 
        {
            char newDelim = numbers.ElementAt(2);
            numbers = numbers.Remove(0, 4);
            splitNums = numbers.Split(',','\n',newDelim);
        }
        else splitNums = numbers.Split(',', '\n');
        var total = 0;
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
