/// <summary>
/// 2997. Minimum Number of Operations to Make Array XOR Equal to K
/// https://leetcode.com/problems/minimum-number-of-operations-to-make-array-xor-equal-to-k
/// 
/// Difficulty Medium
/// Acceptance 86.4%
/// 
/// Array
/// Bit Manipulation
/// </summary>
class Solution {
    public int minOperations(int[] nums, int k) {
        for (var num : nums){
            k = k ^ num;
        }

        var result = 0;
        while (k > 0){
            result += k % 2;
            k = k / 2;
        }

        return result;
    }
}
