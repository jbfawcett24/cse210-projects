class Simple : Goal
{
    public Simple(string name, int points, int timesCompleted) : base(name, points, 1, timesCompleted)
    {

    }
    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine();
    }
}