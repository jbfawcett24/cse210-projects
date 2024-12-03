using System;

class Program
{
    public static void SetPersonFirstName(Person person, string firstName)
    {
        person.SetFirstName(firstName);
    }
    static void Main(string[] args)
    {
        Doctor bob = new Doctor("bob", "billy", 485, "Chainsaw");
        Police bober = new Police("bober", "billyer", 14, "wooden spoon");
        Console.WriteLine(bober.GetPoliceInfo());
        Console.WriteLine(bob.GetDoctorInfo());

        SetPersonFirstName(bober, "doug");
        Console.WriteLine(bober.GetPersonInfo());
    }
}
