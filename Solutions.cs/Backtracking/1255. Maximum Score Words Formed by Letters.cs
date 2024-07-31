namespace Problem1255
{

  /// <summary>
  /// 1255. Maximum Score Words Formed by Letters
  /// https://leetcode.com/problems/maximum-score-words-formed-by-letters
  /// 
  /// Difficulty Hard
  /// Acceptance 82.1%
  /// 
  /// Array
  /// String
  /// Dynamic Programming
  /// Backtracking
  /// Bit Manipulation
  /// Bitmask
  /// </summary>
  public class Solution
  {
    public int MaxScoreWords(string[] w, char[] l, int[] s)
    {
      Words = w;
      foreach (var a in l)
        Letters[a - 'a']++;

      Score = s;

      Check(0, 0);
      return Result;
    }

    private string[] Words;
    private int[] Letters = new int[26];
    private int[] Score;

    private int Result;

    private void Check(int p, int sum)
    {
      if (p == Words.Length)
      {
        Result = Math.Max(sum, Result);
        return;
      }

      var i = 0;
      while (i < Words[p].Length)
      {
        var index = Words[p][i] - 'a';
        if (Letters[index] <= 0)
          break;
        Letters[index]--;
        sum += Score[index];
        i++;
      }

      if (i == Words[p].Length)
        Check(p + 1, sum);

      while (i > 0)
      {
        i--;
        var index = Words[p][i] - 'a';
        Letters[index]++;
        sum -= Score[index];
      }

      Check(p + 1, sum);
    }
  }
}
