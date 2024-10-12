namespace Problem921
{

  /// <summary>
  /// 921. Minimum Add to Make Parentheses Valid
  /// https://leetcode.com/problems/minimum-add-to-make-parentheses-valid
  /// 
  /// Difficulty Medium
  /// Acceptance 74.8%
  /// 
  /// String
  /// Stack
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MinAddToMakeValid(string s)
    {
      var balance = 0;
      var adds = 0;

      foreach (var c in s)
      {
        if (c == '(')
        {
          balance++;
        }
        else
        {
          balance--;
        }

        if (balance < 0)
        {
          balance += 1;
          adds += 1;
        }
      }

      return adds + balance;
    }
  }
}
