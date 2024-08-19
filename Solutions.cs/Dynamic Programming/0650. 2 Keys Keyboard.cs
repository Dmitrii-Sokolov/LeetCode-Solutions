namespace Problem650
{

  /// <summary>
  /// 650. 2 Keys Keyboard
  /// https://leetcode.com/problems/2-keys-keyboard
  /// 
  /// Difficulty Medium
  /// Acceptance 55.9%
  /// 
  /// Math
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int MinSteps(int n)
    {
      var visited = new HashSet<State>();

      var possibilities = new List<State>();
      possibilities.Add((1, 0));
      var steps = 0;

      while (true)
      {
        var next = new List<State>();
        foreach (var (text, buffer) in possibilities)
        {
          if (text == n)
            return steps;

          if (text < n && visited.Add((text, text)))
            next.Add((text, text));

          if (text + buffer <= n && visited.Add((text + buffer, buffer)))
            next.Add((text + buffer, buffer));
        }

        steps++;
        possibilities = next;
      }
    }

    private record struct State(int Text, int Buffer) : IEquatable<State>
    {
      public override int GetHashCode() => HashCode.Combine(Text, Buffer);

      public static implicit operator (int Text, int Buffer)(State value) => (value.Text, value.Buffer);
      public static implicit operator State((int Text, int Buffer) value) => new(value.Text, value.Buffer);
    }
  }
}
