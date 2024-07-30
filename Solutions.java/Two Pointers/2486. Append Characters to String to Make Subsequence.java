/// <summary>
/// 2486. Append Characters to String to Make Subsequence
/// https://leetcode.com/problems/append-characters-to-string-to-make-subsequence
/// 
/// Difficulty Medium
/// Acceptance 73.0%
/// 
/// Two Pointers
/// String
/// Greedy
/// </summary>
class Solution {
    public int appendCharacters(String s, String t) {
        var slen = s.length();
        var tlen = t.length();

        var sp = 0;
        var tp = 0;

        while (sp < slen && tp < tlen) {
            if (s.charAt(sp) == t.charAt(tp)) {
                tp++;
            }

            sp++;
        }
        
        return (tlen - tp);
    }
}
