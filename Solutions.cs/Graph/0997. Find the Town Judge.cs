namespace Problem997
{

  /// <summary>
  /// 997. Find the Town Judge
  /// https://leetcode.com/problems/find-the-town-judge
  /// 
  /// Difficulty Easy
  /// Acceptance 49.8%
  /// 
  /// Array
  /// Hash Table
  /// Graph
  /// </summary>
  public class Solution
  {
    public int FindJudge(int n, int[][] trust)
    {
      var rating = new int[n];

      for (var i = 0; i < trust.Length; i++)
      {
        rating[trust[i][1] - 1] = rating[trust[i][1] - 1] + 1;
        rating[trust[i][0] - 1] = rating[trust[i][0] - 1] - 1;
      }

      for (var i = 0; i < rating.Length; i++)
      {
        if (rating[i] == n - 1)
          return i + 1;
      }

      return -1;
    }
  }
}
