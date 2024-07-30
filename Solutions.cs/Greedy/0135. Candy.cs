namespace Problem135
{

  /// <summary>
  /// 135. Candy
  /// https://leetcode.com/problems/candy
  /// 
  /// Difficulty Hard
  /// Acceptance 43.6%
  /// 
  /// Array
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int Candy(int[] ratings)
    {
      var current = 1;
      var candies = new int[ratings.Length];
      candies[0] = current;

      for (var i = 1; i < ratings.Length; i++)
      {
        current = ratings[i] > ratings[i - 1] ? current + 1 : 1;
        candies[i] = current;
      }

      for (var i = ratings.Length - 1; i > 0; i--)
      {
        if (ratings[i] < ratings[i - 1])
        {
          if (candies[i] >= candies[i - 1])
            candies[i - 1] = candies[i] + 1;
        }
      }

      var result = 0;
      for (var i = 0; i < candies.Length; i++)
      {
        result += candies[i];
      }

      return result;
    }
  }
}
