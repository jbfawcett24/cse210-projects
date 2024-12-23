using System.Diagnostics;

class Activity
{
    string description;
    string name;
    Random random = new Random();
    public Activity(string name, string description)
    {
        this.description = description;
        this.name = name;
    }
    public void Countdown(int time, string display)
    {
        Console.Write($"{display}");
        for(int i = time; i>0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.Write("0");
        Console.WriteLine();
    }
    public void Spinner(int time)
    {
        for(int i = 0; i<time*2; i++)
        {
            Console.Write("|");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("-");
            Thread.Sleep(125);
            Console.Write("\b \b");
            Console.Write("\\");
            Thread.Sleep(125);
            Console.Write("\b \b");
        }
    }
    public int Start()
    {
        Console.WriteLine($"Welcome to the {name}.");
        Console.WriteLine();
        Console.WriteLine(description);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session?");
        string input = Console.ReadLine();
        try 
        {
            return int.Parse(input);
        } 
        catch(Exception)
        {
            Start();
        }
        return int.Parse(input);
    }
    public void End(string title, int time)
    {
        Console.WriteLine("Well Done!");
        Console.WriteLine();
        Console.WriteLine($"You have completed {time} seconds of {title}");
        Console.ReadLine();
        Console.Clear();
    }
    public string GetRandPrompt(List<string> prompts)
    {
        return prompts[random.Next(0, prompts.Count)];
    }
    public string GetName()
    {
        return name;
    }
}