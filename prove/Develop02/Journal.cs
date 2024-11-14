using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Transactions;

class Journal
{
    List<Entry> entries = new List<Entry>();
    Random rand = new Random();
    private DateTime date = DateTime.Now;
    private bool saved = true;
    private string filename;
    private string[] promptsList;
    public void Display()
    {
        if(entries.Count>0)
        {
            Console.Clear();
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
        Console.Write($"{promptsList[prompt]}\n> ");
        string dateText = date.ToShortDateString();
        string day = date.ToString("ddd");
        entries.Add(new Entry(promptsList[prompt], Console.ReadLine(), dateText, day));
        saved = false;
        Console.Clear();
    }
    private int RandPrompt()
    {
        return rand.Next(0,promptsList.Length);
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
                writer.WriteLine(entry.GetDay());
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
        if(entries.Count<=0 || saved == true)
        {
            entries.Clear();
            string[] lines = File.ReadAllLines(filename);
            for(int i = 0; i<lines.Length; i+=5){
                string date = lines[i];
                string prompt = lines[i+1];
                string entryText = lines[i+2];
                string day = lines[i+3];
                entries.Add(new Entry(prompt, entryText, date, day));
            }
            Console.WriteLine("File loaded\n");
            Console.ReadLine();
            Console.Clear();
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
                    string day = lines[i+3];
                    entries.Add(new Entry(prompt, entryText, date, day));
                }
                Console.WriteLine("File loaded\n");
                Console.ReadLine();
                Console.Clear();
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
                Environment.Exit(0);
            }
        }
    }
    public void StartUp()
    {
        Console.WriteLine("Welcome to the Journaling Software");
        CreatePrompts();
        LoadNew();
    }
    public void LoadNew(){
        if(saved == true)
        {
            Console.WriteLine("Input name of file to load:");
            filename = Console.ReadLine();
            if(!File.Exists(filename))
            {
                using(FileStream fs = File.Create(filename))
                {
                    Console.WriteLine("File created, entries will be saved here.");
                    Console.ReadLine();
                    Console.Clear();
                }
            } else {
                Load();
            }
        } else 
        {
            Console.WriteLine("You have unsaved jounral entries. Would you like to save the entries before loading the file? (Y/N)");
            string selection = Console.ReadLine();
            if(selection.ToLower() == "n")
            {
                saved = true;
                LoadNew();
            } else {
                Save();
                LoadNew();
            }
        }
    }
    private void CreatePrompts()
    {
        promptsList = File.ReadAllLines("prompts.txt");
        Console.WriteLine(promptsList.Length);
    }
}