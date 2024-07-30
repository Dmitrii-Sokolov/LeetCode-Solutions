namespace Problem349
{

  /// <summary>
  /// 349. Intersection of Two Arrays
  /// https://leetcode.com/problems/intersection-of-two-arrays
  /// 
  /// Difficulty Easy
  /// Acceptance 74.9%
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] Intersection(int[] nums1, int[] nums2)
    {
      var result1 = new HashSet<int>(nums1);

      return result1.Intersect(nums2).ToArray();
    }
  }
}
