abstract class Pet 
{
    ConsoleColor color;
    int smartLevel = 1;
    int smartXp;
    int smartXpLevel;
    int healthLevel = 1;
    int healthXp;
    int healthXpLevel;
    int happinessLevel = 1;
    int happinessXp;
    int happinessXpLevel;
    string name;
    string type;
    public Pet(string name, ConsoleColor color, string type)
    {
        this.name = name;
        this.color = color;
        this.type = type;
    }
    public Pet(string name, ConsoleColor color, int smartLevel, int smartXp, int healthLevel, int healthXp, int happinessLevel, int happinessXp, string type)
    {
        this.name = name;
        this.color = color;
        this.smartLevel = smartLevel;
        this.smartXp = smartXp;
        this.healthLevel = healthLevel;
        this.healthXp = healthXp;
        this.happinessLevel = happinessLevel;
        this.happinessXp = happinessXp;
        this.type = type;
    }
    public string Name
    {
        get{return name;}
        set{name = value;}
    }
    public ConsoleColor Color
    {
        get{return color;}
        set{color = value;}
    }
    public int SmartLevel
    {
        get{return smartLevel;}
        set{smartLevel = value;}
    }
    public int SmartXp
    {
        get{return smartXp;}
        set{smartXp = value;}
    }
    public int HealthLevel
    {
        get{return healthLevel;}
        set{healthLevel = value;}
    }
    public int HealthtXp
    {
        get{return healthXp;}
        set{healthXp = value;}
    }
    public int HappinessLevel
    {
        get{return happinessLevel;}
        set{happinessLevel = value;}
    }
    public int HappinessXp
    {
        get{return happinessXp;}
        set{happinessXp = value;}
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
        DisplayProgressBar(smartXp, smartXpLevel);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"Health Level {healthLevel}    [");
        DisplayProgressBar(healthXp, healthXpLevel);
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"Happiness Level {happinessLevel} [");
        DisplayProgressBar(happinessXp, happinessXpLevel);
    }
    private void DisplayProgressBar(double xp, double xpToLevelUp)
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
    public string GetPetType()
    {
        return type;
    }
    public string GetStringColor()
    {
        return ToString();
    }
}