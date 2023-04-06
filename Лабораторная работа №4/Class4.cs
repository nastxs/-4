using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Интерфейсы;
using лаба4;



namespace Лаба4
{
    public class TriangleValidateService : ITriangleValidateService
    {
        private readonly ITriangleProvider TriangleProvider;
        private readonly ITriangleService TriangleService;

        public TriangleValidateService(ITriangleProvider TriangleProvider, ITriangleService TriangleService)
        {
            this.TriangleProvider = TriangleProvider;
            this.TriangleService = TriangleService;
        }

       /* public bool IsValid(int id)
        {
            bool x = false;
            Triangle tr = TriangleProvider.GetById(id);
            x = TriangleService.IsValidTriangle(tr.a, tr.b, tr.c);
            return x;
        }*/

        public bool IsAllValid()
        {
            List<Triangle> list = TriangleProvider.GetAll();
            bool x = true;

            if (list.Count == 0)
            {
                return false;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (checkTriangle(list[i]) == false)
                {
                    x = false;
                    break;
                }
            }
            return x;
        }

        private bool checkTriangle(Triangle triangle)
        {
            if (TriangleService.IsValidTriangle(triangle.a, triangle.b, triangle.c) == true)
                if (TriangleService.GetType(triangle.a, triangle.b, triangle.c) == triangle.type)
                    if (TriangleService.GetArea(triangle.a, triangle.b, triangle.c) == triangle.sq)
                       return true;
                    else return false;
                else return false;
            else return false;
        }
        public bool IsValid(int id)
        {
            Triangle triangle = TriangleProvider.GetById(id);
            return checkTriangle(triangle);
          
        }
    }


    /*public class TriangleAreaService : ITriangleAreaService
    {
        private readonly ITriangleProvider TriangleProvider;
        private readonly ITriangleService TriangleService;

        public TriangleAreaService(ITriangleProvider TriangleProvider, ITriangleService TriangleService)
        {
            this.TriangleProvider = TriangleProvider;
            this.TriangleService = TriangleService;
        }

        public bool GetArea(int area)
        {
            bool x = false;
            Triangle tr = TriangleProvider.GetById(area);
            x = TriangleService.IsValidTriangle(tr.a, tr.b, tr.c);
            return x;

        }

    }*/



}
