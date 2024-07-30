/// <summary>
/// 45. Jump Game II
/// https://leetcode.com/problems/jump-game-ii
/// 
/// Difficulty Medium
/// Acceptance 40.6%
/// 
/// Array
/// Dynamic Programming
/// Greedy
/// </summary>
class Solution {
    public int jump(int[] nums) {
        var max = 0;
        var min = 0;
        var step = 0;

        while (max < nums.length - 1) {
            var limit = max;
            for (var i = min; i <= limit; i++) {
                max = Math.max(max, i + nums[i]);
            }
            min = limit;
            step++;
        } 

        return step;
    }
}
