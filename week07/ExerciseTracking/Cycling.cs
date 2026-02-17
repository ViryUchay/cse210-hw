class Cycling : Activity
{
    private double _speed; // mph

    public Cycling(string date, double length, double speed)
        : base(date, length)
    {
        _speed = speed;
    }

    public override double GetDistance() => (_speed * Length) / 60;

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / _speed;

    public override string GetSummary()
    {
        return $"{Date} Cycling ({Length} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}
