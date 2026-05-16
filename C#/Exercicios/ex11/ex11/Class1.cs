using System;
using System.Collections.Generic;
using System.Text;

namespace ex11
{
    class Triangulo {

        public double A;
        public double B;
        public double C;

        public double area() {
            double p = (A + B + C) / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
