/// <summary>
/// 3075. Maximize Happiness of Selected Children
/// https://leetcode.com/problems/maximize-happiness-of-selected-children
/// 
/// Difficulty Medium
/// Acceptance 55.0%
/// 
/// Array
/// Greedy
/// Sorting
/// </summary>
class Solution {
    public long maximumHappinessSum(int[] happiness, int k) {
        Arrays.sort(happiness);
        long result = 0;

        for (var i = happiness.length - 1; i > happiness.length - 1 - k; i--){
            var val = happiness[i] - (happiness.length - 1 - i);
            if (val > 0){
                result += val;
            } else {
                return result;
            }
        }

        return result;
    }
}
