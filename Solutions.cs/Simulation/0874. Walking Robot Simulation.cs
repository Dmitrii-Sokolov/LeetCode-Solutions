namespace Problem874
{

  /// <summary>
  /// 874. Walking Robot Simulation
  /// https://leetcode.com/problems/walking-robot-simulation
  /// 
  /// Difficulty Medium
  /// Acceptance 46.2%
  /// 
  /// Array
  /// Hash Table
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int RobotSim(int[] commands, int[][] obstaclesRaw)
    {
      var result = 0;
      var direction = Vector2.North;
      var position = Vector2.Zero;
      var obstacles = obstaclesRaw.Select(o => (Vector2)o).ToHashSet();

      foreach (var command in commands)
      {
        switch (command)
        {
          case -2:
            direction.RotateLeft();
            break;

          case -1:
            direction.RotateRight();
            break;

          default:
            for (var i = 0; i < command; i++)
            {
              var next = position + direction;

              if (obstacles.Contains(next))
                break;

              position = next;
              result = Math.Max(result, position.Sqr);
            }

            break;
        }
      }

      return result;
    }

    public struct Vector2(int x, int y) : IEquatable<Vector2>
    {
      public readonly static Vector2 Zero = new(0, 0);

      public readonly static Vector2 Right = new(1, 0);
      public readonly static Vector2 Up = new(0, 1);
      public readonly static Vector2 Left = new(-1, 0);
      public readonly static Vector2 Down = new(0, -1);

      public readonly static Vector2 North = Up;
      public readonly static Vector2 West = Right;
      public readonly static Vector2 South = Down;
      public readonly static Vector2 East = Left;

      public int X = x;
      public int Y = y;

      public readonly int Sqr => X * X + Y * Y;

      public void RotateRight() => (X, Y) = (Y, -X);

      public void RotateLeft() => (X, Y) = (-Y, X);

      public static implicit operator int[](Vector2 v) => [v.X, v.Y];
      public static implicit operator Vector2(int[] v) => new(v[0], v[1]);

      public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
      public static Vector2 operator -(Vector2 a, Vector2 b) => new(a.X - b.X, a.Y - b.Y);

      public static bool operator ==(Vector2 a, Vector2 b) => a.Equals(b);
      public static bool operator !=(Vector2 a, Vector2 b) => !a.Equals(b);

      public readonly bool Equals(Vector2 other) => X == other.X && Y == other.Y;

      public override readonly bool Equals(object obj) => obj is Vector2 v && Equals(v);
      public override readonly int GetHashCode() => HashCode.Combine(X, Y);
    }
  }
}
