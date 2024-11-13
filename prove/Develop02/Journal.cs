using System.ComponentModel.Design;
using System.Transactions;

class Journal
{
    List<Entry> entries = new List<Entry>();
    List<string> prompts = new List<string>{"food", "beans"};
    Random rand = new Random();
    private DateTime date = DateTime.Now;
    private bool saved = true;
    private string filename;
    public void Display()
    {
        if(entries.Count>0)
        {
            Console.WriteLine($"{entries[0].GetDate()} - {entries[^1].GetDate()}");
            for(int i = 0; i < entries.Count(); i++)
            {
                entries[i].Display();
            }
            Console.ReadLine();
        } else {
            Console.WriteLine("Please add an entry first");
            Console.ReadLine();
        }
        Console.Clear();
    }
    public void addNew()
    {
        int prompt = RandPrompt();
        Console.Write($"{prompts[prompt]}\n> ");
        string dateText = date.ToShortDateString();
        entries.Add(new Entry(prompts[prompt], Console.ReadLine(), dateText));
        saved = false;
        Console.Clear();
    }
    private int RandPrompt()
    {
        return rand.Next(0,prompts.Count());
    }
    public void Save()
    {
        using(StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine(entry.GetDate());
                writer.WriteLine(entry.GetPrompt());
                writer.WriteLine(entry.GetEntry());
                writer.WriteLine();
            }
            Console.WriteLine("Saved to file.\n");
            saved = true;
            Console.ReadLine();
            Console.Clear();
        }
    }
    public void Load()
    {
        if(entries.Count<=0)
        {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        for(int i = 0; i<lines.Length; i+=4){
            string date = lines[i];
            string prompt = lines[i+1];
            string entryText = lines[i+2];
            entries.Add(new Entry(prompt, entryText, date));
        }
        Console.WriteLine("File loaded\n");
        Console.ReadLine();
        } else 
        {
            Console.WriteLine("You have unsaved jounral entries. Would you like to save the entries before loading the file? (Y/N)");
            string selection = Console.ReadLine();
            if(selection.ToLower() == "n")
            {
                entries.Clear();
                string[] lines = File.ReadAllLines(filename);
                for(int i = 0; i<lines.Length; i+=4){
                    string date = lines[i];
                    string prompt = lines[i+1];
                    string entryText = lines[i+2];
                    entries.Add(new Entry(prompt, entryText, date));
                }
                Console.WriteLine("File loaded\n");
                Console.ReadLine();
            } else {
                Save();
            }
            Console.Clear();
        }
    }
    public void Quit()
    {
        if(saved == true)
        {
            Environment.Exit(0);
        } else 
        {
            Console.WriteLine("you have unsaved journal entries. Would you like to save them before quitting? (Y/N)");
            string selection = Console.ReadLine();
            if(selection.ToLower() == "n")
            {
                Environment.Exit(0);
            } else {
                Save();
            }
        }
    }
    public void StartUp()
    {
        Console.WriteLine("Input the name of the file you would like to save to");
        filename = Console.ReadLine();
        Load();
    }
    public void LoadNew(){
        Console.WriteLine("Input name of file to load:");
        filename = Console.ReadLine();
        Load();
    }
}