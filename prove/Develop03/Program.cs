using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.StartUp();
        while(true)
        {
            menu.Display();
        }
    }
}
//Creativity shown: you have to input the words as they dissapear for more words to dissapear. aditionally, at the end, you may choose to redo it or quit.