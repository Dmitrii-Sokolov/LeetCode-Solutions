namespace Problem1861
{

  /// <summary>
  /// 1861. Rotating the Box
  /// https://leetcode.com/problems/rotating-the-box
  /// 
  /// Difficulty Medium
  /// Acceptance 71.2%
  /// 
  /// Array
  /// Two Pointers
  /// Matrix
  /// </summary>
  public class Solution
  {
    public char[][] RotateTheBox(char[][] box)
    {
      var m = box.Length;
      var n = box[0].Length;

      var result = new char[n][];
      for (var i = 0; i < n; i++)
        result[i] = new char[m];

      for (var i = 0; i < m; i++)
      {
        var column = box[i];
        var index = m - 1 - i;
        var bottom = n;
        for (var top = n - 1; top >= 0; top--)
        {
          var c = column[top];
          switch (c)
          {
            case '*':
              while (bottom > top + 1)
                result[--bottom][index] = '.';
              result[--bottom][index] = c;
              break;

            case '#':
              result[--bottom][index] = c;
              break;

            case '.':
              break;
          }
        }

        while (bottom > 0)
          result[--bottom][index] = '.';
      }

      return result;
    }
  }
}
