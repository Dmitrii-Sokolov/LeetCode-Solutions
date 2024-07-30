namespace Problem15
{

  /// <summary>
  /// 15. 3Sum
  /// https://leetcode.com/problems/3sum
  /// 
  /// Difficulty Medium
  /// Acceptance 35.0%
  /// 
  /// Array
  /// Two Pointers
  /// Sorting
  /// </summary>
  public class Solution
  {
    public IList<IList<int>> ThreeSum(int[] nums)
    {
      Array.Sort(nums);
      var result = new HashSet<List<int>>();

      for (var i = 0; i < nums.Length - 2; i++)
      {
        while (i > 0 && nums[i] == nums[i - 1])
        {
          i++;
          if (i == nums.Length - 2)
            return new List<IList<int>>(result);
        }

        var n = nums[i];
        var a = i + 1;
        var b = i + 2;

        while (b < nums.Length &&
            nums[a] + nums[b] + n < 0)
        {
          a++;
          b++;
        }

        while (i < a && b < nums.Length)
        {
          if (nums[a] + nums[b] + n == 0)
            Add(n, nums[a], nums[b], result);

          if (nums[a] + nums[b] + n < 0)
          {
            do
            {
              b++;
            } while (b < nums.Length && nums[b] == nums[b - 1]);
          }
          else
          {
            do
            {
              a--;
            } while (a > i && nums[a] == nums[a + 1]);
          }
        }
      }

      return new List<IList<int>>(result);
    }

    private void Add(int a, int b, int c, HashSet<List<int>> result)
    {
      var tri = new List<int>();

      tri.Add(a);
      tri.Add(b);
      tri.Add(c);
      result.Add(tri);
    }
  }
}
