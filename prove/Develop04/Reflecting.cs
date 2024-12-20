using System.ComponentModel.Design;

class Reflecting : Activity
{
    List<string> prompts = new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
    List<string> reflections = new List<string>{"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};
    public Reflecting(string name, string description) : base(name, description){}
    public void DoActivity()
    {
        int duration = Start();
        Think();
        for(int i = 0; i<duration; i+=2)
        {
            Answer();
        }
        Spinner(1);
        End(GetName(), duration);
    }
    private void Think()
    {
        Console.WriteLine(GetRandPrompt(prompts));
        Console.WriteLine("Press enter to continue");
        Console.ReadLine();
    }
    private void Answer()
    {
        Console.Clear();
        Console.WriteLine(GetRandPrompt(reflections));
        Spinner(2);
    }
}