using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лаба4;

namespace Интерфейсы
{
    public interface ITriangleService
    {
        bool IsValidTriangle(double a, double b, double c);
        string GetType(double a, double b, double c);
        double GetArea(double a, double b, double c);   
    }
}
