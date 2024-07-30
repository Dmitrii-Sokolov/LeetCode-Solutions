/// <summary>
/// 1208. Get Equal Substrings Within Budget
/// https://leetcode.com/problems/get-equal-substrings-within-budget
/// 
/// Difficulty Medium
/// Acceptance 58.3%
/// 
/// String
/// Binary Search
/// Sliding Window
/// Prefix Sum
/// </summary>
class Solution {
    public int equalSubstring(String s, String t, int maxCost) {
        this.s = s;
        this.t = t;
        var result = 0;
        var min = 0;
        var max = -1;
        var cost = 0;

        while (max < t.length() - 1 && min < t.length()) {
            while (max < t.length() - 1 && cost + cost(max + 1) <= maxCost) {
                max++;
                cost += cost(max);
            }
            result = Math.max(max - min + 1, result);

            cost -= cost(min);
            min++;
        }

        return result;
    }

    private String s;
    private String t;

    private int cost(int p) {
        return Math.abs(s.charAt(p) - t.charAt(p));
    }
}
