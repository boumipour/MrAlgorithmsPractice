Console.WriteLine("Hello, IT World!");

Solution solution = new Solution();
int[] nums = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
int val = 2;
int result = solution.RemoveElement(nums, val);
Console.WriteLine($"Result: {nums}");

public class Solution
{
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
}