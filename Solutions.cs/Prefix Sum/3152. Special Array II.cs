namespace Problem3152
{

  /// <summary>
  /// 3152. Special Array II
  /// https://leetcode.com/problems/special-array-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 35.7%
  /// 
  /// Array
  /// Binary Search
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public bool[] IsArraySpecial(int[] numbers, int[][] queries)
    {
      var parityIndex = new int[numbers.Length];
      for (var i = 1; i < numbers.Length; i++)
        parityIndex[i] = parityIndex[i - 1] + (numbers[i - 1] + numbers[i] + 1) % 2;

      var result = new bool[queries.Length];
      for (var i = 0; i < queries.Length; i++)
        result[i] = parityIndex[queries[i][0]] == parityIndex[queries[i][1]];

      return result;
    }
  }
}
