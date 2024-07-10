using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square("Blue", 4.0));
        shapes.Add(new Rectangle("Green", 3.0, 5.0));
        shapes.Add(new Circle("Yellow", 2.5));

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape Color: {shape.Color}");
            Console.WriteLine($"Shape Area: {shape.GetArea()}");
            Console.WriteLine(); // Separate each shape's output
        }
    }
}
