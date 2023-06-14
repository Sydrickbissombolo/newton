using System;
using System.Collections.Generic;

namespace ShapeAreaCalculator
{
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
            return _length * _idth;
        }
    }
}