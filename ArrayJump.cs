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
}