using Microsoft.VisualBasic;

class Task
{
    DateOnly timeStarted;
    string repeatTime;
    string name;
    int points;
    bool complete;
    DateOnly currentTime = new DateOnly();
    DateOnly lastCompleted;
    public Task(string name, string repeatTime, int points, DateOnly timeStarted, bool complete)
    {
        this.name = name;
        this.points = points;
        this.repeatTime = repeatTime;
        this.timeStarted = timeStarted;
        this.complete = complete;
        currentTime = DateOnly.FromDateTime(DateTime.Now);
        //Console.WriteLine($"{currentTime} - {timeStarted}");
    }
    public string Name
    {
        get {return name;}
        set {name = value;}
    }
    public int Points
    {
        get {return points;}
        set {points = value;}
    }
    public string RepeatTime
    {
        get {return repeatTime;}
        set {repeatTime = value;}
    }
    public DateOnly TimeStarted
    {
        get{return timeStarted;}
        set{timeStarted = value;}
    }
    public bool Complete
    {
        get{return complete;}
        set{complete = value;}
    }
    public DateOnly LastCompleted
    {
        get{return lastCompleted;}
        set{lastCompleted = value;}
    }
    public int GetPoints()
    {
        return points;
    }
    public virtual void DisplayTask(int index)
    {
        if(ShouldDisplay())
        {
            Console.WriteLine($"[{index}] {name} [{points}]");
        }
    }
    public void CompleteTask()
    {
        //Console.WriteLine("completed");
        lastCompleted = DateOnly.FromDateTime(DateTime.Now);
        complete = true;
    }
    private void CheckComplete()
    {
        currentTime = DateOnly.FromDateTime(DateTime.Now);
        if(!complete)
        {
            complete = false;
        } else if(lastCompleted != currentTime && (repeatTime == "daily" || repeatTime == "D"))
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