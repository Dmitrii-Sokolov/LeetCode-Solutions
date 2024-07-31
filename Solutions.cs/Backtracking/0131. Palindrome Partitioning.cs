namespace Problem131
{

  /// <summary>
  /// 131. Palindrome Partitioning
  /// https://leetcode.com/problems/palindrome-partitioning
  /// 
  /// Difficulty Medium
  /// Acceptance 69.9%
  /// 
  /// String
  /// Dynamic Programming
  /// Backtracking
  /// </summary>
  public class Solution
  {
    public IList<IList<string>> Partition(string s)
    {
      S = s;
      Len = s.Length;
      Pal = new int[Len + 1, Len + 1];

      Check([], 0);

      return Result.Select(l => (IList<string>)l).ToList();
    }

    private string S;
    private List<List<string>> Result = new();
    private int Len;
    private int[,] Pal;

    private void Check(List<string> row, int start)
    {
      if (IsPalindrome(start, Len))
      {
        var cloned = new List<string>(row);
        cloned.Add(S.Substring(start, Len - start));
        Result.Add(cloned);
      }

      for (var i = start + 1; i < Len; i++)
      {
        if (IsPalindrome(start, i))
        {
          var cloned = new List<string>(row);
          cloned.Add(S.Substring(start, i - start));
          Check(cloned, i);
        }
      }
    }

    private bool IsPalindrome(int start, int end)
    {
      if (Pal[start, end] != 0)
        return Pal[start, end] == 1;

      var p = IsPalindromeInternal(start, end);
      Pal[start, end] = p ? 1 : -1;
      return p;
    }

    private bool IsPalindromeInternal(int start, int end)
    {
      end--;
      while (start < end)
      {
        if (S[start] != S[end])
          return false;
        start++;
        end--;
      }

      return true;
    }
  }
}
