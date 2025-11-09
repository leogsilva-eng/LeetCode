namespace LeetCode.TwoPointers
{
    /*
    https://leetcode.com/problems/remove-duplicates-from-sorted-array/
    Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
    Consider the number of unique elements in nums to be k​​​​​​​​​​​​​​. After removing duplicates, return the number of unique elements k.
    The first k elements of nums should contain the unique numbers in sorted order. The remaining elements beyond index k - 1 can be ignored.

    Should result length without duplicates and the modified array must be returned by reference.
    */

    public class RemoveDuplicatesFromSortedArray
    {
        public int RemoveDuplicates(int[] nums)
        {
            int result = 0;
            int currentNumber = nums[0] - 1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != currentNumber)
                {
                    result++;
                    currentNumber = nums[i];
                    nums[result - 1] = nums[i];
                }
            }

            return result;
        }
    }

    public class RemoveDuplicatesFromSortedArrayTests
    {
        [Theory]
        [InlineData(new int[] { 1, 1, 2 }, 2, new int[] { 1, 2 })]
        [InlineData(new int[] { 0,0,1,1,1,2,2,3,3,4 }, 5, new int[] { 0,1,2,3,4 })]
        [InlineData(new int[] { 1,2,3,4,5 }, 5, new int[] { 1,2,3,4,5 })]
        [InlineData(new int[] { 1,1,1,1,1 }, 1, new int[] { 1 })]
        public void RemoveDuplicates_ShouldReturnCorrectLengthAndModifyArray(int[] input, int expectedLength, int[] expectedArray)
        {
            // Arrange
            var sut = new RemoveDuplicatesFromSortedArray();
            // Act
            int resultLength = sut.RemoveDuplicates(input);
            // Assert
            Assert.Equal(expectedLength, resultLength);
            for (int i = 0; i < expectedLength; i++)
            {
                Assert.Equal(expectedArray[i], input[i]);
            }
        }
    }
}