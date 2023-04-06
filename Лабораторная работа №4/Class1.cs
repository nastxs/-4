using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using Npgsql;
using System.Runtime.InteropServices;
using Интерфейсы;

namespace лаба4
{

        public class Triangle
        {
            public int id;
            public double a;
            public double b;
            public double c;
            public double sq;
            public string type;

            public Triangle(int ID, double A, double B, double C, double Sq, string Type)
            {
                id = ID;
                a = A;
                b = B;
                c = C;
                sq = Sq;
                type = Type;
            }
        public Triangle()
        {
            
        }


    }
    

}
