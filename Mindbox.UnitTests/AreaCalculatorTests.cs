using MindboxTest.AreaCalculator;
using MindboxTest.AreaCalculator.Figures;
using MindboxTest.AreaCalculator.Interfaces;

namespace Mindbox.UnitTests;

public class AriaCalculatorTests
{
    private IAreaCalculator _calculator;
    
    [SetUp]
    public void Setup()
    {
        _calculator = new AreaCalculator();
    }

    [TestCase(new double[]{6, 8, 10})]
    [TestCase(new double[]{3, 4, 5})]
    [TestCase(new double[]{12, 16, 20})]
    public void RightTriangle_ReturnTrue(double[] sides)
    {
        var triangle = GetTriangle(sides);
        Assert.IsTrue(triangle.IsRightTriangle, 
            $"Triangle with sides {sides[0]}, {sides[1]}, {sides[2]} should be right triangle");
    }
    
    [TestCase(new double[]{5, 6, 3})]
    [TestCase(new double[]{2, 3, 4})]
    [TestCase(new double[]{10, 11, 12})]
    public void RightTriangle_ReturnFalse(double[] sides)
    {
        var triangle = GetTriangle(sides);
        Assert.IsFalse(triangle.IsRightTriangle, 
            $"Triangle with sides {sides[0]}, {sides[1]}, {sides[2]} shouldn't be right triangle");
    }

    [TestCase(new double[] { 1, 2, 4 })]
    [TestCase(new double[] { 1, 1, 5 })]
    public void Triangle_BadParameters(double[] sides)
    {
        var exception = Assert.Throws<ArgumentException>(() => GetTriangle(sides));
        StringAssert.Contains("Sum of two sides must be greater than third", exception?.Message);
    }

    [Test]
    public void Triangle_CheckCalculator()
    {
        var triangle = new Triangle(6, 8, 10);
        _calculator.SetFigure(triangle);
        var area = _calculator.CalculateArea();
        Assert.AreEqual(area, 24);
    }
    
    [Test]
    public void Circle_CheckCalculator()
    {
        var circle = new Circle(2);
        _calculator.SetFigure(circle);
        var area = _calculator.CalculateArea();
        Assert.AreEqual(area, 12,566370614359172);
    }

    private static Triangle GetTriangle(double[] sides)
    {
        return new Triangle(sides[0], sides[1], sides[2]);
    }
}