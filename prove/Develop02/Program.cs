using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        journal.addNew();
        journal.Display();
        // Entry entry = new Entry("cheese", "food");
        // entry.Display();
    }
}