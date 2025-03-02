namespace Problem2570
{

  /// <summary>
  /// 2570. Merge Two 2D Arrays by Summing Values
  /// https://leetcode.com/problems/merge-two-2d-arrays-by-summing-values
  /// 
  /// Difficulty Easy
  /// Acceptance 77.4%
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public int[][] MergeArrays(int[][] numbers0, int[][] numbers1)
    {
      var result = new List<int[]>();
      var i0 = 0;
      var i1 = 0;
      while (i0 < numbers0.Length && i1 < numbers1.Length)
      {
        if (numbers0[i0][0] == numbers1[i1][0])
        {
          result.Add(numbers0[i0++]);
          result[^1][1] += numbers1[i1++][1];
        }
        else if (numbers0[i0][0] < numbers1[i1][0])
        {
          result.Add(numbers0[i0++]);
        }
        else
        {
          result.Add(numbers1[i1++]);
        }
      }

      while (i0 < numbers0.Length)
        result.Add(numbers0[i0++]);

      while (i1 < numbers1.Length)
        result.Add(numbers1[i1++]);

      return [.. result];
    }
  }
}
