/// <summary>
/// 976. Largest Perimeter Triangle
/// https://leetcode.com/problems/largest-perimeter-triangle
/// 
/// Difficulty Easy
/// Acceptance 56.2%
/// 
/// Array
/// Math
/// Greedy
/// Sorting
/// </summary>
class Solution {
    public int largestPerimeter(int[] nums) {
        for (var i = 0; i < nums.length; i++) {
            var max = i;
            for (var k = i; k < nums.length; k++) {
                if (nums[k] > nums[max]) {
                    max = k;
                }
            }

            var temp = nums[i];
            nums[i] = nums[max];
            nums[max] = temp;

            if (i > 1) {
                if (nums[i] + nums[i - 1] > nums[i - 2]) {
                    return nums[i] + nums[i - 1] + nums[i - 2];
                }
            }
        }

        return 0;
    }
}
