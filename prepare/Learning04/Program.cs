using System;

class Program
{
    static void Main(string[] args)
    {
        Math math = new Math("7.3", "8-19", "Samuel Rodriguez", "Fractions");
        Writing writing = new Writing("The Causes of World War II", "Mary Waters", "European History");
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInfo());
    }
}