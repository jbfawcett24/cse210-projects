using System.ComponentModel;

class Entry
{
    DateTime date = DateTime.Now;
    private string dateText;
    private string day;
    private string entry;
    private string prompt;

    public Entry(string prompt, string entry, string date, string day)
    {
        dateText = date;
        this.day = day;
        this.prompt = prompt;
        this.entry = entry;
    }
    public void Display()
    {
        Console.WriteLine($"{dateText} - {day}: {prompt}\n{entry}");
    }
    public string GetDate()
    {
        return dateText;
    }
    public string GetPrompt()
    {
        return prompt;
    }
    public string GetEntry()
    {
        return entry;
    }
    public string GetDay()
    {
        return day;
    }
}