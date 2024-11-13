class Menu
{
    private string userInput;
    Journal journal = new Journal();
    public void Display()
    {
        Console.Write($"[1] Add New Entry\n[2] Save to File\n[3] Load File\n[4] Display All Entries\n[5] Quit\n\nInput number here: ");
        userInput = Console.ReadLine();
            if(userInput == "1")
            {
                journal.addNew();
            } else if (userInput == "2")
            {
                journal.Save();
            } else if(userInput == "3")
            {
                journal.LoadNew();
            } else if(userInput == "4")
            {
                journal.Display();
            } else if(userInput == "5")
            {
                journal.Quit();
            }
    }
    public void StartUp()
    {
        journal.StartUp();
    }
}