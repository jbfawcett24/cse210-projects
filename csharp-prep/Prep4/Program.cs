using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
        string input;
        float intInput = -1;
        List<float> numbers = new List<float>();
        Console.WriteLine("enter a list of numbers, type 0 to stop.");
        while(intInput != 0){
            Console.Write("Enter number: ");
            input = Console.ReadLine();
            intInput = float.Parse(input);
            if(intInput != 0){
                numbers.Add(intInput);
            } else {
                float sum = 0;
                int largeNum = 0;
                foreach(int num in numbers) {
                    sum += num;
                    if(num > largeNum) {
                        largeNum = num;
                    }
                }
                float average = sum / numbers.Count;
                Console.WriteLine($"Sum: {sum}, Average: {average}, Largest Number: {largeNum}");
            }
        }
    }
}