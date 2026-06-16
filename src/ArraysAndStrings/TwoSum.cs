namespace Algoritms.ArraysAndStrings;

public class TwoSum
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers
    /// such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use
    /// the same element twice.
    /// Brute-force approach: for every pair (i, j) check whether nums[i] + nums[j] == target.
    /// Example 1:
    /// Input: nums = [2,7,11,15], target = 9
    /// Output: [0,1]
    /// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    /// </summary>
    /// <param name="nums">Array of integers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>Indices of the two numbers that add up to target.</returns>
    public int[] TwoSum_1(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                    return [i, j];
            }
        }

        return [];
    }

    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers
    /// such that they add up to target.
    /// You may assume that each input would have exactly one solution, and you may not use
    /// the same element twice.
    /// Hash-map approach: for each element record its index in a dictionary; before inserting,
    /// check whether the complement (target - nums[i]) is already present. One pass, O(n) time.
    /// Example 1:
    /// Input: nums = [2,7,11,15], target = 9
    /// Output: [0,1]
    /// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    /// </summary>
    /// <param name="nums">Array of integers.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>Indices of the two numbers that add up to target.</returns>
    public int[] TwoSum_1_HashMap(int[] nums, int target)
    {
        Dictionary<int, int> map = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int need = target - nums[i];

            if (map.ContainsKey(need))
                return [map[need], i];

            map[nums[i]] = i;
        }

        return [];
    }
}
