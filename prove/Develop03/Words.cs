using System.Runtime.InteropServices;
using System.Text;

class Words
{
    static string[] words;
    List<string> replacedWords = new List<string>();
    string[] displayWords;
    List<int> removedNum = new List<int>();
    int numWordsReplaced;
    int startReplaced = 3;
    Random randWord = new Random();
    public Words(string scripture)
    {
        words = scripture.Split(" ");
        displayWords = words;
    }
    public void ReplaceWords()
    {
        displayWords = (string[])words.Clone();
        if(numWordsReplaced > words.Length - removedNum.Count() && words.Length - removedNum.Count() != 0)
        {
            numWordsReplaced = words.Length-removedNum.Count();
        } else {
            numWordsReplaced = startReplaced;
        }
        for(int i = 0; i<numWordsReplaced; i++)
        {
            removedNum.Add(RandWords());
        }
        removedNum.Sort();
        replacedWords.Clear();
        for(int i = 0; i<removedNum.Count; i++)
        {
            replacedWords.Add(words[removedNum[i]]);
            displayWords[removedNum[i]] = DashWords(displayWords[removedNum[i]]);
        }
        //Console.WriteLine("replaced");
    }
    private int RandWords()
    {
        if(removedNum.Count() != words.Length)
        {
            int rand;
            do
            {
                rand = randWord.Next(0, words.Length);
            } while (removedNum.Contains(rand));
            return rand;
        } else {
            Finished();
            return 0;
        }
    }
    private string DashWords(string word){
        StringBuilder dashedWord = new StringBuilder();
        for(int i = 0; i<word.Length; i++)
        {
            dashedWord.Append("_");
        }
        return dashedWord.ToString();
    }
    public void Display()
    {
        for(int i = 0; i<displayWords.Length; i++)
        {
            Console.Write($"{displayWords[i]} ");
        }
        Console.WriteLine();
        // for(int i = 0; i<replacedWords.Count;i++)
        // {
        //     Console.Write($"{replacedWords[i]} ");
        // }
        // Console.WriteLine();
    }
    public List<string> GetReplaced()
    {
        return replacedWords;
    }
    private void Finished()
    {
        Console.WriteLine("Congrats, you finished the scripture. Type quit to quit, or press enter to try again");
        string userInput = Console.ReadLine();
        if(userInput == "quit")
        {
            Environment.Exit(0);
        } else {
            replacedWords.Clear();
            removedNum.Clear();
        }
    }
}