class Scripture
{
    string verse;
    Refrence refrence = new Refrence("John", 3, 16);
    public Words words;
    public Scripture(string verse)
    {
        this.verse = verse;
        words = new Words(verse);
    }
    public void Display()
    {
        refrence.Display();
        words.Display();
    }
}