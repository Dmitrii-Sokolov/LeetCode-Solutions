namespace Extensions
{
  public static class Math
  {
    private static int Mod(int x, int m) => ((x % m) + m) % m;
  }

  public struct Vector2 : IEquatable<Vector2>
  {
    public int X;
    public int Y;

    public Vector2(int x, int y)
    {
      X = x;
      Y = y;
    }

    public static implicit operator int[](Vector2 v) => [v.X, v.Y];

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);

    public static bool operator ==(Vector2 a, Vector2 b) => a.Equals(b);
    public static bool operator !=(Vector2 a, Vector2 b) => !a.Equals(b);

    public override bool Equals(object obj) => obj is Vector2 v && Equals(v);
    public bool Equals(Vector2 other) => X == other.X && Y == other.Y;
    public override int GetHashCode() => HashCode.Combine(X, Y);
  }
}
