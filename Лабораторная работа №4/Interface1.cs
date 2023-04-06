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
using лаба4;

namespace Интерфейсы
{
    public interface ITriangleProvider
    {
        Triangle GetById(int id);
        List<Triangle> GetAll();
        void Save(Triangle triangle);
    }
}
