namespace Algoritms.ArraysAndStrings;

public class MergeSortedArray
{
    /// <summary>
    /// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers
    /// m and n, representing the number of elements in nums1 and nums2 respectively.
    /// Merge nums1 and nums2 into a single array sorted in non-decreasing order, stored inside nums1.
    /// Example 1:
    /// Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
    /// Output: [1,2,2,3,5,6]
    /// Example 2:
    /// Input: nums1 = [1], m = 1, nums2 = [], n = 0
    /// Output: [1]
    /// Example 3:
    /// Input: nums1 = [0], m = 0, nums2 = [1], n = 1
    /// Output: [1]
    /// Note that because m = 0 there are no elements in nums1; the 0 is only there so the merge result fits.
    /// </summary>
    /// <param name="nums1">Destination array with m valid elements followed by n placeholder slots.</param>
    /// <param name="m">Number of valid elements in nums1.</param>
    /// <param name="nums2">Source array with n elements.</param>
    /// <param name="n">Number of elements in nums2.</param>
    public void Merge_88(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = 0; i < n; i++)
            nums1[m + i] = nums2[i];

        Array.Sort(nums1);
    }
}
