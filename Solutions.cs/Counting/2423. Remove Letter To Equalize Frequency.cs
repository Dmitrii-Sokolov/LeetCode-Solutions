namespace Problem2423
{

  /// <summary>
  /// 2423. Remove Letter To Equalize Frequency
  /// https://leetcode.com/problems/remove-letter-to-equalize-frequency
  /// 
  /// Difficulty Easy
  /// Acceptance 17.4%
  /// 
  /// Hash Table
  /// String
  /// Counting
  /// </summary>
  public class Solution
  {
    public bool EqualFrequency(string word)
    {
      var freq = new int[26];

      for (var i = 0; i < word.Length; i++)
      {
        freq[word[i] - 'a']++;
      }

      var a = -1;
      var b = -1;

      var an = 0;
      var bn = 0;

      foreach (var f in freq)
      {
        if (f == 0)
          continue;
        else if (f == a || a == -1)
        {
          a = f;
          an++;
        }
        else if (f == b || b == -1)
        {
          b = f;
          bn++;
        }
        else
        {
          return false;
        }
      }

      if (b == -1)
        return a == 1 || an == 1;
      else
      {
        if (a == 1 && an == 1)
          return true;
        else if (b == 1 && bn == 1)
        {
          return true;
        }
        else if (a - b == 1 && an == 1)
        {
          return true;
        }
        else if (b - a == 1 && bn == 1)
        {
          return true;
        }
      }

      return false;
    }
  }
}
