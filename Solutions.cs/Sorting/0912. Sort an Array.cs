namespace Problem912
{

  /// <summary>
  /// 912. Sort an Array
  /// https://leetcode.com/problems/sort-an-array
  /// 
  /// Difficulty Medium
  /// Acceptance 58.1%
  /// 
  /// Array
  /// Divide and Conquer
  /// Sorting
  /// Heap (Priority Queue)
  /// Merge Sort
  /// Bucket Sort
  /// Radix Sort
  /// Counting Sort
  /// </summary>
  public class Solution
  {
    public int[] SortArray(int[] nums)
    {
      Sort(nums, 0, nums.Length - 1);
      return nums;
    }

    private static void Sort(int[] nums, int from, int to)
    {
      if (IsSorted(nums, from, to))
        return;

      var first = from;
      var last = to - 1;
      do
      {
        while (first <= to - 1 && nums[first] <= nums[to])
          first++;

        while (from <= last && nums[last] >= nums[to])
          last--;

        if (first < last && first <= to - 1 && last >= from)
        {
          Swap(nums, first, last);
          first++;
          last--;
        }
      } while (first <= last);

      Swap(nums, to, last + 1);

      if (from < last)
        Sort(nums, from, last);

      if (last + 2 < to)
        Sort(nums, last + 2, to);
    }

    private static bool IsSorted(int[] nums, int from, int to)
    {
      for (var i = from; i < to; i++)
      {
        if (nums[i] > nums[i + 1])
          return false;
      }

      return true;
    }

    private static void Swap(int[] nums, int a, int b)
      => (nums[a], nums[b]) = (nums[b], nums[a]);
  }
}
