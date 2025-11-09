namespace StringManipulation.TwoPointers
{
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
}

