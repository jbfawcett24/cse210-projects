using System;

class Program
{
    static void Main(string[] args)
    {
        List<Fraction> fractions = new List<Fraction>();
        fractions.Add(new Fraction());
        fractions.Add(new Fraction(5));
        fractions.Add(new Fraction(3,4));
        fractions.Add(new Fraction(1,3));
        for(int i = 0; i < fractions.Count; i++)
        {
            Console.WriteLine(fractions[i].GetFractionString());
            Console.WriteLine(fractions[i].GetDecimalValue());
        }
    }
}