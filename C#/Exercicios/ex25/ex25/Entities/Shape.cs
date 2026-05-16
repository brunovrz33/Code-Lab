using System;
using System.Collections.Generic;
using System.Text;
using ex25.Enums;

namespace ex25.Entities
{
    abstract class Shape
    {
        public Color Color { get; set; }

        public Shape(Color color)
        {
            Color = color;
        }
        public abstract double Area();
    }
}
