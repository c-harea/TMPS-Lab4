using System;

public abstract class Shape
{
    public abstract double Area();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double Area()
    {
        return Width * Height;
    }
}

public class Square : Shape
{
    public double Side { get; set; }

    public override double Area()
    {
        return Side * Side;
    }
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public override double Area()
    {
        return Math.PI * Radius * Radius;
    }
}

public class Calculator
{
    public double CalculateArea(Shape shape)
    {
        return shape.Area();
    }
}

public class Program
{
    public static void Main()
    {
        Rectangle rectangle = new Rectangle { Width = 10, Height = 5 };
        Square square = new Square { Side = 5 };
        Circle circle = new Circle { Radius = 7 };

        Calculator calculator = new Calculator();

        Console.WriteLine("Area of rectangle is: " + calculator.CalculateArea(rectangle));
        Console.WriteLine("Area of square is: " + calculator.CalculateArea(square));
        Console.WriteLine($"Circle radius: {circle.Radius}, area: {circle.Area()}");

    }
}
