namespace Problem735
{

  /// <summary>
  /// 735. Asteroid Collision
  /// https://leetcode.com/problems/asteroid-collision
  /// 
  /// Difficulty Medium
  /// Acceptance 45.0%
  /// 
  /// Array
  /// Stack
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[] AsteroidCollision(int[] asteroids)
    {
      var result = new List<int>();
      foreach (var asteroid in asteroids)
      {
        while (result.Count > 0 && 0 < result[^1] && result[^1] < -asteroid)
          result.RemoveAt(result.Count - 1);

        if (asteroid > 0 || result.Count == 0 || result[^1] < 0)
        {
          result.Add(asteroid);
        }
        else if (result[^1] == -asteroid)
        {
          result.RemoveAt(result.Count - 1);
        }
      }

      return [.. result];
    }
  }
}
