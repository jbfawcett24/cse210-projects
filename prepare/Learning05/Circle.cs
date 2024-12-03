class Circle : Shape
{
    double radius;
    public Circle(double r, string color) : base(color)
    {
        radius = r;
    }
    public override double GetArea()
    {
        return radius*radius*Math.PI;
    }
}