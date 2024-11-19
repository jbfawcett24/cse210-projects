using System.ComponentModel.DataAnnotations;

class Refrence
{
    private string book;
    private int chapter;
    private string verses;
    public Refrence(string book, int chapter, int verse)
    {
        this.book = book;
        this.chapter = chapter;
        verses = verse.ToString();
    }
    public Refrence(string book, int chapter, int startVerse, int endVerse)
    {
        this.book = book;
        this.chapter = chapter;
        verses = $"{startVerse}-{endVerse}";
    }
    public void Display()
    {
        Console.WriteLine($"{book} {chapter}:{verses}");
    }
}