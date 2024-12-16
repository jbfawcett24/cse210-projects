using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

class Menu
{
    List<string> userNames = File.ReadAllLines("../../../users.txt").ToList();
    List<User> users = new List<User>{};
    DateOnly time = new DateOnly();
    int currentUser;
    public Menu()
    {
        SetCurrentTime();
        Console.WriteLine("Select your user");
        for(int i = 0; i<userNames.Count; i++)
        {
            Console.WriteLine($"[{i}] {userNames[i]}");
            users.Add(new User(userNames[i]));
        }
        string userSelectStr = Console.ReadLine();
        bool isInt = false;
        do
        {
            try
            {
                currentUser = int.Parse(userSelectStr);
                isInt = true;
            }
            catch
            {
                Console.WriteLine("please select a valid user");
            }
        } while (isInt == false);
        DisplayMenu();
    }
    private void SetCurrentTime()
    {
        time = DateOnly.FromDateTime(DateTime.Now);
    }
    public static DateOnly GetTime()
    {
        return DateOnly.FromDateTime(DateTime.Now);
    }
    public void DisplayMenu()
    {
        Console.Clear();
        users[currentUser].DisplayUserInfo();
        Console.WriteLine("Input the letter and number of the task you would like to check off.\nInput 'new' to create a new task, 'quit' to exit, 'study' to start a study timer, or 'switch' to change pet");
        ProcessInput();
        users[currentUser].SaveAll();
        DisplayMenu();
    }
    private void ProcessInput()
    {
        string input = Console.ReadLine();
        switch(input)
        {
            case "new":
                users[currentUser].CreateNewTask();
                break;
            case "quit":
                Save();
                Environment.Exit(0);
                break;
            case "switch":
                ChangeUser();
                break;
            case "study":
                StudyTimer();
                break;
            default:
                string letter = input.Substring(0,1).ToUpper();
                int index = 0;
                try
                {
                    index =  int.Parse(input.Substring(1));
                    //Console.WriteLine(index);
                } catch
                {
                    Console.WriteLine("Input a valid Task");
                    DisplayMenu();
                    return;
                }
                users[currentUser].CheckTasks(letter, index);
                break;
        }
    }
    private void ChangeUser()
    {
        Console.WriteLine("Select your user, 'new' to create a new user");
        for(int i = 0; i<userNames.Count(); i++)
        {
            Console.WriteLine($"[{i}] {userNames[i]}");
        }
        string input = Console.ReadLine();
        if(input == "new")
        {
            CreateNewUser();
        } else {
            int currentUser = int.Parse(input);
        }
    }
    public void StartUp()
    {
        Console.WriteLine("Select your user");
        for(int i = 0; i<userNames.Count; i++)
        {
            Console.WriteLine($"[{i}] {userNames[i]}");
        }
        string userSelectStr = Console.ReadLine();
        bool isInt = false;
        do
        {
            try
            {
                currentUser = int.Parse(userSelectStr);
                isInt = true;
            }
            catch
            {
                Console.WriteLine("please select a valid user");
            }
        } while (isInt == false);
    }
    private void CreateNewUser()
    {
        Console.Clear();
        Console.WriteLine("what is the name of your pet");
        string name = Console.ReadLine();
        System.IO.Directory.CreateDirectory($"../../../{name}");
        Console.Clear();
        ConsoleColor[] colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
        foreach (ConsoleColor colour in colors)
        {
            Console.ForegroundColor = colour;
            Console.WriteLine(colour.ToString());
        }
        Console.ResetColor();
        Console.WriteLine("\nEnter your chosen color:");
        ConsoleColor color = ConsoleColor.White;
        string userChoice = Console.ReadLine();
        if (Enum.TryParse<ConsoleColor>(userChoice, true, out ConsoleColor selectedColor))
        {
            color = selectedColor;
            Console.WriteLine($"\nYou selected {selectedColor}.");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nInvalid color selection.");
        }
        bool animalSelect = false;
        do
        {
            Console.WriteLine("What type on animal do you want your pet to be?\n[0] Dog\n[1] Cat\n[2] Fish");
            string animalType = Console.ReadLine();
            switch(animalType)
            {
                case "0":
                    users.Add(new User(name, color, "dog"));
                    userNames.Add(name);
                    currentUser = users.Count -1;
                    animalSelect = true;
                    break;
                case "1":
                    users.Add(new User(name, color, "cat"));
                    userNames.Add(name);
                    currentUser = users.Count-1;
                    animalSelect = true;
                    break;
                case "2":
                    users.Add(new User(name, color, "fish"));
                    userNames.Add(name);
                    currentUser = users.Count-1;
                    animalSelect = true;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Please input a valid number");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        } while(animalSelect == false);
        
    }
    private void Save()
    {
        users[currentUser].SaveAll();
        File.WriteAllLines("../../../users.txt", userNames);
    }
    private void StudyTimer()
    {
        Console.WriteLine("Enter the study time in minutes (You will recieve Smart Xp equal to 10x the amount of minutes studied):");
        if (int.TryParse(Console.ReadLine(), out int minutes) && minutes > 0)
        {
            int totalSeconds = minutes * 60;

            Console.WriteLine("Study timer started!");
            for (int remaining = totalSeconds; remaining >= 0; remaining--)
            {
                Console.Clear();
                TimeSpan time = TimeSpan.FromSeconds(remaining);
                //users[currentUser].DisplayUserInfo();
                Console.WriteLine($"Time Remaining: {time.ToString(@"mm\:ss")}");
                Thread.Sleep(1000);
            }

            Console.Clear();
            Console.WriteLine("Time's up! Good job studying!");
            users[currentUser].AddStudyPoints(minutes);
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}