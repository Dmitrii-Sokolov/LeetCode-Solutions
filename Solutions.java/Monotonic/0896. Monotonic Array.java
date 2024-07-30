/// <summary>
/// 896. Monotonic Array
/// https://leetcode.com/problems/monotonic-array
/// 
/// Difficulty Easy
/// Acceptance 61.3%
/// 
/// Array
/// </summary>
class Solution {
    public boolean isMonotonic(int[] nums) {
        var up = true;
        var down = true;

        for (var i = 1; i < nums.length; i++){
            if (nums[i] > nums[i - 1]){
                down = false;
            }
            if (nums[i] < nums[i - 1]){
                up = false;
            }

            if (down == false && up == false)
                return false;
        }

        return true;
    }
}
