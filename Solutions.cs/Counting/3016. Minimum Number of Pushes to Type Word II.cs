namespace Problem3016
{

  /// <summary>
  /// 3016. Minimum Number of Pushes to Type Word II
  /// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-ii
  /// 
  /// Difficulty Medium
  /// Acceptance 78.3%
  /// 
  /// Hash Table
  /// String
  /// Greedy
  /// Sorting
  /// Counting
  /// </summary>
  public class Solution
  {
    private const int LettersCount = 26;
    private const char FirstLetter = 'a';
    private const int ButtonsCount = 8;

    public int MinimumPushes(string word)
    {
      var counts = new int[LettersCount];
      foreach (var wordChar in word)
        counts[wordChar - FirstLetter]++;

      Array.Sort(counts);

      var result = 0;
      for (var i = 0; i < LettersCount; i++)
        result += counts[i] * (((LettersCount - i - 1) / ButtonsCount) + 1);

      return result;

    }
  }
}
