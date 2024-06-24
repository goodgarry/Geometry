using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry;
using System;

namespace Geometry.Tests
{
    [TestClass]
    public class ShapeTests
    {
        [TestMethod]
        public void CircleAreaTest()
        {
            var circle = new Circle(5);
            double area = circle.GetArea();
            Assert.AreEqual(Math.PI * 25, area, 1e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CircleInvalidRadiusTest()
        {
            var circle = new Circle(-1);
        }

        [TestMethod]
        public void TriangleAreaTest()
        {
            var triangle = new Triangle(3, 4, 5);
            double area = triangle.GetArea();
            Assert.AreEqual(6, area, 1e-10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TriangleInvalidSidesTest()
        {
            var triangle = new Triangle(1, 2, 3);
        }

        [TestMethod]
        public void RightTriangleTest()
        {
            var triangle = new Triangle(3, 4, 5);
            bool isRight = triangle.IsRightTriangle();
            Assert.IsTrue(isRight);
        }

        [TestMethod]
        public void NonRightTriangleTest()
        {
            var triangle = new Triangle(3, 4, 6);
            bool isRight = triangle.IsRightTriangle();
            Assert.IsFalse(isRight);
        }

        [TestMethod]
        public void FormFactoryCircleTest()
        {
            IForm form = Factory.CreateForm(5.0);
            Assert.IsInstanceOfType(form, typeof(Circle));
        }

        [TestMethod]
        public void FormFactoryTriangleTest()
        {
            IForm shape = Factory.CreateForm(3.0, 4.0, 5.0);
            Assert.IsInstanceOfType(shape, typeof(Triangle));
        }
    }
}
