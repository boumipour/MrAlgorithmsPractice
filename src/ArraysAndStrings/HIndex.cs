namespace Algoritms.ArraysAndStrings;

public class HIndex
{
    /// <summary>
    /// Given an array citations where citations[i] is the number of citations a researcher received
    /// for their ith paper, return the researcher's h-index.
    /// The h-index is defined as the maximum value h such that the researcher has published at least h
    /// papers that have each been cited at least h times.
    /// Example 1:
    /// Input: citations = [3,0,6,1,5]
    /// Output: 3
    /// Explanation: There are 3 papers with at least 3 citations each (the papers with 3, 6 and 5
    /// citations), so the h-index is 3.
    /// </summary>
    /// <param name="citations">Citation counts, one per paper.</param>
    /// <returns>The researcher's h-index.</returns>
    public int HIndex_274(int[] citations)
    {
        Array.Sort(citations);
        Array.Reverse(citations);

        int n = citations.Length;
        int h = 0;

        for (int i = 0; i < n; i++)
        {
            if (citations[i] >= i + 1)
            {
                h = i + 1;
            }
            else
            {
                break;
            }
        }

        return h;
    }

    /// <summary>
    /// Improved-performance h-index using counting sort instead of comparison sorting.
    /// A paper can never contribute an h larger than the total number of papers n, so any citation
    /// count above n is capped at n. We bucket the papers by citation count, then sweep from the
    /// highest bucket downward accumulating how many papers have "at least i" citations; the first
    /// i where that running count reaches i is the h-index. This runs in O(n) time, O(n) space —
    /// faster than the O(n log n) sort above.
    /// Example 1:
    /// Input: citations = [3,0,6,1,5]
    /// Output: 3
    /// Explanation: 3 papers have at least 3 citations each, so the h-index is 3.
    /// </summary>
    /// <param name="citations">Citation counts, one per paper.</param>
    /// <returns>The researcher's h-index.</returns>
    public int HIndex_274_Counting(int[] citations)
    {
        int n = citations.Length;
        int[] buckets = new int[n + 1];

        foreach (int c in citations)
            buckets[Math.Min(c, n)]++;

        int count = 0;
        for (int i = n; i >= 0; i--)
        {
            count += buckets[i];
            if (count >= i)
                return i;
        }

        return 0;
    }
}
