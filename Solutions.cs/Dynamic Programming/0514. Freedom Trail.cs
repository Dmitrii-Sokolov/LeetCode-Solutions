namespace Problem514
{

  /// <summary>
  /// 514. Freedom Trail
  /// https://leetcode.com/problems/freedom-trail
  /// 
  /// Difficulty Hard
  /// Acceptance 59.0%
  /// 
  /// String
  /// Dynamic Programming
  /// Depth-First Search
  /// Breadth-First Search
  /// </summary>
  public class Solution
  {
    public int FindRotateSteps(string ring, string key)
    {
      Ring = ring;
      Key = key;
      Results = new int[ring.Length, key.Length];

      return Check(0, 0);
    }

    private int MinResult = int.MaxValue;
    private string Ring;
    private string Key;
    private int[,] Results;

    private int Check(int rotation, int step)
    {
      if (step == Key.Length)
        return 0;
      else
      {
        var result = Results[rotation, step];

        if (result > 0)
          return result;

        result = int.MaxValue;
        for (var i = 0; i < Ring.Length; i++)
        {
          if (Ring[i] == Key[step])
          {
            var add = Math.Min(Mod(i - rotation, Ring.Length), Mod(rotation - i, Ring.Length));
            result = Math.Min(result, Check(i, step + 1) + add + 1);
          }
        }

        Results[rotation, step] = result;
        return result;
      }
    }

    private static int Mod(int x, int m)
    {
      return ((x % m) + m) % m;
    }
  }
}
