namespace Problem2516
{

  /// <summary>
  /// 2516. Take K of Each Character From Left and Right
  /// https://leetcode.com/problems/take-k-of-each-character-from-left-and-right
  /// 
  /// Difficulty Medium
  /// Acceptance 45.2%  
  /// 
  /// Hash Table
  /// String
  /// Sliding Window
  /// </summary>
  public class Solution
  {
    private const int CharCount = 3;
    private const int Complete = 0b111;

    public int TakeCharacters(string s, int k)
    {
      if (k == 0)
        return 0;

      if (s.Length < k * CharCount)
        return -1;

      var counts = new int[CharCount];
      var right = s.Length;
      var status = 0;
      while (right > 0 && status != Complete)
      {
        var c = s[--right];
        var type = c - 'a';
        counts[type]++;
        if (counts[type] >= k)
          status |= 1 << type;
      }

      if (status != Complete)
        return -1;

      var left = -1;
      var result = s.Length - right + left + 1;
      var bestPossible = k * CharCount;
      while (right < s.Length && result != bestPossible)
      {
        var type = s[++left] - 'a';
        if (++counts[type] == k)
          status |= 1 << type;

        type = s[right++] - 'a';
        if (--counts[type] == k - 1)
          status &= ~(1 << type);

        if (status == Complete)
        {
          while (right < s.Length && counts[s[right] - 'a'] > k)
          {
            type = s[right++] - 'a';
            --counts[type];
          }
        }

        var candidate = s.Length - right + left + 1;
        if (result > candidate)
          result = candidate;
      }

      return result;
    }
  }
}
