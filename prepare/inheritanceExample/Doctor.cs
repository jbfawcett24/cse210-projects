class Doctor : Person
{
    private string tools;
    public Doctor(string firstName, string lastName, int age, string tools) : base(firstName, lastName, age)
    {
        this.tools = tools;
    }
    public string GetDoctorInfo()
    {
        return $"{tools}, {GetPersonInfo()}";
    }
}