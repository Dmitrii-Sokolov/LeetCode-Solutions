namespace Problem948
{

  /// <summary>
  /// 948. Bag of Tokens
  /// https://leetcode.com/problems/bag-of-tokens
  /// 
  /// Difficulty Medium
  /// Acceptance 59.0%
  /// 
  /// Array
  /// Two Pointers
  /// Greedy
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int BagOfTokensScore(int[] tokens, int power)
    {
      var scoreCurrent = 0;
      var scoreMax = 0;
      Array.Sort(tokens);
      var first = 0;
      var last = tokens.Length - 1;

      while (first <= last)
      {
        if (power >= tokens[first])
        {
          power -= tokens[first];
          first++;
          scoreCurrent++;
          scoreMax = Math.Max(scoreCurrent, scoreMax);
          continue;
        }

        if (scoreCurrent > 0)
        {
          power += tokens[last];
          last--;
          scoreCurrent--;
          continue;
        }

        break;
      }

      return scoreMax;
    }
  }
}
