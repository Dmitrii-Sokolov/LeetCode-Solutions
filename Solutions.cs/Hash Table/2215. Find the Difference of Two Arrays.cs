namespace Problem2215
{

  /// <summary>
  /// 2215. Find the Difference of Two Arrays
  /// https://leetcode.com/problems/find-the-difference-of-two-arrays
  /// 
  /// Difficulty Easy
  /// Acceptance 80.1%
  /// 
  /// Array
  /// Hash Table
  /// </summary>
  public class Solution
  {
    public IList<IList<int>> FindDifference(int[] numbers1, int[] numbers2)
    {
      var set1 = numbers1.ToHashSet();
      var set2 = numbers2.ToHashSet();

      return [set1.Except(set2).ToList(), set2.Except(set1).ToList()];
    }
  }
}
