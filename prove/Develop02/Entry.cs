using System.ComponentModel;

class Entry
{
    DateTime date = DateTime.Now;
    private string dateText;
    private string entry;
    private string prompt;

    public Entry(string prompt, string entry, string date)
    {
        dateText = date;
        this.prompt = prompt;
        this.entry = entry;
    }
    public void Display()
    {
        Console.WriteLine($"{dateText}: {prompt}\n{entry}");
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
}