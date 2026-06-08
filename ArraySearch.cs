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

    /// <summary>
    /// You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.
    /// Example 1:
    /// Input: prices = [7,1,5,3,6,4]
    /// Output: 5
    /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
    /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
    /// </summary>
    /// <param name="prices"> You are given an array prices where prices[i] is the price of a given stock on the ith day.</param>
    /// <returns>Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.</returns>
     public int MaxProfit_121(int[] prices) {
        
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices) {
            if (price < minPrice) {
                minPrice = price;
            } else if (price - minPrice > maxProfit) {
                maxProfit = price - minPrice;
            }
        }

      return maxProfit;

    }
}
