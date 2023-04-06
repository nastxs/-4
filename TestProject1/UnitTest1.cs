
using Интерфейсы;
using Лаба4.Классы;
using Лаба4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Лабa4.Классы;
using лаба4;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using DotNet.Testcontainers.Containers;
using DotNet.Testcontainers.Builders;

namespace Лаба4.Tests
{



    [TestClass]
    public class TriangleValidateServiceIntegrationTests
    {
        //string connectionString = "Server=127.0.0.1; Port=5433; Database=Triangles; User ID=postgres; Password=asd123; ";
        

        private ITriangleProvider triangleProvider;
        private ITriangleService triangleService;
        private ITriangleValidateService triangleValidateService;

        [TestInitialize]
        public void TestInitialize()
        {

            /*try
            {
                using (var con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "CREATE TABLE Triangles(id INTEGER NOT NULL PRIMARY KEY, A REAL NOT NULL, B REAL NOT NULL, C REAL NOT NULL, Square REAL NOT NULL, Type VARCHAR(30) NOT NULL)"; , Type TEXT NOT NULL
                    NpgsqlCommand command = new NpgsqlCommand(sql, con);
                    command.ExecuteNonQuery();
                }
            }
            catch { }*/
            triangleProvider = new TriangleProvider();
            triangleService = new TriangleService();
            triangleValidateService = new TriangleValidateService(triangleProvider, triangleService);
        }

        [TestMethod]
        public void IsValid_true()
        {
            triangleProvider.Save(new Triangle(3, 4, 4, 4, 6.928203230275509, "равносторонний"));
            Assert.AreEqual(true, triangleValidateService.IsValid(3));
        }

        [TestMethod]
        public void IsValid_false()
        {
            triangleProvider.Save(new Triangle(3, 4, 20, 4, 13, "разносторонний"));
            Assert.AreEqual(false, triangleValidateService.IsValid(3));
        }

         [TestMethod]
         public void IsValid_false_EmptyTriangle()
         {
             triangleProvider.Save(new Triangle());
             Assert.AreEqual(false, triangleValidateService.IsValid(3));
         }

        [TestMethod]
        public void IsValid_false_EmptyDB()
        {
            Assert.AreEqual(false, triangleValidateService.IsValid(3));
        }

        [TestMethod]
        public void IsAllValid_true()
        {
            triangleProvider.Save(new Triangle(1, 5, 6, 7, 14.696938456699069, "разносторонний"));
            triangleProvider.Save(new Triangle(2, 7, 8, 9, 26.832815729997478, "разносторонний"));
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void IsAllValid_false()
        {
            triangleProvider.Save(new Triangle(1, 45, 20, 7, 21, "разносторонний"));
            triangleProvider.Save(new Triangle(2, 7, 6, 9, 30, "разносторонний"));
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void IsAllValid_true_5Triangle()
        {
            triangleProvider.Save(new Triangle(6, 5, 6, 7, 14.696938456699069, "разносторонний"));
            triangleProvider.Save(new Triangle(7, 7, 8, 9, 26.832815729997478, "разносторонний"));
            triangleProvider.Save(new Triangle(3, 7, 8, 9, 26.832815729997478, "разносторонний"));
            triangleProvider.Save(new Triangle(4, 7, 8, 9, 26.832815729997478, "разносторонний"));
            triangleProvider.Save(new Triangle(5, 7, 8, 9, 26.832815729997478, "разносторонний"));
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        /* [TestMethod]
         public void IsAllValid_false_EmptyTriangle()
         {
             triangleProvider.Save(new Triangle());
             Assert
             .AreEqual(false, triangleValidateService.IsAllValid());
         }*/

       /* [TestMethod]
        public void IsAllValid_false_EmptyDB()
        {
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }
        [TestMethod]
        public void ASD()
        {
            Assert.AreEqual("разносторонний", triangleService.GetType(5, 6, 7));
        }*/
    }
    
}
