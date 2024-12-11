using System.Drawing;

class Dog : Pet
{
    List<List<List<string>>> pictures = new List<List<List<string>>>
    {};
    public Dog(string name, ConsoleColor color) : base(name, color){}
    public Dog(string name, ConsoleColor color, int smartLevel, int smartXp, int healthLevel, int healthXp, int happinessLevel, int happinessXp) : base(name, color, smartLevel, smartXp, healthLevel, healthXp, happinessLevel, happinessXp){}
    public override void DisplayAnimal()
    {
        base.DisplayAnimal();
        Console.ForegroundColor = GetColor();
        Console.WriteLine("dog");
        Console.ForegroundColor = ConsoleColor.White;
    }

}