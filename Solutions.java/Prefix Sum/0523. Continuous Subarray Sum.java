/// <summary>
/// 523. Continuous Subarray Sum
/// https://leetcode.com/problems/continuous-subarray-sum
/// 
/// Difficulty Medium
/// Acceptance 30.3%
/// 
/// Array
/// Hash Table
/// Math
/// Prefix Sum
/// </summary>
class Solution {
    public boolean checkSubarraySum(int[] nums, int k) {
        if (nums.length < 2) {
            return false;
        }

        var set = new HashSet<Integer>();
        var sum = 0;
        var prevSum = 0;

        for (var i = 0; i < nums.length; i++) {
            prevSum = sum;
            sum = (sum % k + nums[i] % k) % k;
            if (set.contains(sum)) {
                return true;
            }
            set.add(prevSum);
        }
        
        return false;
    }
}
