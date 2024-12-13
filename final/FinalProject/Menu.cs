using System.Diagnostics.CodeAnalysis;

class Menu
{
    Pet pet = new Dog("jeff", ConsoleColor.DarkCyan);
    List<Task> schoolTasks = new List<Task>{};
    List<Task> physicalTasks = new List<Task>{};
    List<Task> mentalTasks = new List<Task>{};
    DateOnly time = new DateOnly();
    public Menu()
    {
        SetCurrentTime();
        LoadAll();
    }
    public void SetCurrentTime()
    {
        time = DateOnly.FromDateTime(DateTime.Now);
    }
    public DateOnly GetTime()
    {
        SetCurrentTime();
        return time;
    }
    public void DisplayMenu()
    {
        pet.DisplayAnimal();
        Console.WriteLine("School Tasks");
        foreach(Task task in schoolTasks)
        {
            task.DisplayTask();
        }
        Console.WriteLine("Physical Tasks");
        Console.WriteLine("Mental Tasks");
        Console.WriteLine("Input the letter and number of the task you would like to check off.\nInput 'new' to create a new task");
        ProcessInput();
        SaveAll();
        DisplayMenu();
    }
    private void ProcessInput()
    {
        string input = Console.ReadLine();
        switch(input)
        {
            case "new":
                CreateNewTask();
                break;
            default:
                string letter = input.Substring(0,1).ToUpper();
                int index = 0;
                try
                {
                    index =  int.Parse(input.Substring(1));
                    Console.WriteLine(index);
                } catch
                {
                    Console.WriteLine("Input a valid Task");
                    DisplayMenu();
                    return;
                }
                switch(letter)
                {
                    case "S":
                        schoolTasks[index].CompleteTask();
                        pet.AddSmartXp(schoolTasks[index].GetPoints());
                        Console.WriteLine($"School {index}");
                        break;
                    case "P":
                        physicalTasks[index].CompleteTask();
                        pet.AddHealthXp(schoolTasks[index].GetPoints());
                        Console.WriteLine($"Physical {index}");
                        break;
                    case "M":
                        mentalTasks[index].CompleteTask();
                        pet.AddHappyXp(mentalTasks[index].GetPoints());
                        Console.WriteLine("Mental");
                        break;
                    default:
                        break;
                }
                break;
        }
    }
    private void CreateNewTask()
    {
        Console.Write("What is tha name of the Task: ");
        string name = Console.ReadLine();
        Console.Write("How often should this repeat, Daily (D) or Weekly (W)");
        string repeatTimeInput = Console.ReadLine();
        string repeatTime;
        if(repeatTimeInput.ToLower() == "d")
        {
            repeatTime = "daily";
            Console.WriteLine(repeatTime);
        } else 
        {
            repeatTime = "weekly";
        }
        bool isInt = false;
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

        Console.Write("Is this a School (S), Physical (P), or Mental (M) task: ");
        string type = Console.ReadLine();
        switch(type.ToLower())
        {
            case "s":
                schoolTasks.Add(new Task(name, repeatTime, points, GetTime(), false));
                break;
        }
    }
    public void SaveAll()
    {
        Save.SaveTask(schoolTasks, "schoolTasks");
    }
    public void LoadAll()
    {
        schoolTasks = Save.LoadTask("schoolTasks");
    }
}