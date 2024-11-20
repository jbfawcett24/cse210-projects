using System.Runtime.InteropServices;
using System.Text;

class Words
{
    static string[] words;
    List<string> replacedWords = new List<string>();
    string[] displayWords;
    List<int> removedNum = new List<int>();
    int numWordsReplaced = 1;
    Random randWord = new Random();
    public Words(string scripture)
    {
        words = scripture.Split(" ");
        displayWords = words;
    }
    public void ReplaceWords()
    {
        displayWords = (string[])words.Clone();
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
        Console.WriteLine("replaced");
    }
    private int RandWords()
    {
        int rand;
        do
        {
            rand = randWord.Next(0, words.Length);
        } while (removedNum.Contains(rand));
        return rand;
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
        for(int i = 0; i<replacedWords.Count;i++)
        {
            Console.Write($"{replacedWords[i]} ");
        }
        Console.WriteLine();
    }
    public List<string> GetReplaced()
    {
        return replacedWords;
    }
}