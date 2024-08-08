namespace Problem885
{

  /// <summary>
  /// 885. Spiral Matrix III
  /// https://leetcode.com/problems/spiral-matrix-iii
  /// 
  /// Difficulty Medium
  /// Acceptance 78.3%
  /// 
  /// Array
  /// Matrix
  /// Simulation
  /// </summary>
  public class Solution
  {
    public int[][] SpiralMatrixIII(int xMax, int yMax, int x, int y)
    {
      var result = new int[xMax * yMax][];
      var index = 0;
      var direction = new Vector2(0, 1);
      var currentCell = new Vector2(x, y);

      while (index < result.Length)
      {
        var target = currentCell + direction;

        while (currentCell != target)
        {
          if (IsInside(currentCell))
            result[index++] = currentCell;

          currentCell += direction.GetSign();
        }

        direction.Rotate();
      }

      bool IsInside(Vector2 v) => 0 <= v.X && v.X < xMax && 0 <= v.Y && v.Y < yMax;

      return result;
    }

    private struct Vector2 : IEquatable<Vector2>
    {
      public int X;
      public int Y;

      public Vector2(int x, int y)
      {
        X = x;
        Y = y;
      }

      public void Rotate()
      {
        (X, Y) = (Y, -X);

        if (Y < 0)
          Y--;

        if (Y > 0)
          Y++;
      }

      public Vector2 GetSign() => new(Math.Sign(X), Math.Sign(Y));

      public static implicit operator int[](Vector2 v) => [v.X, v.Y];

      public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);

      public static bool operator ==(Vector2 a, Vector2 b) => a.Equals(b);
      public static bool operator !=(Vector2 a, Vector2 b) => !a.Equals(b);

      public override bool Equals(object obj) => obj is Vector2 v && Equals(v);
      public bool Equals(Vector2 other) => X == other.X && Y == other.Y;
      public override int GetHashCode() => HashCode.Combine(X, Y);
    }
  }
}
