namespace Problem125
{

  /// <summary>
  /// 125. Valid Palindrome
  /// https://leetcode.com/problems/valid-palindrome
  /// 
  /// Difficulty Easy
  /// Acceptance 48.2%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public bool IsPalindrome(string s)
    {
      var first = 0;
      var last = s.Length - 1;
      do
      {
        if (first < s.Length - 1 && !char.IsLetterOrDigit(s[first]))
        {
          first++;
          continue;
        }
        if (last > 0 && !char.IsLetterOrDigit(s[last]))
        {
          last--;
          continue;
        }

        if (first > last)
          return true;

        if (char.ToLower(s[first]) != char.ToLower(s[last]))
          return false;

        first++;
        last--;
      } while (first < last);

      return true;
    }
  }
}
