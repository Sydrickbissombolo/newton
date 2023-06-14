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

        public string GetColor()
        {
            return color;
        }
        public void SetColor(string color)
        {
            _color = color;
        }

        public abstract double GetArea();
    }
}
