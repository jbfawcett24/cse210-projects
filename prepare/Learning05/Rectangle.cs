class Rectangle : Shape
{
    double length;
    double width;
    public Rectangle(double l, double w, string color) : base(color)
    {
        length = l;
        width = w;
    }
    public override double GetArea()
    {
        return length*width;
    }
}