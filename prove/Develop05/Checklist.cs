class Checklist : Goal
{
    int completePoints;
    public Checklist(string name, int points, int timesToComplete, int timesCompleted, int completePoints) : base(name, points, timesToComplete, timesCompleted)
    {
        this.completePoints = completePoints;
    }
}