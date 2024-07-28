namespace Problem1255
{

  /// <summary>
  /// 1255. Maximum Score Words Formed by Letters
  /// https://leetcode.com/problems/maximum-score-words-formed-by-letters
  /// 
  /// Difficulty Hard 82.1%
  /// 
  /// Array
  /// String
  /// Dynamic Programming
  /// Backtracking
  /// Bit Manipulation
  /// Bitmask
  /// </summary>
  class Solution
  {
    public int maxScoreWords(String[] w, char[] l, int[] s)
    {
      words = w;
      for (var a : l)
      {
        letters[a - 'a']++;
      }
      score = s;

      Check(0, 0);
      return result;
    }

    private String[] words;
    private int[] letters = new int[26];
    private int[] score;

    private int result;

    private void Check(int p, int sum)
    {
      if (p == words.length)
      {
        result = Math.max(sum, result);
        return;
      }

      var i = 0;
      while (i < words[p].length())
      {
        int index = words[p].charAt(i) - 'a';
        if (letters[index] <= 0)
        {
          break;
        }
        letters[index]--;
        sum += score[index];
        i++;
      }

      if (i == words[p].length())
      {
        Check(p + 1, sum);
      }

      while (i > 0)
      {
        i--;
        int index = words[p].charAt(i) - 'a';
        letters[index]++;
        sum -= score[index];
      }

      Check(p + 1, sum);
    }
  }
}
