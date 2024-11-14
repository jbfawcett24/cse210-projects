using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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

//Exceeding requirments - i simplified the proccess of loading the files by prompting it at the start of the program, additionally i added a check to ensure you couldnt load a new file or quit without confirming that you do not want to save.
//I also made the menu its own class. I made the program create a new file if the file you try to load doesnt exist. Saving no longer requires an input of a file, it will save to the loaded file.
//I also made the prompts load from a Text file instead of just being stored in a list