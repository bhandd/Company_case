using System.Runtime.InteropServices.JavaScript;
using Company_case.Core.Domain;
using Company_case.Core.Interface;

namespace Company_case.Core.Service;

public class MathService : IMathService
{
    public bool IsItFibonacchi(long input)
    {
        if (input < 0) throw new ArgumentException("input cannot be negative");
        if(input == 0 || input == 1) return true;
        
        long a = 0;
        long b = 1;
        long result = 0;

        while (result <= input)
        {
            if (input == result) return true;
    
            result = a + b;
            //safety check for overflow (if long wraps around to negative)
            if (result < 0) break;
            a = b;
            b = result;
        }
        return false;
    }

    public DateTime WhenIsItEaster(int year)
    {
        if (year < 1900 || year > 2199)
        {
            throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 1900 and 2199");
        }
        
        int day;
        int M = 24;
        int N = 5;
        int a = year % 19;
        int b = year % 4;
        int c = year % 7;
        int d = (19 * a + M) % 30;
        int month = 3;
        
        if (year > 2099)
        {
            N = 6;
        }
        int e = (2*b+4*c+6*d+N) % 7;

        if ((d + e) > 9)
        {
            day = d + e - 9;
            month = 4;
            if(day == 26) day = 19;
            if(day == 25 && d==28 && e==6) day = 18;
        }
        else
        {
            day = 22+d + e;
        }
        
        return new DateTime(year, month, day);
    }


    public EasterTrend EasterStatistics()
    {
        int startYear = DateTime.Now.Year;
        int endYear = startYear + 100;
        int before = 0;
        int after = 0;
        int same = 0;
        int year = startYear;
        List<DateTime> easterDates = new List<DateTime>();
    
        while (year <= endYear)
        {
           DateTime easterDate = WhenIsItEaster(year);
           easterDates.Add(easterDate);

            if (easterDate.Month < 4 ||(easterDate.Month == 4 && easterDate.Day < 15))
            {
                before++;
            }
            else if (easterDate.Month == 4 && easterDate.Day == 15)
            {
                same++;
            }
            else
            {
                after++;
            }
                
            year++;
            
        }
        string trend;
        if (before > after && before > same)
            trend = "före";
        else if (after > before && after > same)
            trend = "efter";
        else
            trend = "på";
        return new EasterTrend(startYear,endYear, before, after, same, trend, easterDates);
    }
    
    
    //För unit-tester
    public EasterTrend EasterStatisticsInput(int startYear)
    {
        int endYear = startYear + 100;
        int before = 0;
        int after = 0;
        int same = 0;
        
        while (startYear < endYear)
        {
            DateTime easterDate = WhenIsItEaster(startYear);
           

            if (easterDate.Month < 4 ||(easterDate.Month == 4 && easterDate.Day < 15))
            {
                before++;
            }
            else if (easterDate.Month == 4 && easterDate.Day == 15)
            {
                same++;
            }
            else
            {
                after++;
            }
            startYear++;
        }
        return new EasterTrend(startYear, startYear+1, before, after, same, "på", new List<DateTime>());
    }
}