using StringManipulation;

namespace UnitTests
{
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
