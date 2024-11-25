using System.Runtime.InteropServices;

class Writing : Assignment
{
    string title;
    public Writing(string title, string studentName, string topic) : base(studentName, topic)
    {
        this.title = title;
    }
    public string GetWritingInfo()
    {
        return $"{title} by {GetName()}";
    }
}