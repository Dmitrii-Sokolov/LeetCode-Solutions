namespace Problem189
{

  /// <summary>
  /// 189. Rotate Array
  /// https://leetcode.com/problems/rotate-array
  /// 
  /// Difficulty Medium
  /// Acceptance 41.1%
  /// 
  /// Array
  /// Math
  /// Two Pointers
  /// </summary>
  public class Solution
  {
    public void Rotate(int[] nums, int k)
    {
      var n = nums.Length;
      k = k % n;
      Reverse(nums, 0, n - 1);
      Reverse(nums, 0, k - 1);
      Reverse(nums, k, n - 1);

    }

    private static void Reverse(int[] array, int from, int to)
    {
      int temp;
      for (var i = 0; i < (to + 1 - from) / 2; i++)
      {
        temp = array[from + i];
        array[from + i] = array[to - i];
        array[to - i] = temp;
      }
    }
  }
}
