namespace Problem1636
{

  /// <summary>
  /// 1636. Sort Array by Increasing Frequency
  /// https://leetcode.com/problems/sort-array-by-increasing-frequency/description/
  /// 
  /// Difficulty Easy 79.7%
  /// 
  /// Array
  /// Hash Table
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] FrequencySort(int[] nums)
    {
      var counts = new int[201];
      foreach (var num in nums)
        counts[num + 100]++;

      Array.Sort(nums, (a, b) => Compare(counts, a, b));

      return nums;
    }

    private int Compare(int[] counts, int a, int b)
    {
      var c = counts[a + 100].CompareTo(counts[b + 100]);
      return c != 0 ? c : b.CompareTo(a);
    }
  }
}
