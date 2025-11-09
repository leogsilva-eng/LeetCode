using FluentAssertions;
using StringManipulation;

namespace UnitTests
{
    public class BiggerPrefixInAListTests
    {
        [Theory]
        [MemberData(nameof(MemberData))]
        public void PrefixFoundedShouldBeAsExpected(string[] data, string prefix)
        {
            // Arrange            
            var sut = new BiggerPrefixInAList();

            // Act
            // Assert
            sut.LongestCommonPrefix(data).Should().Be(prefix);

        }

        public static IEnumerable<object[]> MemberData()
        {
            yield return new object[] { new string[] { "flower", "flow", "flight" }, "fl" };
            yield return new object[] { new string[] { "dog", "racecar", "car" }, "" };
            yield return new object[] { new string[] { "ab", "a"}, "a" };
            yield return new object[] { new string[] { "a" }, "a" };
        }
    }
}