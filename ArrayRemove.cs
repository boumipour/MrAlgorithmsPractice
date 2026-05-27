public class ArrayRemove
{
    /// <summary>
    /// Given an integer array nums and an integer val, remove all occurrences of val in nums in-place. The order of the elements may be changed. Then return the number of elements in nums which are not equal to val.
    /// Consider the number of elements in nums which are not equal to val be k, to get accepted, you need to do the following things:
    /// Change the array nums such that the first k elements of nums contain the elements which are not equal to val. The remaining elements of nums are not important as well as the size of nums.
    /// Return k.
    /// Example 1:
    /// Input: nums = [0,1,2,2,3,0,4,2], val = 2
    /// Output: 5, nums = [0,1,4,0,3,_,_,_]
    /// Explanation: Your function should return k = 5, with the first five elements of nums containing 0, 0, 1, 3, and 4.
    /// Note that the five elements can be returned in any order.
    /// It does not matter what you leave beyond the returned k (hence they are underscores).
    /// </summary>
    /// <returns></returns>
    public int RemoveElement(int[] nums, int val)
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
    /// Given an integer array nums sorted in non-decreasing order, remove the duplicates in-place such that each unique element appears only once. The relative order of the elements should be kept the same.
    /// Consider the number of unique elements in nums to be k​​​​​​​​​​​​​​. After removing duplicates, return the number of unique elements k.
    /// The first k elements of nums should contain the unique numbers in sorted order. The remaining elements beyond index k - 1 can be ignored.
    /// </summary>
    /// <param name="nums">The input array sorted in non-decreasing order</param>
    /// <returns>return the number of unique elements k. The remaining elements beyond index k - 1 can be ignored</returns>
    public int RemoveDuplicateFromSortedArray(int[] nums)
    {
        int k = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[k] == nums[i])
                continue;
            else
                nums[++k] = nums[i];

        }

        return k + 1;
    }


    /// <summary>
    /// Given an integer array nums sorted in non-decreasing order, remove some duplicates in-place such that each unique element appears at most twice. The relative order of the elements should be kept the same.
    /// Since it is impossible to change the length of the array in some languages, you must instead have the result be placed in the first part of the array nums. More formally, if there are k elements after removing the duplicates, then the first k elements of nums should hold the final result. It does not matter what you leave beyond the first k elements.
    /// Return k after placing the final result in the first k slots of nums.
    /// </summary>
    /// <param name="nums">The input array sorted in non-decreasing order</param>
    /// <returns>return the number of elements after removing duplicates</returns>
    public int RemoveDuplicateItemsMoreThanTwoFromSortedArray(int[] nums)
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