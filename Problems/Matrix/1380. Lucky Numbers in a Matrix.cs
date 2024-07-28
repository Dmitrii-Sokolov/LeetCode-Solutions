namespace Problem1380
{

  /// <summary>
  /// 1380. Lucky Numbers in a Matrix
  /// https://leetcode.com/problems/lucky-numbers-in-a-matrix/description/
  /// 
  /// Difficulty Easy 79.9%
  /// 
  /// Array
  /// Matrix
  /// </summary>
  public class Solution
  {
    public IList<int> LuckyNumbers(int[][] matrix)
      => matrix.
      Select(x => x.Min()).
      ToHashSet().
      Intersect(
        Enumerable.Range(0, matrix[0].Length).
        Select(i => matrix.Max(m => m[i])).
        ToHashSet()).ToList();
  }
}
