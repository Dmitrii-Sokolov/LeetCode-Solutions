/// <summary>
/// 3. Longest Substring Without Repeating Characters
/// https://leetcode.com/problems/longest-substring-without-repeating-characters
/// 
/// Difficulty Medium
/// Acceptance 35.2%
/// 
/// Hash Table
/// String
/// Sliding Window
/// </summary>
class Solution {
    public int lengthOfLongestSubstring(String s) {
        var result = 0;
        var start = 0;
        var end = 0;
        var set = new HashSet<Character>();

        while (end < s.length()) {
            while (end < s.length() && set.add(s.charAt(end))) {
                end++;
            }

            result = Math.max(result, end - start);
            if (end == s.length()) {
                return result;
            }
            
            while (start < end && s.charAt(end) != s.charAt(start)) {
                set.remove(s.charAt(start));
                start++;
            }

            start++;
            end++;
        }

        return result;
        
    }
}
