using System.Text.RegularExpressions;

class User
{
    List<Goal> goals = new List<Goal>{};
    string filePath;
    string name;
    int level;
    int xp;
    int numSimple;
    int numEternal;
    int numChecklist;
    public User(string filename)
    {
        filePath = @$"../../../users/{filename}";
        string [] userInfo = File.ReadAllLines(@$"{filePath}/userinfo.txt");
        name = userInfo[0];
        level = int.Parse(userInfo[1]);
        xp = int.Parse(userInfo[2]);
        string [] simpleGoals = File.ReadAllLines(@$"{filePath}/simple.txt");
        numSimple = simpleGoals.Length;
        for(int i = 0; i< simpleGoals.Length; i++)
        {
            string[] createSimple = simpleGoals[i].Split(",");
            goals.Add(new Simple(createSimple[0], int.Parse(createSimple[1]), int.Parse(createSimple[2])));
        }
        string [] eternalGoals = File.ReadAllLines(@$"{filePath}/eternal.txt");
        numEternal = eternalGoals.Length;
        for(int i = 0; i<eternalGoals.Length; i++)
        {
            string[] createEternal = eternalGoals[i].Split(",");
            goals.Add(new Eternal(createEternal[0], int.Parse(createEternal[1]), int.Parse(createEternal[2])));
        }
        string [] checklistGoals = File.ReadAllLines(@$"{filePath}/checklist.txt");
        numChecklist = checklistGoals.Length;
        for(int i = 0; i< checklistGoals.Length; i++)
        {
            string[] createChecklist = checklistGoals[i].Split(",");
            goals.Add(new Checklist(createChecklist[0], int.Parse(createChecklist[1]), int.Parse(createChecklist[2]), int.Parse(createChecklist[3]), int.Parse(createChecklist[4])));
        }
    }
    public void DisplayUserInfo()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"{name} - Level {level}");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("[");
        for(int i = 0; i<30*GetProgressBar(); i++)
        {
            Console.Write("*");
        }
        for(int i = 0; i<30*(1-GetProgressBar()); i++)
        {
            Console.Write("-");
        }
        Console.WriteLine("]");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void DisplayAllGoals()
    {
        Console.WriteLine("Simple Quests [S]:");
        for(int i = 0; i<numSimple; i++)
        {
            Console.Write($"[{i}] ");
            goals[i].DisplayGoal();
        }
        Console.WriteLine("Eternal Quests [E]:");
        for(int i = 0; i<numEternal; i++)
        {
            Console.Write($"[{i}]");
            goals[i+numSimple].DisplayGoal();
        }
        Console.WriteLine("Checklist Quests [C]: ");
        for(int i = 0; i< numChecklist; i++)
        {
            Console.Write($"[{i}]");
            goals[i+numSimple+numEternal].DisplayGoal();
        }
        Console.WriteLine("Input the letter, then the number, of the quest you would like to check off");
        QuestSelect();
    }
    private void QuestSelect()
    {
        string input = Console.ReadLine();
        string type = input.Substring(0,1).ToLower();
        int number = int.Parse(input.Substring(1));
        switch(type)
        {
            case "s":
                goals[number].CompleteQuest();
                break;
            case "e":
                goals[number+numSimple].CompleteQuest();
                break;
            case "c":
                goals[number+numSimple+numEternal].CompleteQuest();
                break;
            default:
                break;
        }
    }
    private double GetProgressBar()
    {
        return 0.5;
    }
}