using System.Diagnostics.CodeAnalysis;

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
        users[currentUser].DisplayUserInfo();
        Console.WriteLine("Input the letter and number of the task you would like to check off.\nInput 'new' to create a new task");
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
                users[currentUser].CheckTasks(letter, index);
                break;
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
}