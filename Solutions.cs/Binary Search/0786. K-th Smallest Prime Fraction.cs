namespace Problem786
{

  /// <summary>
  /// 786. K-th Smallest Prime Fraction
  /// https://leetcode.com/problems/k-th-smallest-prime-fraction
  /// 
  /// Difficulty Medium
  /// Acceptance 68.1%
  /// 
  /// Array
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// Heap (Priority Queue)
  /// </summary>
  public class Solution
  {
    public int[] KthSmallestPrimeFraction(int[] arr, int k)
    {
      var len = arr.Length;
      double left = 0;
      double right = 1;
      var result = new int[2];
      var total = (len - 1) * len / 2;

      while (left <= right)
      {
        var middle = (right + left) / 2;
        double fraction = 0;
        var j = 1;
        var count = 0;

        for (var i = 0; i < len - 1; i++)
        {
          while (j < len && arr[i] > middle * arr[j])
          {
            j++;
          }

          count += j - i - 1;

          if (j < len && fraction < arr[i] * 1.0 / arr[j])
          {
            result = new int[] { arr[i], arr[j] };
            fraction = arr[i] * 1.0 / arr[j];
          }
        }

        if (count == total - k)
          return result;
        else if (count < total - k)
        {
          right = middle;
        }
        else if (count > total - k)
        {
          left = middle;
        }
      }

      return result;
    }
  }
}
