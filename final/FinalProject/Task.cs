using Microsoft.VisualBasic;

class Task
{
    DateOnly timeStarted;
    string repeatTime;
    string name;
    int points;
    bool complete = false;
    bool initComplete;
    DateOnly currentTime = new DateOnly();
    DateOnly lastCompleted;
    public Task(string name, string repeatTime, int points, DateOnly timeStarted, bool initComplete)
    {
        this.name = name;
        this.points = points;
        this.repeatTime = repeatTime;
        this.timeStarted = timeStarted;
        this.initComplete = initComplete;
        currentTime = DateOnly.FromDateTime(DateTime.Now);
        //Console.WriteLine($"{currentTime} - {timeStarted}");
    }
    public int GetPoints()
    {
        return points;
    }
    public virtual void DisplayTask()
    {
        if(ShouldDisplay())
        {
            Console.WriteLine($"{name} [{points}]");
        }
    }
    public void CompleteTask()
    {
        Console.WriteLine("completed");
        lastCompleted = DateOnly.FromDateTime(DateTime.Now);
        complete = true;
    }
    private void CheckComplete()
    {
        if(!initComplete)
        {
            complete = false;
        } else if(lastCompleted != currentTime && repeatTime == "daily")
        {
            complete = false;
        } else if(timeStarted.DayOfWeek == currentTime.DayOfWeek && repeatTime == "weekly")
        {
            complete = false;
        } else {
            complete = true;
        }
    }
    private bool ShouldDisplay()
    {
        CheckComplete();
        return !complete;
    }
}