using System.Drawing;

namespace Mindbox
{
    /// <summary>
    /// Represents an abstract geometric figure.
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Returns the area of geometric figure.
        /// </summary>
        public abstract double GetArea();
        /// <summary>
        /// Returns the perimeter of geometric figure.
        /// </summary>
        public abstract double GetPerimeter();
    }
    /// <summary>
    /// Represents the geometric circle. 
    /// </summary>
    public class Circle : Shape
    {
        private double _radius;
        /// <summary>
        /// Gets or sets the radius of a circle. Radius cannot be a negative number.
        /// </summary>
        public double Radius
        {
            get => _radius;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Radius cannot be a negative number.");
                else
                    _radius = value;
            }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class with a specific radius.
        /// </summary>
        public Circle(double radius) { this.Radius = radius; }
        /// <summary>
        /// Returns the area of circle.
        /// </summary>
        public override double GetArea() => Math.PI * Radius * Radius;
        /// <summary>
        /// Returns the perimeter of circle.
        /// </summary>
        public override double GetPerimeter() => 2.0 * Math.PI * Radius;
    }
    /// <summary>
    /// Represents the geometric triangle. 
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// Gets one of the three sides of a triangle.
        /// </summary>
        public double SideA { get; private set; }
        /// <summary>
        /// Gets one of the three sides of a triangle.
        /// </summary>
        public double SideB { get; private set; }
        /// <summary>
        /// Gets one of the three sides of a triangle.
        /// </summary>
        public double SideC { get; private set; }
        /// <summary>
        /// Indicates whether a triangle is a right triangle using the Pythagorean theorem.
        /// </summary>
        public bool isRight 
        {
            get => (SideA * SideA + SideB * SideB == SideC * SideC) ||
                   (SideA * SideA + SideC * SideC == SideB * SideB) ||
                   (SideB * SideB + SideC * SideC == SideA * SideA) ? true : false;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class with three sides.
        /// </summary>
        /// <remarks>
        /// According to Triangle Inequality Theorem, for any triangle, the sum of lengths of two sides is always greater than the third side.
        /// </remarks>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (ValidateSides(sideA, sideB, sideC))
            {
                this.SideA = sideA;
                this.SideB = sideB;
                this.SideC = sideC;
            }
            else
                throw new ArgumentException("Side must be a positive number and satisfy the triangle inequality theorem.");
        }
        /// <summary>
        /// Returns the area of triangle using Heron's formula.
        /// </summary>
        public override double GetArea()
        {
            var p = GetPerimeter() / 2.0;
            return Math.Sqrt(p*(p-SideA)*(p-SideB)*(p-SideC));
        }
        /// <summary>
        /// Returns the perimeter of triangle.
        /// </summary>
        public override double GetPerimeter() => SideA + SideB + SideC;
        /// <summary>
        /// Сhecks if the sides are positive and satisfy the triangle inequality theorem.
        /// </summary>
        private bool ValidateSides(double sideA, double sideB, double sideC)
        {
            if (sideA > 0 && sideB > 0 && sideC > 0 && (sideA + sideB) > sideC && (sideA + sideC) > sideB && (sideB + sideC) > sideA)
                return true;
            else
                return false;
        }
    }
}