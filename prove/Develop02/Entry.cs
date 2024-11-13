using System.ComponentModel;

class Entry
{
    DateTime date = DateTime.Now;
    private string dateText;
    private string entry;
    private string prompt;

    public Entry(string prompt, string entry)
    {
        date = DateTime.Now;
        dateText = date.ToShortDateString();
        this.prompt = prompt;
        this.entry = entry;
    }
    public void Display()
    {
        Console.WriteLine($"{dateText}: {prompt}\n{entry}");
    }
    public string getDate()
    {
        return dateText;
    }
}