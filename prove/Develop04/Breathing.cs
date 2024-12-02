class Breathing : Activity
{
    public Breathing(string name, string description) : base(name, description){}
    public void DoActivity()
    {
        Console.ResetColor();
        int duration = Start();
        Console.Clear();
        CheckDuration(duration);
        for(int i = 0; i < duration/10; i++)
        {
            Breath(10);
        }
        Spinner(duration % 10);
        End(GetName(), duration);
    }
    private void Breath(int time)
    {
        Countdown(time/2, "Breathe In...");
        Countdown(time/2, "Breathe Out...");
        Console.WriteLine();
    }
    private void CheckDuration(int duration)
    {
        if(duration < 10)
        {   
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please input a value greater than 10 seconds.");
            DoActivity();
            Console.ResetColor();
        }
    }
}