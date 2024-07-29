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
class Solution
{
  public boolean isPalindrome(String s)
  {
    var first = 0;
    var last = s.length() - 1;
    do
    {
      if (first < s.length() - 1 && !Character.isLetterOrDigit(s.charAt(first)))
      {
        first++;
        continue;
      }
      if (last > 0 && !Character.isLetterOrDigit(s.charAt(last)))
      {
        last--;
        continue;
      }

      if (first > last)
      {
        return true;
      }

      if (Character.toLowerCase(s.charAt(first)) != Character.toLowerCase(s.charAt(last)))
      {
        return false;
      }

      first++;
      last--;
    } while (first < last);

    return true;
  }
}
