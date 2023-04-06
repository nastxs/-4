using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Интерфейсы;

namespace Лаба4.Классы
{
    public class TriangleService : ITriangleService
    {
        public double GetArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return s;
        }

        public bool IsValidTriangle(double a, double b, double c)
        {
            bool x = true;
            if (a <= 0 || b <= 0 || c <= 0)
            {
                x = false;
            }
            if (a + b <= c || b + c <= a || c + a <= b)
            {
                x = false;
            }
            return x;
        }

        public string GetType(double a, double b, double c)
        {
            if (a == b && b == c)
            {
                return "равносторонний";
            }
            else if (a == b || b == c || c == a)
            {
                return "равнобедренный";
            }
            else
            {
                return "разносторонний";
            }
        }
    }
}
