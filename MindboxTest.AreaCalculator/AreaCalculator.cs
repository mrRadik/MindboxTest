using MindboxTest.AreaCalculator.Interfaces;

namespace MindboxTest.AreaCalculator;

public class AreaCalculator : IAreaCalculator
{
    private IFigure? _figure;

    public AreaCalculator()
    {
    }
    
    public AreaCalculator(IFigure figure)
    {
        _figure = figure;
    }
    
    public AreaCalculator(string figureType, object parameters)
    {
        ArgumentException.ThrowIfNullOrEmpty(figureType);
        
        var type = Type.GetType(figureType);
        
        if (type != null)
        {
            _figure = (IFigure)Activator.CreateInstance(type, parameters)!;
        }
        else
        {
            throw new ArgumentException($"Unknown type {figureType}");
        }
    }
    
    public double CalculateArea()
    {
        if (_figure == null)
        {
            throw new MemberAccessException("Figure must be initialized. Call SetFigure method first");
        }
        return _figure.CalculateArea();
    }

    public void SetFigure(IFigure figure)
    {
        _figure = figure;
    }
}