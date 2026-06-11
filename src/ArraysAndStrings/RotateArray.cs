namespace Algoritms.ArraysAndStrings;

public class RotateArray
{
    /// <summary>
    /// Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
    /// This implementation copies each element to its rotated position in an auxiliary array.
    /// Example 1:
    /// Input: nums = [1,2,3,4,5,6,7], k = 3
    /// Output: [5,6,7,1,2,3,4]
    /// </summary>
    /// <param name="nums">The array to rotate in-place.</param>
    /// <param name="k">The number of steps to rotate to the right.</param>
    public void Rotate_189_Simple(int[] nums, int k)
    {
        if (k <= 0 || nums.Length <= 1 || k == nums.Length)
            return;

        int[] temp = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            int index = i + k;
            if (index >= nums.Length)
                index -= nums.Length;

            temp[index] = nums[i];
        }

        Array.Copy(temp, nums, nums.Length);
    }

    /// <summary>
    /// Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
    /// This implementation rotates in O(1) extra space using the triple-reverse technique.
    /// Example 1:
    /// Input: nums = [1,2,3,4,5,6,7], k = 3
    /// Output: [5,6,7,1,2,3,4]
    /// </summary>
    /// <param name="nums">The array to rotate in-place.</param>
    /// <param name="k">The number of steps to rotate to the right.</param>
    public void Rotate_189_Advanced(int[] nums, int k)
    {
        int n = nums.Length;

        if (n <= 1)
            return;

        k %= n;

        if (k == 0)
            return;

        // Reverse whole array
        for (int left = 0, right = n - 1; left < right; left++, right--)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
        }

        // Reverse first k elements
        for (int left = 0, right = k - 1; left < right; left++, right--)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
        }

        // Reverse remaining elements
        for (int left = k, right = n - 1; left < right; left++, right--)
        {
            (nums[left], nums[right]) = (nums[right], nums[left]);
        }
    }
}
