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
        users[currentUser].saveUserData();
    }
}