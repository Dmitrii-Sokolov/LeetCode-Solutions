namespace Problem135
{

  /// <summary>
  /// 135. Candy
  /// https://leetcode.com/problems/candy
  /// 
  /// Difficulty Hard 43.6%
  /// 
  /// Array
  /// Greedy
  /// </summary>
  class Solution
  {
    public int candy(int[] ratings)
    {
      var current = 1;
      var candies = new int[ratings.length];
      candies[0] = current;

      for (var i = 1; i < ratings.length; i++)
      {
        current = (ratings[i] > ratings[i - 1]) ? current + 1 : 1;
        candies[i] = current;
      }

      for (var i = ratings.length - 1; i > 0; i--)
      {
        if (ratings[i] < ratings[i - 1])
        {
          if (candies[i] >= candies[i - 1])
          {
            candies[i - 1] = candies[i] + 1;
          }
        }
      }

      var result = 0;
      for (var i = 0; i < candies.length; i++)
      {
        result += candies[i];
      }

      return result;
    }
  }
}
