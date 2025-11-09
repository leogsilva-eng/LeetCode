using FluentAssertions;
using StringManipulation.Others;

namespace UnitTests
{
    public class TwoSumTests
    {
        [Theory]
        [MemberData(nameof(MemberData))]
        public void ResultShouldBeAsExpected(int[] data, int target, int[] expectedResult)
        {
            // Arrange            
            var sut = new TwoSum();

            // Act
            // Assert
            sut
               .Run(data, target)
               .Should()
               .BeEquivalentTo(expectedResult);
        }

        public static IEnumerable<object[]> MemberData()
        {
            yield return new object[] { new int[] { 2, 7, 11, 15 }, 9, new int[] { 0, 1 } };

            yield return new object[] { new int[] { 3, 2, 4 }, 6, new int[] { 1, 2 } };

            yield return new object[] { new int[] { 3, 3 }, 6, new int[] { 0, 1 } };
        }
    }
}