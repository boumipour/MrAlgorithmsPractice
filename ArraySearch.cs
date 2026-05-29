public class ArraySearch
{

    /// <summary>
    /// Given an array nums of size n, return the majority element.
    /// The majority element is the element that appears more than ⌊n / 2⌋ times. You may assume that the majority element always exists in the array.
    /// Example 1:
    /// Input: nums = [2,2,1,1,1,2,2]
    /// Output: 2
    /// </summary>
    /// <param name="nums"></param>
    /// <returns>Major item</returns>
    public int MajorityElement_169(int[] nums)
    {
        // Boyer-Moore Voting Algorithm
        int candidate = 0;
        int count = 0;

        foreach (int num in nums)
        {
            if (count == 0)
                candidate = num;

            count += num == candidate ? 1 : -1;
        }

        return candidate;
    }
}
