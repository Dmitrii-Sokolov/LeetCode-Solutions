/// <summary>
/// 1509. Minimum Difference Between Largest and Smallest Value in Three Moves
/// https://leetcode.com/problems/minimum-difference-between-largest-and-smallest-value-in-three-moves
/// 
/// Difficulty Medium
/// Acceptance 59.2%
/// 
/// Array
/// Greedy
/// Sorting
/// </summary>
class Solution {
	public int minDifference(int[] nums) {
		if (nums.length <= 4) {
			return 0;
		}

		int[] mins = {Integer.MAX_VALUE, Integer.MAX_VALUE, Integer.MAX_VALUE, Integer.MAX_VALUE};
		int[] maxs = {Integer.MIN_VALUE, Integer.MIN_VALUE, Integer.MIN_VALUE, Integer.MIN_VALUE};
		for (var i = 0; i < nums.length; i++) {
			var a = nums[i];
			if (a < mins[3]) {
				mins[3] = a;
				Arrays.sort(mins);
			}
			if (a > maxs[0]) {
				maxs[0] = a;
				Arrays.sort(maxs);
			}
		}

		var result = Integer.MAX_VALUE;
		for (var i = 0; i < 4; i++) {
			result = Math.min(result, maxs[i] - mins[i]);
		}
		return result;
	}
}
