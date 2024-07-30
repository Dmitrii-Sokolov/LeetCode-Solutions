/// <summary>
/// 131. Palindrome Partitioning
/// https://leetcode.com/problems/palindrome-partitioning
/// 
/// Difficulty Medium
/// Acceptance 69.9%
/// 
/// String
/// Dynamic Programming
/// Backtracking
/// </summary>
class Solution {
    public List<List<String>> partition(String s) {
        this.s = s;
        result = new ArrayList<List<String>>();
        len = s.length();
        pal = new int[len + 1][len + 1];
 
        Check(new ArrayList<String>(), 0);

        return result;
    }

    private String s;
    private List<List<String>> result;
    private int len;
    private int[][] pal;

    private void Check(ArrayList<String> row, int start) {
        if (IsPalindrome(start, len)) {
            var cloned = new ArrayList<String>(row);
            cloned.add(s.substring(start, len));
            result.add(cloned);
        }

        for (var i = start + 1; i < len; i++) {
            if (IsPalindrome(start, i)) {
                var cloned = new ArrayList<String>(row);
                cloned.add(s.substring(start, i));
                Check(cloned, i);
            }
        }
    }

    private Boolean IsPalindrome(int start, int end) {
        if (pal[start][end] != 0) {
            return pal[start][end] == 1;
        }

        var p = IsPalindromeInternal(start, end);
        pal[start][end] = p ? 1 : -1;
        return p;
    }

    private Boolean IsPalindromeInternal(int start, int end) {
        end--;
        while (start < end) {
            if (s.charAt(start) != s.charAt(end)) {
                return false;
            }
            start++;
            end--;
        }

        return true;
    }
}
