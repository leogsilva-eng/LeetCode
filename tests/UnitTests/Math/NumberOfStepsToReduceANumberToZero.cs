namespace LeetCode.Math
{
    /*
     https://leetcode.com/problems/number-of-steps-to-reduce-a-number-to-zero/description/

     Given an integer num, return the number of steps to reduce it to zero.
     In one step, 
        if the current number is even, you have to divide it by 2, 
        otherwise, you have to subtract 1 from it.
     */

    public class NumberOfStepsToReduceANumberToZero
    {
        public int NumberOfSteps(int num)
        {
            var count = 0;
            while (num > 0)
            {
                if (num % 2 == 0)
                    num = num / 2;
                else
                    num--;

                count++;
            }

            return count;
        }
    }

    public class NumberOfStepsToReduceANumberToZeroTests
    {
        private readonly NumberOfStepsToReduceANumberToZero _sut;

        public NumberOfStepsToReduceANumberToZeroTests()
        {
            _sut = new NumberOfStepsToReduceANumberToZero();
        }

        [Theory]
        [InlineData(0, 0)]           // Edge case: starting with zero
        [InlineData(1, 1)]           // Smallest odd number
        [InlineData(2, 2)]           // Smallest even number > 1
        [InlineData(14, 6)]          // Example with both even and odd steps: 14→7→6→3→2→1→0
        [InlineData(8, 4)]           // Power of 2: 8→4→2→1→0
        [InlineData(123, 12)]        // Larger number: 123→122→61→60→30→15→14→7→6→3→2→1→0
        [InlineData(1000000, 26)]    // Large number to test performance
        public void NumberOfSteps_ShouldReturnCorrectStepCount(int input, int expectedSteps)
        {
            // Act
            int result = _sut.NumberOfSteps(input);

            // Assert
            Assert.Equal(expectedSteps, result);
        }

        [Fact]
        public void NumberOfSteps_VerifyStepByStepReduction()
        {
            // Arrange
            int number = 14;
            int[] expectedSequence = { 14, 7, 6, 3, 2, 1, 0 };
            var actualSequence = new System.Collections.Generic.List<int>();

            // Act & Assert
            while (number >= 0)
            {
                actualSequence.Add(number);
                if (number == 0) break;

                if (number % 2 == 0)
                    number /= 2;
                else
                    number--;
            }

            Assert.Equal(expectedSequence, actualSequence);
        }

        [Theory]
        [InlineData(15)]     // 15→14→7→6→3→2→1→0 (7 steps)
        [InlineData(16)]     // 16→8→4→2→1→0 (5 steps)
        public void NumberOfSteps_ShouldAlwaysTerminate(int input)
        {
            // Act
            int result = _sut.NumberOfSteps(input);

            // Assert
            Assert.True(result > 0);

            // Verify the number actually reduces to zero
            int num = input;
            for (int i = 0; i < result; i++)
            {
                if (num % 2 == 0)
                    num /= 2;
                else
                    num--;
            }
            Assert.Equal(0, num);
        }
    }
}