namespace Problem79
{

  /// <summary>
  /// 79. Word Search
  /// https://leetcode.com/problems/word-search
  /// 
  /// Difficulty Medium
  /// Acceptance 43.3%
  /// 
  /// Array
  /// String
  /// Backtracking
  /// Matrix
  /// </summary>
  public class Solution
  {
    private char[][] board;
    private string word;

    public bool Exist(char[][] board, string word)
    {
      this.board = board;
      this.word = word;

      for (var x = 0; x < board.Length; x++)
      {
        for (var y = 0; y < board[x].Length; y++)
        {
          if (Check(x, y))
            return true;
        }
      }

      return false;
    }

    private bool Check(int x, int y, int l = 0)
    {
      if (l == word.Length)
        return true;

      if (x < 0 || board.Length <= x)
        return false;

      if (y < 0 || board[x].Length <= y)
        return false;

      if (board[x][y] != word[l])
        return false;

      board[x][y] = '0';

      if (Check(x - 1, y, l + 1))
        return true;

      if (Check(x + 1, y, l + 1))
        return true;

      if (Check(x, y - 1, l + 1))
        return true;

      if (Check(x, y + 1, l + 1))
        return true;

      board[x][y] = word[l];

      return false;
    }
  }
}
