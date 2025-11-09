namespace LeetCode.TwoPointers
{
    public class CountOperationsToObtainZero
    {
        public static int CountOperationsBruteForce(int num1, int num2)
        {
            int count = 0;
            while (num1 != 0 && num2 != 0)
            {
                if (num1 >= num2)
                    num1 -= num2;
                else
                    num2 -= num1;
                count++;
            }
            return count;
        }

        public static int CountOperationsOptimized(int num1, int num2)
        {
            int count = 0;
            while (num1 != 0 && num2 != 0)
            {
                if (num1 >= num2)
                {
                    count += num1 / num2;
                    num1 = num1 % num2;
                }
                else
                {
                    count += num2 / num1;
                    num2 = num2 % num1;
                }
            }
            return count;
        }
    }

    public class CountOperationsToObtainZeroTests
    {
        [Theory]
        [InlineData(2, 3, 3)]        // Basic case where num2 > num1
        [InlineData(10, 10, 1)]      // Equal numbers
        [InlineData(3, 2, 3)]        // Basic case where num1 > num2
        [InlineData(0, 1, 0)]        // Edge case with zero
        [InlineData(1, 0, 0)]        // Edge case with zero
        [InlineData(2, 1, 2)]        // Simple case
        [InlineData(100, 25, 4)]     // Case with division
        public void CountOperationsBruteForce_ShouldReturnCorrectCount(int num1, int num2, int expected)
        {
            // Act
            int result = CountOperationsToObtainZero.CountOperationsBruteForce(num1, num2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 3, 3)]        // Basic case where num2 > num1
        [InlineData(10, 10, 1)]      // Equal numbers
        [InlineData(3, 2, 3)]        // Basic case where num1 > num2
        [InlineData(0, 1, 0)]        // Edge case with zero
        [InlineData(1, 0, 0)]        // Edge case with zero
        [InlineData(2, 1, 2)]        // Simple case
        [InlineData(100, 25, 4)]     // Case with division
        public void CountOperationsOptimized_ShouldReturnCorrectCount(int num1, int num2, int expected)
        {
            // Act
            int result = CountOperationsToObtainZero.CountOperationsOptimized(num1, num2);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void BothImplementations_ShouldReturnSameResults()
        {
            // Arrange
            int[,] testCases = new int[,] {
                { 15, 7 },
                { 50, 10 },
                { 123, 45 },
                { 1000, 3 }
            };

            for (int i = 0; i < testCases.GetLength(0); i++)
            {
                int num1 = testCases[i, 0];
                int num2 = testCases[i, 1];

                // Act
                int bruteForceResult = CountOperationsToObtainZero.CountOperationsBruteForce(num1, num2);
                int optimizedResult = CountOperationsToObtainZero.CountOperationsOptimized(num1, num2);

                // Assert
                Assert.Equal(bruteForceResult, optimizedResult);
            }
        }
    }
}
