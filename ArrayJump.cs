public class ArrayJump
{
    /// <summary>
    /// You are given an integer array nums. You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position.
    /// Return true if you can reach the last index, or false otherwise.
    /// Example 1:
    /// Input: nums = [2,3,1,1,4]
    /// Output: true
    /// Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
    /// Example 2:
    /// Input: nums = [3,2,1,0,4]
    /// Output: false
    /// Explanation: You will always arrive at index 3 no matter what. Its maximum jump length is 0, which makes it impossible to reach the last index.
    /// </summary>
    /// <param name="nums">You are given an integer array nums</param>
    /// <returns>Return true if you can reach the last index, or false otherwise.</returns>
    public bool CanJump_55(int[] nums) {
              
       int farthest = 0;
       int n = nums.Length;

        for (int i = 0; i < n; i++)
        {
            if (i > farthest) return false;
            farthest = Math.Max(farthest, i + nums[i]);
        }
     
        return true;
    }


    /// <summary>
    /// You are given a 0-indexed array of integers nums of length n. You are initially positioned at index 0.
    /// Each element nums[i] represents the maximum length of a forward jump from index i. In other words, if you are at index i, you can jump to any index (i + j) where:
    /// 0 <= j <= nums[i] and
    /// i + j < n
    /// Example 1:
    /// Input: nums = [2,3,1,1,4]
    /// Output: 2
    /// Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
    /// Example 2:
    /// Input: nums = [2,3,0,1,4]
    /// Output: 2
    ///Explanation: The minimum number of jumps to reach the last index is 2. Jump 1 step from index 0 to 1, then 3 steps to the last index.
    /// </summary>
    /// <param name="nums">You are given a 0-indexed array of integers nums of length n. You are initially positioned at index 0.</param>
    /// <returns>Return the minimum number of jumps to reach index n - 1. The test cases are generated such that you can reach index n - 1.</returns>
    public int Jump_45(int[] nums)
    {
        int jumps = 0;
        int currentEnd = 0;
        int farthest = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);

            if (i == currentEnd)
            {
                jumps++;
                currentEnd = farthest;
            }
        }

        return jumps;
    }
}