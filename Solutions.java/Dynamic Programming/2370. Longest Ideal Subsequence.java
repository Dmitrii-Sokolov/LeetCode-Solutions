/// <summary>
/// 2370. Longest Ideal Subsequence
/// https://leetcode.com/problems/longest-ideal-subsequence
/// 
/// Difficulty Medium
/// Acceptance 47.4%
/// 
/// Hash Table
/// String
/// Dynamic Programming
/// </summary>
class Solution {
    public int longestIdealString(String s, int k) {
        var dp = new int[27];
        var n = s.length();
        
        for (var i = n - 1; i >= 0 ; i--){
            var c = s.charAt(i);
            var idx = c - 'a';
            var max  = Integer.MIN_VALUE;
            
            var left = Math.max((idx-k), 0);
            var right = Math.min((idx + k), 26);
            
            for(var j = left; j <= right ; j++){
                max = Math.max(max, dp[j]);
            }
            
            dp[idx] = max+1;
        }
        
        var result = Integer.MIN_VALUE;
        
        for (var ele : dp){
            result = Math.max(ele, result);
        }
        
        return result;
    }
}
