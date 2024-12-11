class Menu
{
    Pet pet = new Dog("jeff", ConsoleColor.DarkCyan);
    List<Task> schoolTasks = new List<Task>{};
    List<Task> physicalTasks = new List<Task>{};
    List<Task> mentalTasks = new List<Task>{};
    DateOnly time = new DateOnly();
    public Menu()
    {
        schoolTasks.Add(new School("hello", "daily", 100, time, true));
    }
    public void SetTime()
    {
        time = DateOnly.FromDateTime(DateTime.Now);
    }
    public void GetTime()
    {

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
        DisplayMenu();
    }
    private void ProcessInput()
    {
        string input = Console.ReadLine();
        switch(input)
        {
            case "new":
                Console.WriteLine("not done");
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
}