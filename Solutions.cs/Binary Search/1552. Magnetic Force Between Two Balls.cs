namespace Problem1552
{

  /// <summary>
  /// 1552. Magnetic Force Between Two Balls
  /// https://leetcode.com/problems/magnetic-force-between-two-balls
  /// 
  /// Difficulty Medium
  /// Acceptance 71.1%
  /// 
  /// Array
  /// Binary Search
  /// Sorting
  /// </summary>
  public class Solution
  {
    public int MaxDistance(int[] position, int m)
    {
      Array.Sort(position);
      var min = 1;
      var max = (position[position.Length - 1] - position[0]) / (m - 1);
      var result = max;

      while (min <= max)
      {
        var middle = min + ((max - min) / 2);

        if (Check(position, m, middle))
        {
          min = middle + 1;
          result = middle;
        }
        else
        {
          max = middle - 1;
        }
      }

      return result;
    }

    private bool Check(int[] position, int m, int x)
    {
      var last = position[0];
      m--;

      for (var i = 1; i < position.Length; i++)
      {
        if (position[i] - last >= x)
        {
          last = position[i];
          m--;
          if (m == 0)
            return true;
        }
      }

      return false;
    }
  }
}
