using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.LoadAll();
        menu.SetCurrentTime();
        menu.DisplayMenu();
       
    }
}