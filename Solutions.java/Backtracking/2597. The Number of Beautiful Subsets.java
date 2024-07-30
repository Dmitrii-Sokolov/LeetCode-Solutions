/// <summary>
/// 2597. The Number of Beautiful Subsets
/// https://leetcode.com/problems/the-number-of-beautiful-subsets
/// 
/// Difficulty Medium
/// Acceptance 51.2%
/// 
/// Array
/// Hash Table
/// Math
/// Dynamic Programming
/// Backtracking
/// Sorting
/// Combinatorics
/// </summary>
class Solution {
    public int beautifulSubsets(int[] nums, int k) {
        this.nums = nums;
        this.k = k;

        Arrays.sort(this.nums);
        Check(0);

        return result;
    }

    private int[] nums;
    private int k;

    private int[] counts = new int[1001];
    private int result;

    private void Check(int p) {
        if (p == nums.length) {
            return;
        }

        var n = nums[p];
        var shift1 = n - k;
        var shift2 = n + k;

        if ((shift1 < 0 || shift1 >= 1001 ||
            counts[shift1] == 0) &&
            ((shift2 < 0 || shift2 >= 1001 ||
            counts[shift2] == 0))) {
            counts[n]++;
            Check(p + 1);
            counts[n]--;
            result++;
        }

        Check(p + 1);
    }
}
