namespace Algoritms.ArraysAndStrings;

public class RemoveElements
{
    /// <summary>
    /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place.
    /// The order of the elements may be changed. Then return the number of elements in nums which are not
    /// equal to val. The first k elements of nums must contain the elements which are not equal to val.
    /// Example 1:
    /// Input: nums = [0,1,2,2,3,0,4,2], val = 2
    /// Output: 5, nums = [0,1,4,0,3,_,_,_]
    /// </summary>
    /// <param name="nums">The input array.</param>
    /// <param name="val">The value to remove.</param>
    /// <returns>The number of elements not equal to val (k).</returns>
    public int RemoveElement_27(int[] nums, int val)
    {
        int k = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val)
            {
                nums[k] = nums[i];
                k++;
            }
        }

        return k;
    }

    /// <summary>
    /// Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that
    /// each unique element appears only once. The relative order of the elements should be kept the same.
    /// The first k elements of nums should contain the unique numbers in sorted order.
    /// </summary>
    /// <param name="nums">The input array sorted in non-decreasing order.</param>
    /// <returns>The number of unique elements (k).</returns>
    public int RemoveDuplicates_26(int[] nums)
    {
        int k = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[k] == nums[i])
                continue;

            nums[++k] = nums[i];
        }

        return k + 1;
    }

    /// <summary>
    /// Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that
    /// each unique element appears at most twice. The relative order of the elements should be kept the same.
    /// The first k elements of nums should hold the final result.
    /// </summary>
    /// <param name="nums">The input array sorted in non-decreasing order.</param>
    /// <returns>The number of elements after removing duplicates (k).</returns>
    public int RemoveDuplicatesII_80(int[] nums)
    {
        int k = 1;
        for (int i = 2; i < nums.Length; i++)
        {
            if (nums[i] != nums[i - 2])
                k++;

            nums[k] = nums[i];
        }

        return k + 1;
    }
}
