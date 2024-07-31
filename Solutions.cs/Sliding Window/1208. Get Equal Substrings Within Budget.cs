namespace Problem1208
{

  /// <summary>
  /// 1208. Get Equal Substrings Within Budget
  /// https://leetcode.com/problems/get-equal-substrings-within-budget
  /// 
  /// Difficulty Medium
  /// Acceptance 58.3%
  /// 
  /// String
  /// Binary Search
  /// Sliding Window
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int EqualSubstring(string s, string t, int maxCost)
    {
      S = s;
      T = t;
      var result = 0;
      var min = 0;
      var max = -1;
      var cost = 0;

      while (max < t.Length - 1 && min < t.Length)
      {
        while (max < t.Length - 1 && cost + Cost(max + 1) <= maxCost)
        {
          max++;
          cost += Cost(max);
        }
        result = Math.Max(max - min + 1, result);

        cost -= Cost(min);
        min++;
      }

      return result;
    }

    private string S;
    private string T;

    private int Cost(int p)
    {
      return Math.Abs(S[p] - T[p]);
    }
  }
}
