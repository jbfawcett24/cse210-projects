abstract class Pet 
{
    ConsoleColor color;
    int smartLevel;
    int smartXp;
    int smartXpLevel;
    int healthLevel;
    int healthXp;
    int healthXpLevel;
    int happinessLevel;
    int happinessXp;
    int happinessXpLevel;
    string name;
    public Pet(string name, ConsoleColor color)
    {
        this.name = name;
        this.color = color;
    }
    public Pet(string name, ConsoleColor color, int smartLevel, int smartXp, int healthLevel, int healthXp, int happinessLevel, int happinessXp)
    {
        this.name = name;
        this.color = color;
        this.smartLevel = smartLevel;
        this.smartXp = smartXp;
        this.healthLevel = healthLevel;
        this.healthXp = healthXp;
        this.happinessLevel = happinessLevel;
        this.happinessXp = happinessXp;
    }
    public void AddSmartXp(int num)
    {
        smartXp+=num;
    }
    public void AddHealthXp(int num)
    {
        healthXp+=num;
    }
    public void AddHappyXp(int num)
    {
        happinessXp+=num;
    }
    private void CheckLevel()
    {
        SetXpToLevel();
        if(smartXp>=smartXpLevel)
        {
            smartXp-=smartXpLevel;
            smartLevel++;
        }
        if(healthXp>=healthXpLevel)
        {
            healthXp-=healthXpLevel;
            healthLevel++;
        }
        if(happinessXp>=happinessXpLevel)
        {
            happinessXp-=happinessXpLevel;
            happinessLevel++;
        }
        SetXpToLevel();
    }
    private void SetXpToLevel()
    {
        smartXpLevel = (smartLevel*50)+100;
        healthXpLevel = (healthLevel*50)+100;
        happinessXpLevel = (happinessLevel*50)+100;
    }
    public virtual void DisplayAnimal()
    {
        CheckLevel();
        Console.WriteLine(name);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"Smart Level {smartLevel}     [");
        DisplayProgressBar(smartXp, 100);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Health Level {healthLevel}    [");
        DisplayProgressBar(healthXp, 150);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Happiness Level {happinessLevel} [");
        DisplayProgressBar(happinessXp, 50);
    }
    private void DisplayProgressBar(int xp, int xpToLevelUp)
    {
        double progress = xp/xpToLevelUp;
        for(int i = 0; i<50*progress; i++)
        {
            Console.Write("*");
        }
        for(int i = 0; i< 50*(1-progress); i++)
        {
            Console.Write("-");
        }
        Console.WriteLine($"] {xp}/{xpToLevelUp}");
    }
    public ConsoleColor GetColor()
    {
        return color;
    }
    public string GetName()
    {
        return name;
    }
}