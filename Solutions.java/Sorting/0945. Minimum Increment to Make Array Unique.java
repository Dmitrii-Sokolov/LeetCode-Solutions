/// <summary>
/// 945. Minimum Increment to Make Array Unique
/// https://leetcode.com/problems/minimum-increment-to-make-array-unique
/// 
/// Difficulty Medium
/// Acceptance 60.0%
/// 
/// Array
/// Greedy
/// Sorting
/// Counting
/// </summary>
class Solution {
    public int minIncrementForUnique(int[] nums) {
        var max = 0;
        for (var n : nums) {
            max = Math.max(n, max);
        }        

        var len = max + nums.length;
        var counts = new int[len];
        for (var n : nums) {
            counts[n]++;
        }

        var result = 0;
        for (var i = 0; i < len; i++) {
            if (counts[i] > 1) {
                result += counts[i] - 1;
                counts[i + 1] += counts[i] - 1;
            }
        }
        return result;
    }
}
