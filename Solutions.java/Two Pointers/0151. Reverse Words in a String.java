/// <summary>
/// 151. Reverse Words in a String
/// https://leetcode.com/problems/reverse-words-in-a-string
/// 
/// Difficulty Medium
/// Acceptance 44.7%
/// 
/// Two Pointers
/// String
/// </summary>
class Solution {
    public String reverseWords(String s) {
        var result = new StringBuilder();
        var end = s.length();
        var start = s.length() - 1;

        while (start >= 0 && end > 0) {
            while (end > 0 && s.charAt(end - 1) == ' ') {
                end--;
            }

            start = end;
            while (start > 0 && s.charAt(start - 1) != ' ') {
                start--;
            }

            if (start != end) {
                if (result.length() > 0) {
                    result.append(' ');
                }
                result.append(s.substring(start, end));
            }

            end = start;
        }

        return result.toString();
    }
}
