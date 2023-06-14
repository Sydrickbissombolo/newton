using System;
using System.Collections.Generic;

namespace ShapeAreaCalculator
{
    // Abstract base class for all shapes
    abstract class Shape
    {
        protected string color;

        public Shape(string color)
        {
            _color = color;
        }

        public abstract double GetArea();
    }

    // Square class
    class Square : Shape
    {
        private double side;

        public Square(string color, double side) : base(color)
        {
            _side = side;
        }

        public override double GetArea()
        {
            return _side * _side;
        }
    }

    // Rectangle class
    class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(string color, double length, double width) : base(color)
        {
            _length = length;
            _width = width;
        }

        public override double GetArea()
        {
            return _length * _width;
        }
    }

    // Circle class
    class Circle : Shape
    {
        private double radius;

        public Circle(string color, double radius) : base(color)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store different shapes
            List<Shape> shapes = new List<Shape>();

            // Add some shapes to the list
            shapes.Add(new Square("Red", 5.0));
            shapes.Add(new Rectangle("Blue", 3.0, 4.0));
            shapes.Add(new Circle("Green", 2.5));

            // Iterate through the list and display the areas
            foreach (Shape shape in shapes)
            {
                Console.WriteLine("Shape: " + shape.GetType().Name);
                Console.WriteLine("Color: " + shape.color);
                Console.WriteLine("Area: " + shape.CalculateArea());
                Console.WriteLine();
            }
        }
    }
}
