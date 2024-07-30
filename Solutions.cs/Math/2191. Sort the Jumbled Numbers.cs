namespace Problem2191
{

  /// <summary>
  /// 2191. Sort the Jumbled Numbers
  /// https://leetcode.com/problems/sort-the-jumbled-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 60.3%
  /// 
  /// Array
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int[] SortJumbled(int[] mapping, int[] nums)
    {
      return nums.Select(n => (n, Map(mapping, n))).OrderBy(n => n.Item2).Select(p => p.Item1).ToArray();
    }

    private int Map(int[] mapping, int num)
    {
      var result = 0;
      var degree = 1;
      do
      {
        var digit = num % 10;
        var newDigit = mapping[digit];
        result += degree * newDigit;
        degree *= 10;
        num /= 10;
      } while (num > 0);

      return result;
    }
  }
}
