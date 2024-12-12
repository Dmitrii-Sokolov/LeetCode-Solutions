namespace Problem2558
{

  /// <summary>
  /// 2558. Take Gifts From the Richest Pile
  /// https://leetcode.com/problems/take-gifts-from-the-richest-pile
  /// 
  /// Difficulty Easy
  /// Acceptance 71.8%
  /// 
  /// Array
  /// Heap(Priority Queue)
  /// Simulation
  /// </summary>
  public class Solution
  {
    public long PickGifts(int[] gifts, int k)
    {
      for (var i = 0; i < k; i++)
      {
        var max = 0;
        var maxIndex = 0;
        for (var j = 0; j < gifts.Length; j++)
        {
          if (gifts[j] > max)
          {
            max = gifts[j];
            maxIndex = j;
          }
        }

        gifts[maxIndex] = (int)Math.Sqrt(max);
      }

      var result = 0L;
      foreach (var gift in gifts)
        result += gift;

      return result;
    }
  }
}
