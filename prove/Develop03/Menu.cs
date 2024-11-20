using System.ComponentModel.DataAnnotations;

class Menu
{
    List<string> listInput = new List<string>();
    Scripture scripture = new Scripture("John", 3, 16, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life");
    public Menu()
    {
        scripture.words.ReplaceWords();
    }
    public void Display()
    {
        scripture.Display();
        UserInput();
        if(CompareReplaced() == true)
        {
            Console.WriteLine("Correct");
            scripture.words.ReplaceWords();
        } else {
            Console.WriteLine("Wrong");
        }
    }
    public void UserInput()
    {
        InputToList(Console.ReadLine());
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
        if(listInput.Count  == scripture.words.GetReplaced().Count)
        {
            correct = true;
            for(int i = 0; i<listInput.Count; i++)
            {
                if(listInput[i] != scripture.words.GetReplaced()[i])
                {
                    correct = false;
                }
            }
        }
        return correct;
    }
}