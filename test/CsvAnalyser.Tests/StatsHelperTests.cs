using System.Collections.Generic;
using CsvAnalyser.Core.Helpers;
using Xunit;

namespace CsvAnalyser.Tests
{
    public class StatsHelperTests
    {
        [Theory]
        [MemberData(nameof(TestSumDecimalData))]
        public void Should_Return_CorrectSum(List<decimal> nums, decimal expectedResult)
        {
            var result = StatsHelper.CalculateSum(nums);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(3, 3, 1)]
        [InlineData(-3, -3, 1)]
        [InlineData(5, 10, 0.5)]
        public void Should_Return_CorrectMean(decimal sum, int count, decimal expectedResult)
        {
            var result = StatsHelper.CalculateMean(sum, count);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [MemberData(nameof(TestStdDecimalData))]
        public void Should_Return_CorrectStandardDeviation(List<decimal> nums, decimal mean, double expectedResult)
        {
            var result = StatsHelper.CalculateStandardDeviation(nums, mean);

            Assert.Equal(expectedResult, result);
        }


        [Theory]
        [MemberData(nameof(TestHistogramData))]
        public void Should_Generate_CorrectHistogram(List<decimal> nums, int binSize, int expectedNumBins)
        {
            var result = StatsHelper.GenerateHistogram(nums, binSize);

            Assert.Equal(expectedNumBins, result.Length);
        }

        public static IEnumerable<object[]> TestSumDecimalData()
        {
            yield return new object[] { new List<decimal>{ 0, 0 }, 0 };
            yield return new object[] { new List<decimal>{ -1, -1 }, -2 };
            yield return new object[] { new List<decimal>{ decimal.MinValue, decimal.MaxValue }, 0 };
        }

        public static IEnumerable<object[]> TestStdDecimalData()
        {
            yield return new object[] { new List<decimal>{ 3, 3 }, 3, 0 };
            yield return new object[] { new List<decimal>{ -3, -3 }, -3, 0 };
            yield return new object[] { new List<decimal>{ 5, 10 }, 7.5, 2.5 };
        }

        public static IEnumerable<object[]> TestHistogramData()
        {
            yield return new object[] { new List<decimal>{ 0, 1, 2, 3, 4 }, 1, 5 };
            yield return new object[] { new List<decimal>{ 0, 55, 56, 57 }, 1, 58 };
            yield return new object[] { new List<decimal>{ 0, 1, 2, 15 }, 5, 4 };

        }
    }
}
