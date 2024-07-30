namespace Problem88
{

  /// <summary>
  /// 88. Merge Sorted Array
  /// https://leetcode.com/problems/merge-sorted-array
  /// 
  /// Difficulty Easy
  /// Acceptance 50.4%
  /// 
  /// Array
  /// Two Pointers
  /// Sorting
  /// </summary>
  public class Solution
  {
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
      var i1 = m - 1;
      var i2 = n - 1;
      var i = nums1.Length - 1;
      while (i1 >= 0 || i2 >= 0)
      {
        if (i2 < 0)
          return;
        else if (i1 < 0)
        {
          nums1[i--] = nums2[i2--];
        }
        else
        {
          if (nums1[i1] > nums2[i2])
            nums1[i--] = nums1[i1--];
          else
          {
            nums1[i--] = nums2[i2--];
          }
        }
      }
    }
  }
}
