class Checklist : Goal
{
    int completePoints;
    public Checklist(string name, int points, int timesToComplete, int timesCompleted, int completePoints) : base(name, points, timesToComplete, timesCompleted)
    {
        this.completePoints = completePoints;
    }
    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.Write($" {{{timesCompleted}/{timesToComplete}}} ({completePoints}pts)");
        Console.WriteLine();
    }
    public override void CompleteQuest()
    {
        base.CompleteQuest();
        if(timesCompleted == timesToComplete)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Checklist Quest Completed, you gained {completePoints} points!");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public override int GetFinishedPoints()
    {
        return completePoints;
    }
}