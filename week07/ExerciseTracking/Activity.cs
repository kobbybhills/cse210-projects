public abstract class Activity
{
    private DateTime _date;
    private double _duration;

    public Activity(DateTime date, double duration)
    {
        _date = date;
        _duration = duration;
    }

    public DateTime Date => _date;
    public double Duration => _duration;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {this.GetType().Name} ({Duration} min) - Distance: {GetDistance()}, Speed: {GetSpeed()}, Pace: {GetPace()}";
    }
}
