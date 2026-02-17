class Running : Activity
{
    private double _distance; // in miles

    public Running(string date, double length, double distance)
        : base(date, length)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => (_distance / Length) * 60;

    public override double GetPace() => Length / _distance;

    public override string GetSummary()
    {
        return $"{Date} Running ({Length} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}
