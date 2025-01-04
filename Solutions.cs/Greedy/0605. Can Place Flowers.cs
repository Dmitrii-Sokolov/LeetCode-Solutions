namespace Problem605
{

  /// <summary>
  /// 605. Can Place Flowers
  /// https://leetcode.com/problems/can-place-flowers
  /// 
  /// Difficulty Easy
  /// Acceptance 28.8%
  /// 
  /// Array
  /// Greedy
  /// </summary>
  public class Solution
  {
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
      var empty = 1;
      for (var i = 0; i < flowerbed.Length; i++)
      {
        if (flowerbed[i] == 0)
        {
          empty++;
        }
        else
        {
          empty = 0;
        }

        if (empty == 3)
        {
          empty = 1;
          n--;
        }

        if (n == 0)
          return true;
      }

      if (empty == 2)
        n--;

      return n == 0;
    }
  }
}
