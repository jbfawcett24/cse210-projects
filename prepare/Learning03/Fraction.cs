using System.Diagnostics.Contracts;

class Fraction
{
    private int numuerator;
    private int denominator;
    public Fraction()
    {
        numuerator = 1;
        denominator = 1;
    }
    public Fraction(int numuerator)
    {
        this.numuerator = numuerator;
        denominator = 1;
    }
    public Fraction(int numuerator, int denominator)
    {
        this.numuerator = numuerator;
        this.denominator = denominator;
    }
    public int GetTop()
    {
        return numuerator;
    }
    public void SetTop(int numuerator)
    {
        this.numuerator = numuerator;
    }
    public int GetBottom()
    {
        return denominator;
    }
    public void SetBottom(int denominator)
    {
        this.denominator = denominator;
    }
    public string GetFractionString()
    {
        return $"{numuerator}/{denominator}";
    }
    public double GetDecimalValue()
    {
        return (double)numuerator/(double)denominator;
    }
}