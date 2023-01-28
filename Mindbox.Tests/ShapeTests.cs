namespace Mindbox.Tests
{
    [TestClass]
    public class ShapeTests
    {
        #region Circle class
        [TestMethod]
        public void ConstructorCircle_InvalidParameter_ThrowArgumentException()
        {
            Circle circle;
            Assert.ThrowsException<ArgumentException>(() => circle = new Circle(-3));
        }
        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(8.2)]
        public void PropertyCircleRadius_ValidRadius_CorrectValueReturned(double radius)
        {
            Circle circle = new Circle(10);

            circle.Radius = radius;

            Assert.AreEqual(radius, circle.Radius);
        }
        [TestMethod]
        public void GetCircleArea_ValidRadius_CorrectAreaReturned()
        {
            Circle circle = new Circle(2.5);
            double expected = 19.635;

            double actual = circle.GetArea();

            Assert.AreEqual(expected, actual, 0.0001);
        }
        [TestMethod]
        public void GetCirclePerimeter_ValidRadius_CorrectPerimeterReturned()
        {
            Circle circle = new Circle(2.5);
            double expected = 15.708;

            double actual = circle.GetPerimeter();

            Assert.AreEqual(expected, actual, 0.001);
        }
        #endregion

        #region Triangle
        [TestMethod]
        [DataRow(-3.2, 2, 4)]
        [DataRow(0, 2, 4)]
        [DataRow(4.0, 7.6, 12.5)]
        public void ConstructorTriangle_InvalidParameters_ThrowArgumentException(double A, double B, double C)
        {
            Triangle triangle;
            Assert.ThrowsException<ArgumentException>(() => triangle = new Triangle(A, B, C));
        }
        [TestMethod]
        [DataRow(3, 4, 5, true)]
        [DataRow(2.5, 3.0, 1.5, false)]
        [DataRow(2, 2, 3, false)]
        public void PropertyIsRight_VariousTrianglesSides_TriangleRectangularityReturned(double A, double B, double C, bool expected)
        {
            Triangle triangle = new Triangle(A, B, C);
            bool actual = triangle.isRight;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetTriangleArea_ValidSides_CorrectAreaReturned()
        {
            Triangle triangle = new Triangle(2.5, 3.1, 4.0);
            double expected = 3.875;

            double actual = triangle.GetArea();

            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void GetTrianglePerimeter_ValidSides_CorrectPerimeterReturned()
        {
            Triangle triangle = new Triangle(2.5, 3.3, 5.1);
            double expected = 10.9;

            double actual = triangle.GetPerimeter();

            Assert.AreEqual(expected, actual, 0.001);
        }
        #endregion
    }
}