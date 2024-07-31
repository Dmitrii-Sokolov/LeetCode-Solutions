namespace Problem274
{

  /// <summary>
  /// 274. H-Index
  /// https://leetcode.com/problems/h-index
  /// 
  /// Difficulty Medium
  /// Acceptance 39.2%
  /// 
  /// Array
  /// Sorting
  /// Counting Sort
  /// </summary>
  public class Solution
  {
    public int HIndex(int[] citations)
    {
      var sorted = new int[1001];
      var max = 0;
      for (var i = 0; i < citations.Length; i++)
      {
        sorted[citations[i]]++;
        max = Math.Max(max, citations[i]);
      }

      var articles = sorted[max];
      while (articles < max)
      {
        max--;
        articles += sorted[max];
      }

      return max;
    }
  }
}
