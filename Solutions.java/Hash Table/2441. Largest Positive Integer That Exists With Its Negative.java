/// <summary>
/// 2441. Largest Positive Integer That Exists With Its Negative
/// https://leetcode.com/problems/largest-positive-integer-that-exists-with-its-negative
/// 
/// Difficulty Easy
/// Acceptance 75.1%
/// 
/// Array
/// Hash Table
/// Two Pointers
/// Sorting
/// </summary>
class Solution {
    public int findMaxK(int[] nums) {
        var counts = new int[1000];
        var result = -1;

        for (var num : nums){
            var index = Math.abs(num) - 1;

            if (num > 0)
                counts[index] |= 1;

            if (num < 0)
                counts[index] |= 2;

            if (counts[index] == 3)
                result = Math.max(result, index + 1);
        }

        return result;
    }
}
