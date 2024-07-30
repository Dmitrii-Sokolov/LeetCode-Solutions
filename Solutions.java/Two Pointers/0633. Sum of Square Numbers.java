/// <summary>
/// 633. Sum of Square Numbers
/// https://leetcode.com/problems/sum-of-square-numbers
/// 
/// Difficulty Medium
/// Acceptance 36.6%
/// 
/// Math
/// Two Pointers
/// Binary Search
/// </summary>
class Solution {
    public boolean judgeSquareSum(int c) {
        var a = (int) Math.floor(Math.sqrt(c));
        var a2 = a * a;
        var b = 0;
        var b2 = b * b;

        while (b <= a) {
            var diff = c - a2 - b2;
            if (diff < 0) {
                a--;
                a2 = a * a;
            } else if (diff > 0) {
                b++;
                b2 = b * b;
            } else {
                return true;
            }
        }

        return false;
    }
}
