using System.ComponentModel.DataAnnotations;

class Menu
{
    string[] listInput;
    Scripture scripture = new Scripture("John", 3, 16, "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life");
    public void Display()
    {
        scripture.words.ReplaceWords();
        scripture.Display();
        UserInput();
        if(CompareReplaced() == true)
        {
            Console.WriteLine("Correct");
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
        listInput = input.Split(" ");
    }
    private bool CompareReplaced()
    {
        if(listInput.Length == scripture.words.GetReplaced().Count)
        {
            for(int i = 0; i<listInput.Length; i++)
            {
                if(listInput[i] != scripture.words.GetReplaced()[i])
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }
}