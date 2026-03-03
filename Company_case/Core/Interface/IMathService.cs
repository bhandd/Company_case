using Company_case.Core.Domain;

namespace Company_case.Core.Interface;

public interface IMathService
{
    public bool IsItFibonacchi(long input);
    public EasterTrend EasterStatistics();
}