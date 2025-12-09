public class Squareshape : Shape
{
    private double _side;


    public Squareshape(string color, double sideLength): base()
    {
        _side = sideLength;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}