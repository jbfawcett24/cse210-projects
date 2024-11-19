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
        Menu menu = new Menu();
        while(true)
        {
            menu.Display();
        }
    }
}