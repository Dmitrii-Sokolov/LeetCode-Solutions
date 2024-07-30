/// <summary>
/// 55. Jump Game
/// https://leetcode.com/problems/jump-game
/// 
/// Difficulty Medium
/// Acceptance 38.7%
/// 
/// Array
/// Dynamic Programming
/// Greedy
/// </summary>
class Solution {
    public boolean canJump(int[] nums) {
        var max = 0;
        var current = 0;
        var target = nums.length - 1;

        while (current <= max && max < target) {
            max = Math.max(current + nums[current++], max);
        }

        return max >= target;
    }
}
