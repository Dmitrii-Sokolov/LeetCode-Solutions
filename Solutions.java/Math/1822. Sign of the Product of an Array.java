/// <summary>
/// 1822. Sign of the Product of an Array
/// https://leetcode.com/problems/sign-of-the-product-of-an-array
/// 
/// Difficulty Easy
/// Acceptance 65.3%
/// 
/// Array
/// Math
/// </summary>
class Solution {
    public int arraySign(int[] nums) {
        var result = 1;

        for (var i = 0; i < nums.length; i++){
            if (nums[i] == 0){
                return 0;
            } else if (nums[i] < 0) {
                result = -result;
            }
        }
        
        return result;
    }
}
