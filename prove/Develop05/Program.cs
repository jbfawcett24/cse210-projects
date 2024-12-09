using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.StartUp();
        menu.DisplayMenu();
    }
}
//Creativity - The user system allows multiple different people to use the program with no overlap of thier goals. The saving and loading is all done automatically in the background. completed quests are moved to a different menu to keep the main menu clean. I also implemented a leveling system, where the xp required to level up increases each level.