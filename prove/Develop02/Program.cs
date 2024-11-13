using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string input;
        Journal journal = new Journal();
        while(true)
        {
        input = journal.Menu();
            if(input == "1")
            {
                journal.addNew();
            } else if (input == "2")
            {
                journal.Save();
            } else if(input == "3")
            {
                journal.Load();
            } else if(input == "4")
            {
                journal.Display();
            } else if(input == "5")
            {
                break;
            }
        }
    }
}