class Cat : Pet
{
        Random random = new Random();
    List<List<string>> pictures = new List<List<string>>
    {
    new List<string>
    {
        @"      |\      _,,,---,,_",
        @"ZZZzz /,`.-'`'    -.  ;-;;,_",
        @"     |,4-  ) )-,_. ,\ (  `'-'",
        @"    '---''(_/--'  `-'\_)  "
    },
    new List<string>
    {
        @"    /\_/\           ___",
        @"   = o_o =_______    \ \",
        @"    __^      __(  \.__) )",
        @"(@)<_____>__(_____)____/"
    }
    };
    public Cat(string name, ConsoleColor color, string type) : base(name, color, type){}
    public Cat(string name, ConsoleColor color, int smartLevel, int smartXp, int healthLevel, int healthXp, int happinessLevel, int happinessXp, string type) : base(name, color, smartLevel, smartXp, healthLevel, healthXp, happinessLevel, happinessXp, type){}
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