using System.Text.RegularExpressions;

class User
{
    List<Goal> goals = new List<Goal>{};
    List<Goal> completeGoals = new List<Goal>{};
    string filePath;
    string name;
    int level;
    int xp;
    int numSimple;
    int numEternal;
    int numChecklist;
    int numSimpleComplete = 0;
    int numChecklistComplete = 0;
    int xpToLevelUp;
    public User(string filename)
    {
        filePath = @$"../../../users/{filename}";
        string [] userInfo = File.ReadAllLines(@$"{filePath}/userinfo.txt");
        name = userInfo[0];
        level = int.Parse(userInfo[1]);
        xp = int.Parse(userInfo[2]);
        xpToLevelUp = (level*50)+50;
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
        Console.WriteLine($"] {xp}/{xpToLevelUp}");
        Console.ForegroundColor = ConsoleColor.White;
    }
    public void DisplayAllGoals()
    {
        Console.WriteLine("Simple Quests [S]:");
        for(int i = 0; i<numSimple; i++)
        {
            Console.Write($"[{i}] [");
            if(goals[i].GetFinished())
            {
                Console.Write("x");
            } else {
                Console.Write(" ");
            }
            Console.Write("] ");
            goals[i].DisplayGoal();
        }
        Console.WriteLine("Eternal Quests [E]:");
        for(int i = 0; i<numEternal; i++)
        {
            Console.Write($"[{i}] ");
            goals[i+numSimple].DisplayGoal();
        }
        Console.WriteLine("Checklist Quests [C]: ");
        for(int i = 0; i< numChecklist; i++)
        {
            Console.Write($"[{i}] [");
            if(goals[i+numSimple+numEternal].GetFinished())
            {
                Console.Write("x");
            } else {
                Console.Write(" ");
            }
            Console.Write("] ");
            goals[i+numSimple+numEternal].DisplayGoal();
        }
        Console.WriteLine("Input the letter, then the number, of the quest you would like to check off (quit to exit)");
        QuestSelect();
    }
    private void QuestSelect()
    {
        string input = Console.ReadLine();
        string type;
        int number = -1;
        if(input.Length<=1)
        {
            return;
        } else
        {
            type = input.Substring(0,1).ToLower();
            try 
            {
            number = int.Parse(input.Substring(1));
            } catch 
            {
                QuestSelect();
            }
            switch(type)
            {
                case "s":
                    if(number<numSimple&&number>=0&&goals[number].GetFinished() == false)
                    {
                        goals[number].CompleteQuest();
                        SetXp(goals[number].GetPoints());
                        Console.ReadLine();
                        AddCompleteGoals();
                        CheckLevel();
                    } else {
                        return;
                    }
                    break;
                case "e":
                    if(number<numEternal)
                    {
                        goals[number+numSimple].CompleteQuest();
                        SetXp(goals[number+numSimple].GetPoints());
                        Console.ReadLine();
                        CheckLevel();
                    } else {
                        return;
                    }
                    break;
                case "c":
                    if(number<numChecklist)
                    {
                        goals[number+numSimple+numEternal].CompleteQuest();
                        SetXp(goals[number+numSimple+numEternal].GetPoints());
                        if(goals[number+numSimple+numEternal].GetFinished())
                        {
                            SetXp(goals[number+numSimple+numEternal].GetFinishedPoints());
                        }
                        AddCompleteGoals();
                        Console.ReadLine();
                        CheckLevel();
                    } else {
                        return;
                    }
                    break;
                default:
                    return;
            }
        }
    }
    
    private void AddCompleteGoals()
    {
        for(int i = 0; i<goals.Count; i++)
        {
            if(goals[i].GetFinished())
            {
                completeGoals.Add(goals[i]);
                goals.RemoveAt(i);
                if(i<numSimple)
                {
                    numSimple--;
                    numSimpleComplete++;
                } else if(i>=numEternal && i<numChecklist)
                {
                    numChecklist--;
                    numChecklistComplete++;
                }
            }
        }
    }
    public void DisplayAllComplete()
    {
        if(completeGoals.Count>0)
        {
            Console.WriteLine("Simple Quests:");
            for(int i = 0; i<numSimpleComplete; i++)
            {
                completeGoals[i].DisplayGoal();
            }
            Console.WriteLine("Checklist Quests: ");
            for(int i = 0; i< numChecklistComplete; i++)
            {
                completeGoals[i+numSimpleComplete].DisplayGoal();
            }
            Console.ReadLine();
        } else 
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("No complete goals, how dare you");
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    public void CreateNewGoal()
    {
        Console.WriteLine("What type of Goal");
        Console.WriteLine("[0] Simple Goal");
        Console.WriteLine("[1] Eternal Goal");
        Console.WriteLine("[2] Checklist Goal");
        string input = Console.ReadLine();
        switch(input)
        {
            case "0":
                CreateSimple();
                break;
            case "1":
                CreateEternal();
                break;
            case "2":
                CreateChecklist();
                break;
        }
    }
    private void CreateSimple()
    {

    }
    private void CreateEternal()
    {

    }
    private void CreateChecklist()
    {

    }
    private double GetProgressBar()
    {
        return (double)xp/xpToLevelUp;
    }
    private void SetXp(int points)
    {
        xp+=points;
    }
    private void CheckLevel()
    {
        if(xp>=xpToLevelUp)
        {
            level++;
            xp-=xpToLevelUp;
            Console.WriteLine("Level Up!");
            xpToLevelUp += 50;
            Console.ReadLine();
        }
    }
}