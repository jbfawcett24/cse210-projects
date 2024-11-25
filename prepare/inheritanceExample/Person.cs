class Person 
{
    private string firstName;
    private string lastName;
    private int age;
    public Person(string firstName, string lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
    public string GetPersonInfo()
    {
        return $"{firstName}, {lastName}, {age}";
    }
}