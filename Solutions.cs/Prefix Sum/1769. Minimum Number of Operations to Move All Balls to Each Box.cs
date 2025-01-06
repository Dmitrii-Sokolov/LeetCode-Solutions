namespace Problem1769
{

  /// <summary>
  /// 1769. Minimum Number of Operations to Move All Balls to Each Box
  /// https://leetcode.com/problems/minimum-number-of-operations-to-move-all-balls-to-each-box
  /// 
  /// Difficulty Medium
  /// Acceptance 87.1%
  /// 
  /// Array
  /// String
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int[] MinOperations(string boxes)
    {
      var result = new int[boxes.Length];

      var count = 0;
      var steps = 0;
      for (var i = 0; i < boxes.Length; i++)
      {
        result[i] += steps;
        count += boxes[i] == '1' ? 1 : 0;
        steps += count;
      }

      steps = 0;
      count = 0;
      for (var i = boxes.Length - 1; i >= 0; i--)
      {
        result[i] += steps;
        count += boxes[i] == '1' ? 1 : 0;
        steps += count;
      }

      return result;
    }
  }
}
