using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!\n"); 

        /* 
        // This doesnt scale well
        Square firstShape = new Square("Blue", 3);
        Rectangle secondShape = new Rectangle("Red", 4, 5);
        Circle thirdShape = new Circle("Green", 2);

        List <Shape> shapes = new List<Shape>();
        shapes.Add(firstShape);
        shapes.Add(secondShape);
        shapes.Add(thirdShape);
        */

        List<Shape> shapes = new List<Shape>
        {
            new Square("Yellow", 7),
            new Square("Blue", 2),
            new Square("Pink", 5),
            new Rectangle("Red", 4, 7),
            new Rectangle("Red", 4, 5),
            new Circle("Green", 9),
            new Circle("Blue", 2),
            new Circle("Red", 3)
        };


        string color;
        double area;

        foreach (Shape shape in shapes)
        {
            color = shape.GetColor();
            area = shape.GetArea();
            Console.WriteLine($"The area of the {color} shape is: {area}");
        }
    }
}