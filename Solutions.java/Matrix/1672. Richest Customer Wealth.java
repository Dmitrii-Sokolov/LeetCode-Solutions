/// <summary>
/// 1672. Richest Customer Wealth
/// https://leetcode.com/problems/richest-customer-wealth
/// 
/// Difficulty Easy
/// Acceptance 88.1%
/// 
/// Array
/// Matrix
/// </summary>
class Solution {
    public int maximumWealth(int[][] accounts) {
        var result = 0;
        for (var i = 0; i < accounts.length; i++) {
            var wealth = 0;
            for (var k = 0; k < accounts[i].length; k++) {
                wealth += accounts[i][k];
            }
            result = Math.max(wealth, result);
        }

        return result;
    }
}
