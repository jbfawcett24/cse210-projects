using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Input Grade: ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);
        string letter;
        bool passing = false;
        string plusMinus;
        if (percent >= 90) {
            letter = "A";
        } else if (percent >= 80){
            letter = "B";
        } else if (percent >= 70) {
            letter = "C";
        } else if (percent >= 60) {
            letter = "D";
        } else {
            letter = "F";
        }

        if ((percent % 10) >= 7 && percent > 50 && percent < 90){
            plusMinus = "+";
        } else if ((percent % 10) < 3 && letter != "F") {
            plusMinus = "-";
        } else {
            plusMinus = "";
        }
        if (percent >= 70) {
            passing = true;
        }
        Console.WriteLine($"Your letter grade is {letter}{plusMinus}");
        if (passing == true) {
            Console.WriteLine("Congrats, you are passing!");
        } else {
            Console.WriteLine("Uh Oh, you're failing");
        }
    }
}