using System.Text;

class Scripture
{
    string verse;
    Refrence refrence;
    private Words words;
    public Scripture(string book, int chapter, int startVerse, int endVerse, string verse)
    {
        this.verse = verse;
        words = new Words(verse);
        refrence = new Refrence(book, chapter, startVerse, endVerse);
        
    }
        public Scripture(string book, int chapter, int startVerse, string verse)
    {
        this.verse = verse;
        words = new Words(verse);
        refrence = new Refrence(book, chapter, startVerse);
        
    }
    public void Display()
    {
        refrence.Display();
        words.Display();
    }
    public void ReplaceWords()
    {
        words.ReplaceWords();
    }
    public List<string> GetReplaced()
    {
        return words.GetReplaced();
    }
    public string GetVerse()
    {
        refrence.Display();
        return verse;
    }
}