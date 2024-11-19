class Scripture
{
    string verse;
    Refrence refrence;
    public Words words;
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
}