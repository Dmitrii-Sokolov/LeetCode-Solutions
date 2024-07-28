namespace Problem350
{

  /// <summary>
  /// 350. Intersection of Two Arrays II
  /// https://leetcode.com/problems/intersection-of-two-arrays-ii/description/
  /// 
  /// Difficulty Easy 58.6%
  /// 
  /// Array
  /// Hash Table
  /// Two Pointers
  /// Binary Search
  /// Sorting
  /// </summary>
  class Solution
  {
    public int[] intersect(int[] nums1, int[] nums2)
    {
      var counts = new int[1001];
      for (var n : nums1)
      {
        counts[n]++;
      }

      var result = new int[1001];
      var i = 0;
      for (var n : nums2)
      {
        if (counts[n] > 0)
        {
          counts[n]--;
          result[i++] = n;
        }
      }

      return Arrays.copyOfRange(result, 0, i);
    }
  }
}
