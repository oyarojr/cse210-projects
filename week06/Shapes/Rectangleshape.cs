public class Rectangleshape : Shape
{
    private double _length;
    private double _width;

    public Rectangleshape(string color, double length, double width) : base()

    {
        _length = length;
        _width = width;
    }

    public override double GetArea()
    {
        return _length * _width;
    }
}