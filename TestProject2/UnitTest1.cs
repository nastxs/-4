using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Лаба4;
using Moq;
using System.IO;
using Npgsql;
using Интерфейсы;
using Лаба4.Классы;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using лаба4;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Лаба4.Tests
{
    [TestClass]
    public class TriangleValidateServiceTest
    {
       
        private Mock<ITriangleProvider> triangleProvider;
        private ITriangleService triangleService;
        private ITriangleValidateService triangleValidateService;

        [TestInitialize]
        public void TestInitialize()
        {
            triangleProvider = new Mock<ITriangleProvider>();
            triangleService = new TriangleService();
            triangleValidateService = new TriangleValidateService(triangleProvider.Object, triangleService);
        }

        [TestMethod]
        public void TriangleValidateService_IsValid_true()
        {
            triangleProvider.Setup(a => a.GetById(It.IsAny<int>())).Returns(new Triangle(3, 3, 5, 4, 6, "разносторонний"));
            Assert.AreEqual(true, triangleValidateService.IsValid(3));
        }

        [TestMethod]
        public void TriangleValidateService_IsValid_false()
        {
            triangleProvider.Setup(a => a.GetById(It.IsAny<int>())).Returns(new Triangle(3, 3, 20, 4, 13, "разносторонний"));
            Assert.AreEqual(false, triangleValidateService.IsValid(1));
        }

       /* [TestMethod]
        public void TriangleValidateService_IsValid_false_EmptyTriangle()
        {
            triangleProvider.Setup(a => a.GetById(It.IsAny<int>())).Returns(new Triangle());
            Assert.AreEqual(false, triangleValidateService.IsValid(1));
        }*/

        [TestMethod]
        public void TriangleValidateService_IsAllValid_true_5Triangle()
        {
            triangleProvider.Setup(a => a.GetAll()).Returns(new List<Triangle> { new Triangle(1, 3, 5, 4, 6, "разносторонний"), new Triangle(2, 3, 3, 4, 12, "равнобедренный"), new Triangle(3, 3, 3, 3, 11, "равносторонний"), new Triangle(4, 3, 3, 4, 12, "равнобедренный"), new Triangle(5, 3, 3, 4, 12, "равнобедренный") });
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void TriangleValidateService_IsAllValid_true_3Triangle()
        {
            triangleProvider.Setup(a => a.GetAll()).Returns(new List<Triangle> { new Triangle(1, 3, 5, 4, 13, "разносторонний"), new Triangle(2, 3, 3, 4, 12, "равнобедренный"), new Triangle(3, 3, 3, 3, 11, "равносторонний") });
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void TriangleValidateService_IsAllValid_true_2Triangle()
        {
            triangleProvider.Setup(a => a.GetAll()).Returns(new List<Triangle> { new Triangle(1, 3, 5, 4, 13, "разносторонний"), new Triangle(2, 3, 3, 4, 12, "равнобедренный") });
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void TriangleValidateService_IsAllValid_true_1Triangle()
        {
            triangleProvider.Setup(a => a.GetAll()).Returns(new List<Triangle> { new Triangle(3, 3, 3, 3, 11, "равносторонний") });
            Assert.AreEqual(true, triangleValidateService.IsAllValid());
        }

        [TestMethod]
        public void TriangleValidateService_IsAllValid_false_1Triangle()
        {
            triangleProvider.Setup(a => a.GetAll()).Returns(new List<Triangle> { new Triangle(1, 3, 5, 20, 13, "разносторонний"), new Triangle(2, 3, 3, 4, 12, "равнобедренный"), new Triangle(3, 3, 3, 3, 11, "равносторонний") });
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }

       /* [TestMethod]
        public void TriangleValidateService_IsAllValid_false_EmptyTriangle()
        {
            triangleProvider.Setup(a => a.GetAll()).Returns(new List<Triangle> { new Triangle() });
            Assert.AreEqual(false, triangleValidateService.IsAllValid());
        }*/
    }
}