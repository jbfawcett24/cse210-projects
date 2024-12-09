class Menu
{
    List<string> usersList = File.ReadLines(@"../../../users.txt").ToList();
    List<User> users = new List<User>{};
    int currentUser = 0;
    public Menu()
    {
        for(int i = 0; i < usersList.Count; i++)
        {
            users.Add(new User(usersList[i]));
        }
    }
    public void StartUp()
    {
        Console.Clear();
        Console.WriteLine("Chose your profile");
        Console.WriteLine("[0] Create New");
        for(int i = 0; i<users.Count; i++)
        {
            Console.WriteLine($"[{i+1}] {users[i].GetName()}");
        }
        string input = Console.ReadLine();
        if(input!="0")
        {
            try
            {
                currentUser = int.Parse(input)-1;
            }
            catch
            {
                StartUp();
            }
        } else {
            CreateNewUser();
        }
    }
    public void DisplayMenu()
    {
        Console.Clear();
        users[currentUser].DisplayUserInfo();
        Console.WriteLine($"   [0] View and complete current Quests");
        Console.WriteLine($"   [1] View Completed Quests");
        Console.WriteLine($"   [2] Add new Quest");
        Console.WriteLine($"   [3] Switch User");
        Console.WriteLine($"   [4] Quit");
        ProcessUserInput();
    }
    private void DisplayMenuQuests()
    {
        Console.Clear();
        users[currentUser].DisplayUserInfo();
        users[currentUser].DisplayAllGoals();
        DisplayMenu();
    }
    private void DisplayMenuComplete()
    {
        Console.Clear();
        users[currentUser].DisplayUserInfo();
        users[currentUser].DisplayAllComplete();
        DisplayMenu();
    }
    private void ProcessUserInput()
    {
        string input = Console.ReadLine();
        switch(input)
        {
            case "0":
                DisplayMenuQuests();
                break;
            case "1":
                DisplayMenuComplete();
                break;
            case "2":
                users[currentUser].CreateNewGoal();
                break;
            case "3":
                StartUp();
                break;
            case "4":
                Save();
                Environment.Exit(0);
                break;
        }
        DisplayMenu();
    }
    public void Save()
    {
        using(StreamWriter writer = new StreamWriter(@"../../../users.txt"))
        {
            foreach(User user in users)
            {
                writer.WriteLine(user.GetName());
            }
        }
        users[currentUser].saveUserData();
    }
    private void CreateNewUser()
    {
        Console.Write("Input Name of user: ");
        string userName = Console.ReadLine();
        if(usersList.Contains(userName))
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("User already created");
            Console.ForegroundColor = ConsoleColor.White;
            CreateNewUser();
            return;
        }
        string userDirectory = @$"../../../users/{userName}";
        System.IO.Directory.CreateDirectory(userDirectory);
        string userInfoPath = @$"{userDirectory}/userInfo.txt";
        using (var simpleFile = System.IO.File.Create($"{userDirectory}/simple.txt")) { }
        using (var eternalFile = System.IO.File.Create($"{userDirectory}/eternal.txt")) { }
        using (var checklistFile = System.IO.File.Create($"{userDirectory}/checklist.txt")) { }
        using (StreamWriter writer = new StreamWriter(userInfoPath))
        {
            writer.WriteLine(userName);
            writer.WriteLine("0");
            writer.WriteLine("0");
        }
        using(StreamWriter writer = new StreamWriter("../../../users.txt"))
        {
            writer.WriteLine(userName);
        }
        users.Add(new User(userName));
        usersList.Add(userName);
        Save();
        currentUser = usersList.Count-1;
    }
}