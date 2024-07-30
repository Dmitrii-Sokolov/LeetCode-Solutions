/// <summary>
/// 283. Move Zeroes
/// https://leetcode.com/problems/move-zeroes
/// 
/// Difficulty Easy
/// Acceptance 61.9%
/// 
/// Array
/// Two Pointers
/// </summary>
class Solution {
    public void moveZeroes(int[] nums) {
        var index = 0;
        for (var i = 0; i < nums.length; i++){
            if (nums[i] != 0){
                nums[index] = nums[i];
                index++;
            }
        }

        for (; index < nums.length; index++){
            nums[index] = 0;
        }
    }
}
