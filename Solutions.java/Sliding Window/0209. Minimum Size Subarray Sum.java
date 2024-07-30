/// <summary>
/// 209. Minimum Size Subarray Sum
/// https://leetcode.com/problems/minimum-size-subarray-sum
/// 
/// Difficulty Medium
/// Acceptance 47.5%
/// 
/// Array
/// Binary Search
/// Sliding Window
/// Prefix Sum
/// </summary>
class Solution {
    public int minSubArrayLen(int target, int[] nums) {
        var left = 0;
        var right = 0;
        var result = 1000000;
        target = -target;

        while (right <= nums.length) {
            while (left < nums.length && target >= nums[left]) {
                target -= nums[left];
                left++;
            }

            if (target >= 0) {
                result = Math.min(result, right - left);
            }

            if (right == nums.length) {
                break;
            }

            do {
                target += nums[right];
                right++;
            } while (right < nums.length && target < 0);
        }
            
        return result == 1000000 ? 0 : result;
    }
}
