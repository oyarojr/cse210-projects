using System;

class Program
{
    static void Main(string[] args)
    {

        List<Shape> shapes = new List<Shape>();

        Squareshape s1 = new Squareshape("Red", 3);
        shapes.Add(s1);

        Rectangleshape s2 = new Rectangleshape("Blue", 4, 5);
        shapes.Add(s2);

        Circleshape s3 = new Circleshape("Green", 6);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            // Notice that all shapes have a GetColor method from the base class
            string color = s.GetColor();

            // Notice that all shapes have a GetArea method, but the behavior is
            // different for each type of shape
            double area = s.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}