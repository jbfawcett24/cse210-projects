using System.Drawing;

class Dog : Pet
{
    Random random = new Random();
    List<List<string>> pictures = new List<List<string>>
    {
    new List<string>
    {
        @"/^-----^\",
        @"V  o o  V" ,
        @" |  Y  |" ,
        @"  \ Q /" ,
        @"  / - \" ,
        @"  |    \" ,
        @"  |     \     )" ,
        @"  || (___\===="
    },
    new List<string>
    {
        @"           ^\",
        @" /        //o__o",
        @"/\       /  __/",
        @"\ \______\  /",
        @" \         /",
        @"  \ \----\ \",
        @"   \_\_   \_\_"
    }
    };
    public Dog(string name, ConsoleColor color, string type) : base(name, color, type){}
    public Dog(string name, ConsoleColor color, int smartLevel, int smartXp, int healthLevel, int healthXp, int happinessLevel, int happinessXp, string type) : base(name, color, smartLevel, smartXp, healthLevel, healthXp, happinessLevel, happinessXp, type){}
    public override void DisplayAnimal()
    {
        base.DisplayAnimal();
        Console.ForegroundColor = GetColor();
        int randDisplay = random.Next(0,pictures.Count);
        for(int i = 0; i < pictures[randDisplay].Count; i++)
        {
            Console.WriteLine(pictures[randDisplay][i]);
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

}