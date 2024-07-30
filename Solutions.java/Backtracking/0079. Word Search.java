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
class Solution
{
    private char[][] board;
    private String word;

    public boolean exist(char[][] board, String word)
    {
        this.board = board;
        this.word = word;

        for (var x = 0; x < board.length; x++)
        {
            for (var y = 0; y < board[x].length; y++)
            {
                if (check(x, y, 0))
                    return true;
            }
        }

        return false;
    }

    private boolean check(int x, int y, int l)
    {
        if (l == word.length())
            return true;

        if (x < 0 || board.length <= x)
            return false;

        if (y < 0 || board[x].length <= y)
            return false;

        if (board[x][y] != word.charAt(l))
            return false;

        board[x][y] = '0';

        if (check(x - 1, y, l + 1))
            return true;

        if (check(x + 1, y, l + 1))
            return true;

        if (check(x, y - 1, l + 1))
            return true;

        if (check(x, y + 1, l + 1))
            return true;

        board[x][y] = word.charAt(l);

        return false;
    }
}
