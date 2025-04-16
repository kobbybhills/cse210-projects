public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, double duration, double speed) : base(date, duration)
    {
        _speed = speed;
    }

    public override double GetDistance() => (GetSpeed() / 60) * Duration;

    public override double GetSpeed() => _speed;

    public override double GetPace() => 60 / GetSpeed();
}
