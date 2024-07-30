/// <summary>
/// 6. Zigzag Conversion
/// https://leetcode.com/problems/zigzag-conversion
/// 
/// Difficulty Medium
/// Acceptance 48.8%
/// 
/// String
/// </summary>
class Solution {
    public String convert(String s, int numRows) {
        if (numRows == 1 || s.length() == 1) {
            return s;
        }

        var period = 2 * numRows - 2;
        var result = new StringBuilder();
        var p = 0;

        while (p < s.length()) {
            result.append(s.charAt(p));
            p += period;
        }

        for (var row = 1; row < numRows - 1; row++) {
            var step = period - 2 * row;
            p = row;
            while (p < s.length()) {
                result.append(s.charAt(p));
                p += step;
                step = period - step;
            }
        }

        p = numRows - 1;
        while (p < s.length()) {
            result.append(s.charAt(p));
            p += period;
        }

        return result.toString();
    }
}
