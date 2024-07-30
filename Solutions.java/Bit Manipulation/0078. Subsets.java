/// <summary>
/// 78. Subsets
/// https://leetcode.com/problems/subsets
/// 
/// Difficulty Medium
/// Acceptance 78.8%
/// 
/// Array
/// Backtracking
/// Bit Manipulation
/// </summary>
class Solution {
    public List<List<Integer>> subsets(int[] nums) {
        var result = new ArrayList<List<Integer>>(1 << nums.length);
        
        for (var i = 0; i < (1 << nums.length); i++) {
            var row = new ArrayList<Integer>();
            var key = i;
            var index = 0;
            while (key > 0) {
                if (key % 2 == 1) {
                    row.add(nums[index]);
                }
                key /= 2;
                index++;
            }
            result.add(row);
        }
        
        return result;
    }
}
