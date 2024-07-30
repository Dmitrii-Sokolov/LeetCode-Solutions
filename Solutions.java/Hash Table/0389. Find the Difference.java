/// <summary>
/// 389. Find the Difference
/// https://leetcode.com/problems/find-the-difference
/// 
/// Difficulty Easy
/// Acceptance 59.6%
/// 
/// Hash Table
/// String
/// Bit Manipulation
/// Sorting
/// </summary>
class Solution {
    public char findTheDifference(String s, String t) {
        var counts = new int[26];

        for (var i = 0; i < s.length(); i++){
            counts[s.charAt(i) - 'a']++;
        }

        for (var i = 0; i < t.length(); i++){
            counts[t.charAt(i) - 'a']--;

            if (counts[t.charAt(i) - 'a'] == -1)
                return t.charAt(i);
        }
        
        return '0';
    }
}
