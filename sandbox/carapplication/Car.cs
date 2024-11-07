using System.ComponentModel.DataAnnotations;

class Car
{
    private Tire tires;

    public Car()
    {
        tires = new Tire(205, 16, 55);
    }
    public void Display()
    {
        tires.Display();
        Console.WriteLine("car is driving");
    }
}