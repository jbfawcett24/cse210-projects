class Journal
{
    List<Entry> entries = new List<Entry>();
    List<string> prompts = new List<string>{"food", "beans"};
    Random rand = new Random();
    public void Display()
    {
        Console.WriteLine($"{entries[0].getDate()} - {entries[^1].getDate()}");
        for(int i = 0; i < entries.Count(); i++)
        {
            entries[i].Display();
        }
        Console.ReadLine();
    }
    public void addNew()
    {
        int prompt = RandPrompt();
        Console.Write($"{prompts[prompt]}\n> ");
        entries.Add(new Entry(prompts[prompt], Console.ReadLine()));

    }
    private int RandPrompt()
    {
        return rand.Next(0,prompts.Count());
    }

    public string Menu()
    {
        Console.Write($"[1] Add New Entry\n[2] Save to File\n[3] Load File\n[4] Display All Entries\n\nInput number here: ");
        return Console.ReadLine();
    }
    public void Save()
    {
        Console.WriteLine("not done :/");
    }
    public void Load()
    {
        Console.WriteLine("not deon :/");
    }
}