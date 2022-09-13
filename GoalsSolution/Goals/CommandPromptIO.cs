/*
 * Journal
Create a .NET Console Application called 'Goals' that you can run from the command line that asks you your goal for the day.
It trims the input to 256 characters, accepts just one line of text. It displays the entry like this:

Enter your goal for today:
--------------------------
I would like to learn how to use C# Generics.

[For Monday, August 12, 2022 Your Goal Is:]

"I would like to learn how to use C# Generics"

[Save Changes (Y/n)] Y

If you hit enter (or 'Y'), it saves your changes in the Application.LocalUserAppDataPath in a file called "goals.txt". It appends each entry to the end of the file.

Part 2
After the journal is created, when you run the application, it asks if you want to view previous entries. If the user replies affirmatively, you show them all the previous entries.

Part 3
If you run the command with the -s or --show flag, it simply shows the last goal set, or a message saying there are no saved goals.

Part 4
Final. Build the application in release mode. Create an executable and put that executable in a folder in your c:\users\ItuStudent\dev directory called bin. Add that folder to your Windows PATH environment variable so that you can from any command prompt run goals (or goals -s) to use your application.
*/
internal class CommandPromptIO
{
    public string GetUserInput()
    {
        string input = "";
        char newChar;
        while ((newChar = (char)Console.Read()) != '\n')
        {
            if (input.Length < 256)
            {
                input += newChar;
            }
            else
            {
                input.Remove(0, 1);
                input += newChar;
            }
        }
        return input;
    }
    public void PromptUser()
    {
        Console.WriteLine("Enter your goal for today:");
        Console.WriteLine("--------------------------");
    }
}