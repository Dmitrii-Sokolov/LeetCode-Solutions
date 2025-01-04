namespace Problem1431
{

  /// <summary>
  /// 1431. Kids With the Greatest Number of Candies
  /// https://leetcode.com/problems/kids-with-the-greatest-number-of-candies
  /// 
  /// Difficulty Easy
  /// Acceptance 87.9%
  /// 
  /// Array
  /// </summary>
  public class Solution
  {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
      var max = 0;
      foreach (var count in candies)
      {
        if (max < count)
          max = count;
      }

      max -= extraCandies;
      var result = new List<bool>(candies.Length);
      foreach (var count in candies)
        result.Add(count >= max);

      return result;
    }
  }
}
