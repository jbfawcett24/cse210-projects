using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>{};
        shapes.Add(new Square(5, "green"));
        shapes.Add(new Rectangle(2, 6, "blue"));
        shapes.Add(new Circle (2, "red"));
        foreach(Shape shape in shapes)
        {
            Console.WriteLine(shape.GetArea());
            Console.WriteLine(shape.GetColor());
        }
    }
}