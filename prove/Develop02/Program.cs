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