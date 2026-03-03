namespace Company_case.Core.Domain;

public class EasterTrend
{
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    public int before { get; set; }
    public int after { get; set; }
    public int same { get; set; }
    public string Trend { get; set; }
    public List<DateTime> TrendDates { get; set; }
    
    
    public EasterTrend(int startYear, int endYear, int before, int after, int same, string trend, List<DateTime> trendDates)
    {
        this.StartYear = startYear;
        this.EndYear = endYear;
        this.before = before;
        this.after = after;
        this.same = same;
        this.Trend = trend;
        this.TrendDates = trendDates;
    }
}