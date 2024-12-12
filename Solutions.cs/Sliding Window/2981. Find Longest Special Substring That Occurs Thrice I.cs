namespace Problem2981
{

  /// <summary>
  /// 2981. Find Longest Special Substring That Occurs Thrice I
  /// https://leetcode.com/problems/find-longest-special-substring-that-occurs-thrice-i
  /// 
  /// Difficulty Medium
  /// Acceptance 54.0%
  /// 
  /// Hash Table
  /// String
  /// Binary Search
  /// Sliding Window
  /// Counting
  /// </summary>
  public class Solution
  {
    private struct Triple
    {
      private int First;
      private int Second;
      private int Third;

      public void Add(int value)
      {
        if (value > First)
        {
          Third = Second;
          Second = First;
          First = value;
        }
        else if (value > Second)
        {
          Third = Second;
          Second = value;
        }
        else if (value > Third)
        {
          Third = value;
        }
      }

      public int GetValue()
      {
        return First == Second && Second == Third
          ? First
          : First <= Second + 1
            ? First - 1
            : First - 2;
      }
    }

    public int MaximumLength(string s)
    {
      var counts = new Triple[26];
      var previous = s[0] - 'a';
      var count = 1;
      var i = 1;
      while (true)
      {
        var c = s[i++] - 'a';
        if (c != previous)
        {
          counts[previous].Add(count);
          count = 0;
          previous = c;
        }

        count++;
        if (i == s.Length)
        {
          counts[previous].Add(count);
          break;
        }
      }

      var result = 0;
      foreach (var list in counts)
      {
        var candidate = list.GetValue();
        if (result < candidate)
          result = candidate;
      }

      return result == 0 ? -1 : result;
    }
  }
}
