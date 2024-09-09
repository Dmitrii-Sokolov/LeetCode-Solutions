namespace Problem2326
{

  /// <summary>
  /// 2326. Spiral Matrix IV
  /// https://leetcode.com/problems/spiral-matrix-iv
  /// 
  /// Difficulty Medium
  /// Acceptance 78.8%
  /// 
  /// Array
  /// Linked List
  /// Matrix
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[][] SpiralMatrix(int height, int width, ListNode node)
    {
      var result = new int[height][];
      for (var i = 0; i < result.Length; i++)
      {
        result[i] = new int[width];
        Array.Fill(result[i], -1);
      }

      var position = Vector2.Zero;
      var direction = Vector2.Right;
      while (node != null)
      {
        result[position.Y][position.X] = node.val;
        var next = position + direction;
        if (!IsInside(next) || result[next.Y][next.X] != -1)
          direction.RotateLeft();

        position += direction;
        node = node.next;
      }

      return result;

      bool IsInside(Vector2 v) => 0 <= v.X && v.X < width && 0 <= v.Y && v.Y < height;
    }

    private struct Vector2(int x, int y) : IEquatable<Vector2>
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
