public class ArrayRotate
{
    /// <summary>
    /// Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
    /// Example 1:
    /// Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    /// Output: [1,2,2,3,5,6]
    /// Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
    /// The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
     public void Rotate_189_Simple(int[] nums, int k) {
        
        if(k <= 0 || nums.Length <= 1 || k== nums.Length)
            return;
        
        int[] temp = new int[nums.Length];
        
        for(int i = 0; i < nums.Length; i++)
        {
            int index = (i+k);
            if(index >= nums.Length)
                index = index - nums.Length;

            temp[index] = nums[i];
        }

       Array.Copy(temp, nums, nums.Length);
    }

    /// <summary>
    /// Given an integer array nums, rotate the array to the right by k steps, where k is non-negative.
    /// /// Example 1:
    /// Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    /// Output: [1,2,2,3,5,6]
    /// Explanation: The arrays we are merging are [1,2,3] and [2,5,6].
    /// The result of the merge is [1,2,2,3,5,6] with the underlined elements coming from nums1.
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="k"></param>
     public void Rotate_189_Advance(int[] nums, int k) {
        
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