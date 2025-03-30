namespace MathExtension
{
  public static class Math
  {
    private static int Mod(int x, int m) => (x % m + m) % m;

    private static bool IsIntersect(int[] a, int[] b)
      => b[0] <= a[0] && a[0] <= b[1] ||
      a[0] <= b[0] && b[0] <= a[1];

    private static int DivCeil(int a, int b) => 1 + (a - 1) / b;
    private static long DivCeil(long a, long b) => 1 + (a - 1) / b;
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

    public override string ToString() => $"({X}, {Y})";
  }
}
