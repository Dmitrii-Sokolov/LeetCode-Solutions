/// <summary>
/// 1768. Merge Strings Alternately
/// https://leetcode.com/problems/merge-strings-alternately
/// 
/// Difficulty Easy
/// Acceptance 80.3%
/// 
/// Two Pointers
/// String
/// </summary>
class Solution {
    public String mergeAlternately(String word1, String word2) {
        var result = new StringBuilder();
        var i1 = 0;
        var i2 = 0;

        while (i1 + i2 < word1.length() + word2.length()){
            if (i1 < word1.length()){
                result.append(word1.charAt(i1++));
            }

            if (i2 < word2.length()){
                result.append(word2.charAt(i2++));
            }
        }

        return result.toString();
    }
}
