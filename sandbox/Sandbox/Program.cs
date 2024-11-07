using System;
using System.Net.NetworkInformation;

class Program
{
    class Circle 
    {
        private double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public void GetRadius()
        {
            Console.WriteLine(radius);
        }
    }
    static void Main(string[] args)
    {

        List<Circle> circles = new List<Circle>();
        int x = 3;
        for(int i = 0; i<x; i++)
        {
            circles.Add(new Circle(i));
            Console.WriteLine(circles[i].GetArea());
            circles[i].GetRadius();
        }
        // Circle circle1 = new Circle(x);
        // Circle circle2 = new Circle(x+10);

        // Console.WriteLine(circle1.GetArea());
        // Console.WriteLine(circle2.GetArea());
    }
}