using FluentAssertions;

namespace LeetCode.TwoPointers
{
    /*
    https://leetcode.com/problems/two-sum/description/
    
    Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    You may assume that each input would have exactly one solution, and you may not use the same element twice.
    You can return the answer in any order.
    */

    public class TwoSum
    {
        public int[] Run(int[] nums, int target)
        {
            return
            //BruteForce(nums, target)
            //Sorting_TwoPointers(nums, target)
            HashMap(nums, target)
            ;
        }

        private int[] HashMap(int[] nums, int target)
        {
            Dictionary<int, int> hashMap = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (hashMap.TryGetValue(nums[i], out int result))                
                    return new int[] { i, result };

                hashMap.TryAdd(target - nums[i], i);
            }

            return new int[] { 0 };
        }

        private int[] Sorting_TwoPointers(int[] nums, int target)
        {
            var numsOriginal = nums;
            Array.Sort(nums);
            int i = 0;
            int j = nums.Length - 1;
            bool stop = false;

            while (!stop)
            {
                Console.WriteLine($"I e J: {i} - {j}");

                if (nums[i] + nums[j] == target)
                {
                    Console.WriteLine($"Igual a target: I:{i} - J:{j}");
                    stop = true;
                }

                if (nums[i] + nums[j] > target)
                {
                    Console.WriteLine($"Maior a target: I:{i} - J:{j}");
                    j--;
                }

                if (nums[i] + nums[j] < target)
                {
                    Console.WriteLine($"Menor a target: I:{i} - J:{j}");
                    i++;
                }

            }

            return new int[] { i, j };

        }

        private int[] BruteForce(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                        return new int[]
                        {
                            i,
                            j
                        };
                }
            }

            return new int[]
                        {
                            0,
                            0
                        };
        }
    }

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

