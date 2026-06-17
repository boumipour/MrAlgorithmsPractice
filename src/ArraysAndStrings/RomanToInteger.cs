namespace Algoritms.ArraysAndStrings;

public class RomanToInteger
{
    /// <summary>
    /// Given a roman numeral string s, convert it to an integer.
    /// Roman numerals use seven symbols: I=1, V=5, X=10, L=50, C=100, D=500, M=1000.
    /// Subtraction rules apply when a smaller value precedes a larger one
    /// (e.g. IV=4, IX=9, XL=40, XC=90, CD=400, CM=900).
    /// Walk left to right: if the current symbol is less than the next, subtract it; otherwise add it.
    /// Example 1:
    /// Input: s = "III"
    /// Output: 3
    /// Example 2:
    /// Input: s = "LVIII"
    /// Output: 58
    /// Example 3:
    /// Input: s = "MCMXCIV"
    /// Output: 1994
    /// </summary>
    /// <param name="s">A valid roman numeral string (I, V, X, L, C, D, M).</param>
    /// <returns>The integer value of the roman numeral.</returns>
    public int RomanToInt_13(string s)
    {
        Dictionary<char, int> dict = new()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };

        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (i + 1 < s.Length && dict[s[i]] < dict[s[i + 1]])
            {
                result -= dict[s[i]];
            }
            else
            {
                result += dict[s[i]];
            }
        }

        return result;
    }
}
