namespace Problem2161
{

  /// <summary>
  /// 2161. Partition Array According to Given Pivot
  /// https://leetcode.com/problems/partition-array-according-to-given-pivot
  /// 
  /// Difficulty Medium
  /// Acceptance Medium
  /// 
  /// Array
  /// Two Pointers
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] PivotArray(int[] numbers, int pivot)
    {
      var result = new int[numbers.Length];
      var p = 0;
      var p0 = 0;
      var p1 = 0;
      for (var i = 0; i < numbers.Length; i++)
      {
        if (numbers[i] < pivot)
          p++;

        if (numbers[i] <= pivot)
          p1++;
      }

      while (p < p1)
        result[p++] = pivot;

      for (var i = 0; i < numbers.Length; i++)
      {
        if (numbers[i] < pivot)
        {
          result[p0++] = numbers[i];
        }
        else if (numbers[i] > pivot)
        {
          result[p1++] = numbers[i];
        }
      }

      return result;
    }
  }
}
