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
        users[currentUser].DisplayAllGoals();
        DisplayMenu();
    }
}