
public class Circleshape : Shape
{
    private double _radius;

    public Circleshape(string color, double radius): base()
    {
        _radius = radius;
    }


    public override double GetArea()

    {
        return Math.PI * _radius * _radius;
    }
}