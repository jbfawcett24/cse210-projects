class Police : Person
{
    private string weapon;
    public Police(string firstName, string lastName, int age, string weapon) : base(firstName, lastName, age)
    {
        this.weapon = weapon;
    }
    public string GetPoliceInfo()
    {
        return $"{weapon}, {GetPersonInfo()}";
    }
}