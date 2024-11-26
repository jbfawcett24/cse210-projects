class Activity
{
    int duration;
    string description;
    public Activity(int duration, string description)
    {
        this.duration = duration;
        this.description = description;
    }
    public void Countdown(int time, string display)
    {
        Console.Write($"{display}: ");
        for(int i = time; i>0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public void Spinner(int time)
    {
        for(int i = 0; i<time*1000/500; i++)
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
    public void Start()
    {

    }
    public void End()
    {
        
    }
}