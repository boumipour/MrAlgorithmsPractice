namespace Algoritms.ArraysAndStrings;

public class StockProfit
{
    /// <summary>
    /// You are given an array prices where prices[i] is the price of a given stock on the ith day.
    /// You want to maximize your profit by choosing a single day to buy one stock and choosing a different
    /// day in the future to sell that stock.
    /// Example 1:
    /// Input: prices = [7,1,5,3,6,4]
    /// Output: 5
    /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6 - 1 = 5.
    /// </summary>
    /// <param name="prices">Daily stock prices.</param>
    /// <returns>The maximum achievable profit, or 0 if no profit is possible.</returns>
    public int MaxProfit_121(int[] prices)
    {
        int minPrice = int.MaxValue;
        int maxProfit = 0;

        foreach (int price in prices)
        {
            if (price < minPrice)
                minPrice = price;
            else if (price - minPrice > maxProfit)
                maxProfit = price - minPrice;
        }

        return maxProfit;
    }

    /// <summary>
    /// You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
    /// On each day you may buy and/or sell, holding at most one share at any time (you may buy and sell on
    /// the same day). Find and return the maximum profit you can achieve.
    /// Example 1:
    /// Input: prices = [7,1,5,3,6,4]
    /// Output: 7
    /// Explanation: Buy on day 2 (price = 1), sell on day 3 (price = 5), profit = 4. Then buy on day 4
    /// (price = 3), sell on day 5 (price = 6), profit = 3. Total profit is 4 + 3 = 7.
    /// </summary>
    /// <param name="prices">Daily stock prices.</param>
    /// <returns>The maximum achievable profit across multiple transactions.</returns>
    public int MaxProfi_122(int[] prices)
    {
        int profit = 0;

        for (int i = 1; i < prices.Length; i++)
            if (prices[i] > prices[i - 1])
                profit += prices[i] - prices[i - 1];

        return profit;
    }
}
