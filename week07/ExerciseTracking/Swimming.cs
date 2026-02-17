class Swimming : Activity
{
    private int _laps;

    public Swimming(string date, double length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance() => _laps * 50 / 1000.0 * 0.62; // miles

    public override double GetSpeed() => (GetDistance() / Length) * 60;

    public override double GetPace() => Length / GetDistance();

    public override string GetSummary()
    {
        return $"{Date} Swimming ({Length} min) - Distance: {GetDistance():F2} miles, Speed: {GetSpeed():F2} mph, Pace: {GetPace():F2} min per mile";
    }
}
