namespace LeetCode.StringManipulation
{
    public class RomanNumbersConverter
    {
        private int toBeAdded = 0;
        private char lastChar = 'M';

        public int RomanToInt(string s)
        {
            var result = 0;
            foreach (char actualChar in s)
            {
                if (IsLastCharLess(actualChar))
                {
                    toBeAdded += RomanValues[actualChar] - (RomanValues[lastChar] * 2);

                    lastChar = actualChar;

                    continue;
                }

                toBeAdded += RomanValues[actualChar];

                result += toBeAdded;

                toBeAdded = 0;
                lastChar = actualChar;
            }

            if (toBeAdded > 0)
                result += toBeAdded;

            return result;
        }

        private bool IsLastCharLess(char actualChar)
        {
            return RomanValues[lastChar] < RomanValues[actualChar];
        }

        private Dictionary<char, int> RomanValues =>
            new Dictionary<char, int>(){
            {'I', 1},
            {'V', 5},
            {'X',10},
            {'L',50},
            {'C',100},
            {'D',500},
            {'M',1000}
            };
    }

    public partial class RomanNumbersConverterTests
    {
        [Theory]
        [InlineData("III", 3)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        [InlineData("MCMXCIII", 1993)]
        [InlineData("MMDCCLXXV", 2775)]
        [InlineData("MDXVII", 1517)]
        [InlineData("MMMCDXXXIII", 3433)]
        public void ConversionResultShouldBeAsExpected(string romanNumber, int expectedResult)
        {
            // Arrange
            var converter = new RomanNumbersConverter();
            // Act
            var result = converter.RomanToInt(romanNumber);
            // Assert
            Assert.Equal(expectedResult, result);

        }
    }
}