class Goal
{
    string name;
    protected int timesToComplete;
    protected int timesCompleted;
    int points;
    public Goal(string name, int points, int timesToComplete, int timesCompleted)
    {
        this.name = name;
        this.points = points;
        this.timesToComplete = timesToComplete;
        this.timesCompleted = timesCompleted;
    }
    public string GetName()
    {
        return name;
    }
    public virtual int GetPoints()
    {
        return points;
    }
    public int GetTimesCompleted()
    {
        return timesCompleted;
    }
    public int GetTimesToComplete()
    {
        return timesToComplete;
    }
    public virtual void DisplayGoal()
    {
        Console.Write($"{GetName()} ({GetPoints()} pts)");
    }
    public virtual void CompleteQuest()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Quest Completed, you gained {points} points!");
        Console.ForegroundColor = ConsoleColor.White;
        timesCompleted++;
    }
    public bool GetFinished()
    {
        if(timesToComplete == timesCompleted)
        {
            return true;
        } else {
            return false;
        }
    }
    public virtual int GetFinishedPoints(){return 0;}
}