namespace Problem724
{

  /// <summary>
  /// 724. Find Pivot Index
  /// https://leetcode.com/problems/find-pivot-index
  /// 
  /// Difficulty Easy
  /// Acceptance 59.4%
  /// 
  /// Array
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int PivotIndex(int[] numbers)
    {
      var sumRight = 0;
      for (var i = 0; i < numbers.Length; i++)
        sumRight += numbers[i];

      var sumLeft = 0;
      for (var i = 0; i < numbers.Length; i++)
      {
        sumRight -= numbers[i];

        if (sumLeft == sumRight)
          return i;

        sumLeft += numbers[i];
      }

      return -1;
    }
  }
}
