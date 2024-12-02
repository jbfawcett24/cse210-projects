using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

class Listing : Activity
{
    List<string> prompts = new List<string>{"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    List<string> answers = new List<string>{};
    List<string> loadedAnswers = new List<string>{};
    string filename = "list.txt";
    public Listing(string name, string description) : base(name, description)
    {
        LoadAnswers();
    }
    public void DoActivity()
    {
        StartUp();
        int duration = Start();
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.Elapsed.TotalSeconds < duration)
        {   
            AskQuestion();
        }
        SaveAnswers();
        Spinner(1);
        End(GetName(), duration);
    }
    private void AskQuestion()
    {
        string question = GetRandPrompt(prompts);
        Console.WriteLine(question);
        string answer = Console.ReadLine();
        answers.Add(question);
        answers.Add(answer);
    }
    private void LoadAnswers()
    {
        loadedAnswers.Clear();
        loadedAnswers = File.ReadAllLines(filename).ToList();
    }
    public void SaveAnswers()
    {
        using(StreamWriter writer = new StreamWriter(filename))
        {
            for(int i = 0; i<answers.Count(); i++)
            {
                loadedAnswers.Add(answers[i]);
            }
            for (int i = 0; i < loadedAnswers.Count; i++)
            {
                Console.WriteLine(loadedAnswers[i]);
                writer.WriteLine(loadedAnswers[i]);
            }
        }
    }
    private void DisplayAnswers()
    {
        for(int i = 0; i<loadedAnswers.Count; i+=2)
        {
            Console.WriteLine($"Question: {loadedAnswers[i]}");
            Console.WriteLine($"Answer: {loadedAnswers[i+1]}");
            Console.WriteLine();
        }
        Console.ReadLine();
    }
    private void StartUp()
    {
        Console.WriteLine("Would you like to see previous answers? [y/n]");
        string intput = Console.ReadLine();
        if(intput == "y")
        {
            LoadAnswers();
            DisplayAnswers();
        }
    }
}
