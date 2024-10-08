namespace Problem1963
{

  /// <summary>
  /// 1963. Minimum Number of Swaps to Make the String Balanced
  /// https://leetcode.com/problems/minimum-number-of-swaps-to-make-the-string-balanced
  /// 
  /// Difficulty Medium
  /// Acceptance 73.8%
  /// 
  /// Two Pointers
  /// String
  /// Stack
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MinSwaps(string s)
    {
      var balance = 0;
      var swaps = 0;

      foreach (var c in s)
      {
        if (c == '[')
        {
          balance++;
        }
        else
        {
          balance--;
        }

        if (balance < 0)
        {
          balance += 2;
          swaps += 1;
        }
      }

      return swaps;
    }
  }
}
