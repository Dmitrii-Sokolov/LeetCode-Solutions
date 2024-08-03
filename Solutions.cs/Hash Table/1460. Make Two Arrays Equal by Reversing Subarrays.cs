namespace Problem1460
{

  /// <summary>
  /// 1460. Make Two Arrays Equal by Reversing Subarrays
  /// https://leetcode.com/problems/make-two-arrays-equal-by-reversing-subarrays
  /// 
  /// Difficulty Easy
  /// Acceptance 73.5%
  /// 
  /// Array
  /// Hash Table
  /// Sorting
  /// </summary>
  public class Solution
  {
    public bool CanBeEqual(int[] target, int[] arr)
    {
      var numbers = new int[1001];
      for (var i = 0; i < target.Length; i++)
      {
        numbers[target[i]]++;
        numbers[arr[i]]--;
      }

      return numbers.All(n => n == 0);
    }
  }
}
