using System.Text;

namespace Algoritms.ArraysAndStrings;

public class IntegerToRoman
{
    /// <summary>
    /// Given an integer num, convert it to a roman numeral.
    /// Roman numerals use seven symbols: I=1, V=5, X=10, L=50, C=100, D=500, M=1000.
    /// Subtraction rules apply when a smaller value precedes a larger one
    /// (e.g. IV=4, IX=9, XL=40, XC=90, CD=400, CM=900).
    /// Each digit (thousands, hundreds, tens, ones) maps to a fixed roman string, so the result is
    /// just a lookup and concatenation per digit.
    /// Example 1:
    /// Input: num = 3
    /// Output: "III"
    /// Example 2:
    /// Input: num = 58
    /// Output: "LVIII"
    /// Example 3:
    /// Input: num = 1994
    /// Output: "MCMXCIV"
    /// </summary>
    /// <param name="num">An integer in the range [1, 3999].</param>
    /// <returns>The roman numeral representation of num.</returns>
    public string IntToRoman_12(int num)
    {
        string[] thousands = { "", "M", "MM", "MMM" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

        return thousands[num / 1000] +
               hundreds[(num % 1000) / 100] +
               tens[(num % 100) / 10] +
               ones[num % 10];
    }

    /// <summary>
    /// Greedy alternative: repeatedly subtract the largest roman value (including the six
    /// subtractive pairs CM, CD, XC, XL, IX, IV) that still fits into num, appending its symbol
    /// each time. Values are tried from largest to smallest so the result is built most-significant
    /// symbol first.
    /// Example 1:
    /// Input: num = 3
    /// Output: "III"
    /// Example 2:
    /// Input: num = 58
    /// Output: "LVIII"
    /// Example 3:
    /// Input: num = 1994
    /// Output: "MCMXCIV"
    /// </summary>
    /// <param name="num">An integer in the range [1, 3999].</param>
    /// <returns>The roman numeral representation of num.</returns>
    public string IntToRoman_12_Greedy(int num)
    {
        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        var result = new StringBuilder();

        for (int i = 0; i < values.Length; i++)
        {
            while (num >= values[i])
            {
                result.Append(symbols[i]);
                num -= values[i];
            }
        }

        return result.ToString();
    }
}
