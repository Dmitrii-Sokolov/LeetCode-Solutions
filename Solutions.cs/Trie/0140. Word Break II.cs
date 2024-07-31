namespace Problem140
{

  /// <summary>
  /// 140. Word Break II
  /// https://leetcode.com/problems/word-break-ii
  /// 
  /// Difficulty Hard
  /// Acceptance 51.3%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Dynamic Programming
  /// Backtracking
  /// Trie
  /// Memoization
  /// </summary>
  public class Solution
  {
    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
      Str = s;
      Dictionary = wordDict;

      Check(0);
      return Result;
    }

    private string Str;
    private IList<string> Dictionary;

    private List<string> Result = new();
    private Stack<string> Words = new();

    private void Check(int p)
    {
      if (p == Str.Length)
      {
        var sb = Words.Aggregate((a, b) => b + ' ' + a);
        sb.Remove(sb.Length - 1, 1);

        Result.Add(sb.ToString());
        return;
      }

      foreach (var word in Dictionary)
      {
        if (IsCorrect(p, word))
        {
          Words.Push(word);
          Check(p + word.Length);
          Words.Pop();
        }
      }
    }

    private bool IsCorrect(int p, string word)
    {
      if (Str.Length - p < word.Length)
        return false;

      for (var i = 0; i < word.Length; i++)
      {
        if (word[i] != Str[p + i])
          return false;
      }

      return true;
    }
  }
}
