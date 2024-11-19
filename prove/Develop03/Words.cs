using System.Runtime.InteropServices;
using System.Text;

class Words
{
    string[] words;
    List<string> replacedWords = new List<string>();
    string[] displayWords;
    List<int> removedNum = new List<int>();
    int numWordsReplaced = 3;
    Random randWord = new Random();
    public Words(string scripture)
    {
        words = scripture.Split(" ");
        displayWords = words;
    }
    public void ReplaceWords()
    {
        displayWords = words;
        for(int i = 0; i<numWordsReplaced; i++)
        {
            removedNum.Add(randWord.Next(0, words.Length));
        }
        removedNum.Sort();
        replacedWords.Clear();
        for(int i = 0; i<numWordsReplaced; i++)
        {
            replacedWords.Add(words[removedNum[i]]);
            displayWords[removedNum[i]] = DashWords(words[removedNum[i]]);
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
    }
}