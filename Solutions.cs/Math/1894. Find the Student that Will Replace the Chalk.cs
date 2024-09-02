namespace Problem1894
{

  /// <summary>
  /// 1894. Find the Student that Will Replace the Chalk
  /// https://leetcode.com/problems/find-the-student-that-will-replace-the-chalk
  /// 
  /// Difficulty Medium
  /// Acceptance 49.4%
  /// 
  /// Array
  /// Binary Search
  /// Simulation
  /// Prefix Sum
  /// </summary>
  public class Solution
  {
    public int ChalkReplacer(int[] chalk, int k)
    {
      var current = k;
      while (true)
      {
        for (var i = 0; i < chalk.Length; i++)
        {
          if (chalk[i] > current)
            return i;

          current -= chalk[i];
        }

        var sum = k - current;
        current %= sum;
      }
    }
  }
}
