using FluentAssertions;

namespace StringManipulation
{
    /*
     https://leetcode.com/problems/longest-common-prefix/description/
    
    Write a function to find the longest common prefix string amongst an array of strings.
    If there is no common prefix, return an empty string "".
     */
    public class BiggerPrefixInAList
    {
        private Dictionary<int, string> prefixesSize = [];

        public string LongestCommonPrefix(string[] strs)
        {
            if (strs.Length == 1)
                return strs[0];

            string result = "";

            Array.Sort(strs);

            var firstStr = strs[0];
            var lastStr = strs[strs.Length - 1];

            var lengthToSearch =
                firstStr.Length < lastStr.Length ?
                firstStr.Length :
                lastStr.Length;

            int maxLenght = 0;
            int possibleMaxLength = 0;

            for (int j = 1; j <= lengthToSearch; j++)
            {
                if (firstStr[..j] == lastStr[..j])
                {
                    if (!prefixesSize.Any(x => x.Key == j))
                        prefixesSize.Add(j, firstStr[..j]);

                    if (maxLenght < j)
                        maxLenght = j;

                    continue;
                }

                break;
            }

            if (maxLenght == 0)
                return "";

            return prefixesSize[maxLenght];
        }
    }

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
            yield return new object[] { new string[] { "ab", "a" }, "a" };
            yield return new object[] { new string[] { "a" }, "a" };
        }
    }
}