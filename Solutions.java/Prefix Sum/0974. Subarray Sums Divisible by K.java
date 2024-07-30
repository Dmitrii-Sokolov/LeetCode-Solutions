/// <summary>
/// 974. Subarray Sums Divisible by K
/// https://leetcode.com/problems/subarray-sums-divisible-by-k
/// 
/// Difficulty Medium
/// Acceptance 55.5%
/// 
/// Array
/// Hash Table
/// Prefix Sum
/// </summary>
class Solution {
    public int subarraysDivByK(int[] nums, int k) {
        var set = new int[10000];
        var sum = 0;
        var result = 0;

        for (var i = 0; i < nums.length; i++) {
            set[sum]++;
            sum = Math.floorMod(sum + nums[i], k);
            result += set[sum];
        }
        
        return result;        
    }
}
