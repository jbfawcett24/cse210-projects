using System;
using System.Globalization;

class Program
{
static void DisplayWelcome()
{
    Console.WriteLine("Welcome to the Program!");
}
static string PromptUserName()
{
    string name;
    Console.Write("Enter your name: ");
    name = Console.ReadLine();
    return name;
}
static string PromptUserNumber()
{
    string number;
    Console.Write("Enter your favorite number: ");
    number = Console.ReadLine();
    return number;
}
static int SquareNumber(string number)
{
    int intNum = int.Parse(number);
    intNum *= intNum;
    return intNum;
}
static void DisplayResult(string name, int number)
{
    Console.WriteLine($"{name}, the square of your number is {number}");
}    
    static void Main(string[] args)
    {
        DisplayWelcome();
        string userName = PromptUserName();
        string userNumber = PromptUserNumber();
        int squareNum = SquareNumber(userNumber);
        DisplayResult(userName, squareNum);


    }
}