using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Develop03 World!");
        // Refrence refrence = new Refrence("John", 3, 16);
        // refrence.Display();
        // Refrence refrence1 = new Refrence("Proverbs", 3, 5, 6);
        // refrence1.Display();
        Scripture scripture = new Scripture("For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life");
        scripture.Display();
        scripture.words.ReplaceWords();
        scripture.Display();
    }
}