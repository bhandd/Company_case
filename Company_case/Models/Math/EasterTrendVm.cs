using Company_case.Core.Domain;

namespace Company_case.Models.Math;

public class EasterTrendVm
{
    public int StartYear { get; set; }
    public int EndYear { get; set; }
    public int Before { get; set; }
    public int After { get; set; }
    public int Same { get; set; }
    public string Trend { get; set; }
    public List<DateTime> EasterDates { get; set; }
    public static EasterTrendVm FromEasterTrend(EasterTrend easterTrend)
    {
        return new EasterTrendVm()
        {
            StartYear = easterTrend.StartYear,
            EndYear = easterTrend.EndYear,
            Before = easterTrend.before,
            After = easterTrend.after,
            Same = easterTrend.same,
            Trend = easterTrend.Trend,
            EasterDates = easterTrend.TrendDates
            

        };
    }
    
}