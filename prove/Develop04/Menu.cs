using System.Runtime.CompilerServices;

class Menu
{
    Breathing breathing = new Breathing("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.");
    Listing listing = new Listing("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
    Reflecting reflecting = new Reflecting("Reflecting Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
    public void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("\t1. Start breathing activity");
        Console.WriteLine("\t2. Start reflecting activity");
        Console.WriteLine("\t3. Start listing activity");
        Console.WriteLine("\t4. Quit");
        Console.Write("Select a choice from the menu: ");
        ProcessInput();
    }
    private void ProcessInput()
    {
        string input = Console.ReadLine();
        switch(input)
        {
            case "1":
                Console.Clear();
                breathing.DoActivity();
                DisplayMenu();
                break;
            case "2":
                Console.Clear();
                reflecting.DoActivity();
                DisplayMenu();
                break;
            case "3":
                Console.Clear();
                listing.DoActivity();
                DisplayMenu();
                break;
            case "4":
                Console.Clear();
                Environment.Exit(0);
                break;
            default:
                Console.Clear();
                DisplayMenu();
                break;
        }
    }
}