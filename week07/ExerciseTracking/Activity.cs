using System;

abstract class Activity
{
    // Encapsulated private fields
    private string _date;
    private double _length; // in minutes

    // Constructor
    public Activity(string date, double length)
    {
        _date = date;
        _length = length;
    }

    // Properties (read-only)
    public string Date => _date;
    public double Length => _length;

    // Abstract methods to be implemented by derived classes
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Summary method (can use abstract methods)
    public virtual string GetSummary()
    {
        return $"{Date} ({Length} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}
