using Xunit;
using System;
using Company_case.Core.Service;

namespace Company_case.Tests
{
    public class MathServiceTests
    {
        // Testar normala värden och maxvärden (True/False)
        [Theory]
        [InlineData(0, true)]
        [InlineData(1, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(7540113804746346429, true)] // Max Fibonacci för long
        [InlineData(7540113804746346429 + 1, false)]
        [InlineData(long.MaxValue, false)] // Maxvärde för long (testar overflow)
        [InlineData(12586269025, true)] //tal mitt i serien
        public void IsItFibonacchi_Checks_Multiple_Values(long input, bool expectedResult)
        {
            var service = new MathService();
            bool result = service.IsItFibonacchi(input);
            Assert.Equal(expectedResult, result);
        }

        // Testar att negativa tal kastar fel (Exception)
        [Fact]
        public void IsItFibonacchi_Should_Throw_Error_For_Negative_Numbers()
        {
            var service = new MathService();
            long negativeInput = -5;

            Assert.Throws<ArgumentException>(() => service.IsItFibonacchi(negativeInput));
        }


        [Fact]
        public void EasterTest()
        {
            var service = new MathService();

            //  2026 som blir 5 april
            var result = service.WhenIsItEaster(2026);

            // Testa det undantaget (t.ex. år 1954 eller 2049 ska bli 18 april)
            var resultSpecial = service.WhenIsItEaster(2049);
        }


        [Theory]
// 1. Standard cases (March & April)
        [InlineData(2024, 3, 31)] // Leap year, March
        [InlineData(2026, 4, 5)] // Standard April

// 2. Future century (Testing N=6 logic after 2100)
        [InlineData(2100, 3, 28)] // First year with N=6

// 3. Exception: April 26 -> April 19
        [InlineData(2076, 4, 19)] // Would be 26th without exception

// 4. Exception: April 25 -> April 18 (The d=28, e=6 case)
        [InlineData(2049, 4, 18)] // Would be 25th without exception

// 5. Edge case: April 25 WITHOUT exception (d is not 28)
        [InlineData(2038, 4, 25)] // Should remain 25th
// 6. Edge case: Last year with N=5
        [InlineData(2099, 4, 12)]
        public void WhenIsItEaster_Returns_Correct_Date_For_All_Edge_Cases(int year, int expectedMonth, int expectedDay)
        {
            // Arrange
            var service = new MathService();
            var expectedDate = new DateTime(year, expectedMonth, expectedDay);

            // Act
            var result = service.WhenIsItEaster(year);

            // Assert
            Assert.Equal(expectedDate, result);
        }

        //     [Fact]
        //     public void QuickDebugEaster()
        //     {
        //         var service = new MathService();
        //         var result = service.EasterStatisticsInput(2024);
        //
        //         // Detta test kommer garanterat att faila och visa värdena i felmeddelandet
        //         Assert.True(false, $"Före: {result.GetBefore()}, Efter: {result.GetAfter()}, Samma: {result.GetSame()}");
        //     }

        [Fact]
        public void EasterStatistics_Should_Return_Expected_Counts_For_2024_Century()
        {
            // Arrange
            var service = new MathService();
            int startYear = 2024;

            // Baserat på din körning:
            int expectedBefore = 69;
            int expectedAfter = 27;
            int expectedSame = 4;
            //
            //     // Act
            //     var result = service.EasterStatistics();
            //
            //     // Assert
            //     Assert.Equal(expectedBefore, result.before);
            //     Assert.Equal(expectedAfter, result.after);
            //     Assert.Equal(expectedSame, result.same);
            //
            //     // Dubbelkolla att det totalt blir 100 år
            //     Assert.Equal(100, result.before + result.after + result.same);
            // }


            // [Theory]
            // [InlineData(2099)]
            // [InlineData(2049)]
            // [InlineData(2100)]
            // [InlineData(2038)]
            // [InlineData(2076)]
            // [InlineData(2126)]
            // [InlineData(2030)]
            // public void EasterDate_ManualCheck(int year)
            // {
            //     var service = new MathService();
            //     var result = service.WhenIsItEaster(year);
            //
            //     // Testet kommer att faila för varje år och visa datumet i meddelandet
            //     Assert.True(false, $"År {year} infaller påsken den: {result:yyyy-MM-dd}");
            // }
            //
        }


    }
}