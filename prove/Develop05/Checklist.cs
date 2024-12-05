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
    public override int GetFinishedPoints()
    {
        return completePoints;
    }
}