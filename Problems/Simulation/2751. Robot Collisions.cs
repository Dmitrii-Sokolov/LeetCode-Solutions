namespace Problem2751
{

  /// <summary>
  /// 2751. Robot Collisions
  /// https://leetcode.com/problems/robot-collisions
  /// 
  /// Difficulty Hard 57.1%
  /// 
  /// Array
  /// Stack
  /// Sorting
  /// Simulation
  /// </summary>
  public class Solution
  {
    private class Robot
    {
      public int Index { get; set; }
      public int Position { get; set; }
      public int Health { get; set; }
      public int Direction { get; set; }

      public Robot(int index, int position, int health, int direction)
      {
        Index = index;
        Position = position;
        Health = health;
        Direction = direction;
      }
    }

    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions)
    {
      var leftRobots = new Robot[positions.Length];
      for (var i = 0; i < positions.Length; i++)
      {
        leftRobots[i] = new Robot(i,
          positions[i],
          healths[i],
          directions[i] == 'R' ? 1 : -1);
      }

      Array.Sort(leftRobots, (a, b) => b.Position.CompareTo(a.Position));

      var result = new List<(int Index, int Health)>();
      var rightRobots = new Stack<Robot>();
      for (var i = 0; i < leftRobots.Length; i++)
      {
        var left = leftRobots[i];
        if (left.Direction > 0)
        {
          if (rightRobots.Count > 0)
          {
            var right = rightRobots.Pop();
            if (left.Health > right.Health)
            {
              left.Health--;
              i--;
            }
            else if (left.Health < right.Health)
            {
              right.Health--;
              rightRobots.Push(right);
            }
          }
          else
          {
            result.Add((left.Index, left.Health));
          }
        }
        else
        {
          rightRobots.Push(left);
        }
      }

      foreach (var right in rightRobots)
        result.Add((right.Index, right.Health));

      result.Sort((a, b) => a.Index.CompareTo(b.Index));
      return result.Select(robot => robot.Health).ToList();
    }
  }
}
