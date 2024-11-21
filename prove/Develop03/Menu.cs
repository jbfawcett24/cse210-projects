using System.ComponentModel.DataAnnotations;

class Menu
{
    List<string> listInput = new List<string>();
    Scripture scripture = new Scripture("John", 3, 16, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life");
    public Menu()
    {
        scripture.ReplaceWords();
    }
    public void Display()
    {
        scripture.Display();
        Console.Write("input words missing (quit to exit): ");
        UserInput();
        if(CompareReplaced() == true)
        {
            Console.WriteLine("Correct");
            scripture.ReplaceWords();
        } else {
            Console.WriteLine("Wrong");
        }
    }
    public void UserInput()
    {
        string userInput = Console.ReadLine();
        if(userInput == "quit")
        {
            Environment.Exit(0);
        } else {
            InputToList(userInput);
        }
    }
    private void InputToList(string input)
    {
        if(listInput.Count > 0)
        {
            listInput.Clear();
        }
        listInput = input.Split(" ").ToList();
    }
    private bool CompareReplaced()
    {
        bool correct = false;
        if(listInput.Count  == scripture.GetReplaced().Count)
        {
            correct = true;
            for(int i = 0; i<listInput.Count; i++)
            {
                if(listInput[i] != scripture.GetReplaced()[i])
                {
                    correct = false;
                }
            }
        }
        return correct;
    }
    public void StartUp()
    {
        Console.Clear();
        Console.WriteLine(scripture.GetVerse());
        Console.ReadLine();
    }
}