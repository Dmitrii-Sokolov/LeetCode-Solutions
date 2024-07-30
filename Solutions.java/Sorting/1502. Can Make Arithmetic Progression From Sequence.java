/// <summary>
/// 1502. Can Make Arithmetic Progression From Sequence
/// https://leetcode.com/problems/can-make-arithmetic-progression-from-sequence
/// 
/// Difficulty Easy
/// Acceptance 69.6%
/// 
/// Array
/// Sorting
/// </summary>
class Solution {
    public boolean canMakeArithmeticProgression(int[] arr) {
        if (arr.length == 1)
            return true;

        Arrays.sort(arr);
        var step = arr[1] - arr[0];
        for (var i = 1; i < arr.length; i++){
            if (arr[i] - arr[i - 1] != step)
                return false;
        }

        return true;
    }
}
