using System.Drawing;
using System.Reflection.Metadata.Ecma335;

class User
{
    Pet pet;
    List<Task> schoolTasks = new List<Task>{};
    List<Task> physicalTasks = new List<Task>{};
    List<Task> mentalTasks = new List<Task>{};
    string name;
    public User(string name)
    {
        this.name = name;
        string petInfo = File.ReadAllText(@$"../../../{name}/pet.pet");
        string[] petList = petInfo.Split(",");
        ConsoleColor color;
        Enum.TryParse<ConsoleColor>(petList[1], out color);
        switch(petList[8])
        {
            case "Dog":
                pet = new Dog(petList[0], color, int.Parse(petList[2]), int.Parse(petList[3]), int.Parse(petList[4]), int.Parse(petList[5]), int.Parse(petList[6]), int.Parse(petList[7]), petList[8]);
                break;
        }
        LoadAll();
    }
    public User(string name, ConsoleColor color, string type)
    {
        this.name = name;
        switch(type)
        {
            case "dog":
                pet = new Dog(name, color, type);
                break;
            case "cat":
                pet = new Cat(name, color, type);
                break;
            case "fish":
                pet = new Fish(name, color, type);
                break;
        }
    }
    public Pet Pet
    {
        get{return pet;}
        set{pet = value;}
    }
    public List<Task> SchoolTasks
    {
        get{return schoolTasks;}
        set{schoolTasks = value;}
    }
    public List<Task> PhysicalTasks
    {
        get{return physicalTasks;}
        set{physicalTasks = value;}
    }
    public List<Task> MentalTasks
    {
        get{return mentalTasks;}
        set{mentalTasks = value;}
    }
    public string Name
    {
        get{return name;}
        set{name = value;}
    }
    public void DisplayUserInfo()
    {
        pet.DisplayAnimal();
        Console.WriteLine("School Tasks (S)");
        for(int i = 0; i<schoolTasks.Count; i++)
        {
            schoolTasks[i].DisplayTask(i);
        }
        Console.WriteLine("Physical Tasks (P)");
        for(int i = 0; i<physicalTasks.Count; i++)
        {
            physicalTasks[i].DisplayTask(i);
        }
        Console.WriteLine("Mental Tasks (M)");
        for(int i = 0; i<mentalTasks.Count; i++)
        {
            mentalTasks[i].DisplayTask(i);
        }
    }
    public void LoadAll()
    {
        schoolTasks = Save.LoadTask("schoolTasks", name);
        physicalTasks = Save.LoadTask("physicalTasks", name);
        mentalTasks = Save.LoadTask("mentalTasks", name);
    }
    public void SaveAll()
    {
        Save.SaveTask(schoolTasks, "schoolTasks", name);
        Save.SaveTask(physicalTasks, "physicalTasks", name);
        Save.SaveTask(mentalTasks, "mentalTasks", name);
        string color = pet.GetStringColor();
        File.WriteAllText($"../../../{name}/pet.pet", $"{pet.Name},{pet.Color},{pet.SmartLevel},{pet.SmartXp},{pet.HealthLevel},{pet.HealthtXp},{pet.HappinessLevel},{pet.HappinessXp},{pet.GetType()}");
    }
    public void CheckTasks(string letter, int index)
    {
        switch(letter)
                {
                    case "S":
                        schoolTasks[index].CompleteTask();
                        pet.AddSmartXp(schoolTasks[index].GetPoints());
                        if(schoolTasks[index].RepeatTime == "single")
                        {
                            schoolTasks.RemoveAt(index);
                        }
                        break;
                    case "P":
                        physicalTasks[index].CompleteTask();
                        pet.AddHealthXp(physicalTasks[index].GetPoints());
                        if(physicalTasks[index].RepeatTime == "single")
                        {
                            physicalTasks.RemoveAt(index);
                        }
                        break;
                    case "M":
                        mentalTasks[index].CompleteTask();
                        pet.AddHappyXp(mentalTasks[index].GetPoints());
                        if(mentalTasks[index].RepeatTime == "single")
                        {
                            mentalTasks.RemoveAt(index);
                        }
                        break;
                    default:
                        break;
                }
    }
    public void CreateNewTask()
    {
        Console.Write("What is tha name of the Task: ");
        string name = Console.ReadLine();
        bool isInt = false;
        string repeatTime;
        int points = 0;
        do
        {
            Console.Write("How many points should this be worth (recomended 50-200): ");
            string stringPoints = Console.ReadLine();
            try 
            {
                points = int.Parse(stringPoints);
                isInt = true;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please input a number");
            }
        } while(isInt == false);
        Console.Write("Should this be a Daily task (D), or a single use task (S)");
        string repeatSelect = Console.ReadLine();
        if(repeatSelect.ToLower() == "d")
        {
            repeatTime = "daily";
        } else {
            repeatTime = "single";
        }
        Console.Write("Is this a School (S), Physical (P), or Mental (M) task: ");
        string type = Console.ReadLine();
        switch(type.ToLower())
        {
            case "s":
                schoolTasks.Add(new Task(name, repeatTime, points, Menu.GetTime(), false));
                break;
            case "p":
                physicalTasks.Add(new Task(name, repeatTime, points, Menu.GetTime(), false));
                break;
            case "m":
                mentalTasks.Add(new Task(name, repeatTime, points, Menu.GetTime(), false));
                break;
        }
    }
    public void AddStudyPoints(int minutes)
    {
        pet.AddSmartXp(minutes*10);
    }
}