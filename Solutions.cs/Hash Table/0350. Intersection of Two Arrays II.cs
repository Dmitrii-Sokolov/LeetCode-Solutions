namespace Problem350
{

  /// <summary>
  /// 350. Intersection of Two Arrays II
  /// https://leetcode.com/problems/intersection-of-two-arrays-ii
  /// 
  /// Difficulty Easy
  /// Acceptance 58.6%
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] Intersect(int[] nums1, int[] nums2)
    {
      var counts = new int[1001];
      foreach (var n in nums1)
      {
        counts[n]++;
      }

      var result = new int[1001];
      var i = 0;
      foreach (var n in nums2)
      {
        if (counts[n] > 0)
        {
          counts[n]--;
          result[i++] = n;
        }
      }

      var result0 = new int[i];
      Array.Copy(result, result0, i);

      return result0;
    }
  }
}
