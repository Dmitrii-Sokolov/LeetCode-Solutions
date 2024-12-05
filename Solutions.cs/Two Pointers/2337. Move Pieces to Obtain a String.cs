namespace Problem2337
{

  /// <summary>
  /// 2337. Move Pieces to Obtain a String
  /// https://leetcode.com/problems/move-pieces-to-obtain-a-string
  /// 
  /// Difficulty Medium
  /// Acceptance 52.8%
  /// 
  /// Two Pointers
  /// String
  /// </summary>
  public class Solution
  {
    public bool CanChange(string start, string target)
    {
      var startPosition = 0;
      var targetPosition = 0;

      while (true)
      {
        var isStart = TryFindNext(start, out var startSymbol, ref startPosition);
        var isTarget = TryFindNext(target, out var targetSymbol, ref targetPosition);

        if (isStart)
        {
          if (!isTarget ||
            startSymbol != targetSymbol ||
            startSymbol == 'L' && startPosition < targetPosition ||
            startSymbol == 'R' && startPosition > targetPosition)
            return false;
        }
        else
        {
          return !isTarget;
        }

        startPosition++;
        targetPosition++;
      }
    }

    private static bool TryFindNext(string s, out char symbol, ref int position)
    {
      symbol = '_';
      while (position < s.Length)
      {
        symbol = s[position];
        if (symbol == 'L' || symbol == 'R')
          return true;

        position++;
      }

      return false;
    }
  }
}
