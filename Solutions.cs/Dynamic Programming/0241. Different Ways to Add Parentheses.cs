namespace Problem241
{

  /// <summary>
  /// 241. Different Ways to Add Parentheses
  /// https://leetcode.com/problems/different-ways-to-add-parentheses
  /// 
  /// Difficulty Medium
  /// Acceptance 70.8%
  /// 
  /// Math
  /// String
  /// Dynamic Programming
  /// Recursion
  /// Memoization
  /// </summary>
  public class Solution
  {
    private readonly List<Func<int, int, int>> Operators = [];
    private readonly List<int> Numbers = [];

    public IList<int> DiffWaysToCompute(string expression)
    {
      var lastPrefix = 0;
      foreach (var c in expression)
      {
        switch (c)
        {
          case '-':
          case '+':
          case '*':
            Operators.Add(GetFunc(c));
            Numbers.Add(lastPrefix);
            lastPrefix = 0;
            break;

          default:
            lastPrefix = lastPrefix * 10 + (c - '0');
            break;
        }
      }

      Numbers.Add(lastPrefix);

      return Check(0, Numbers.Count - 1).ToArray();
    }

    private IEnumerable<int> Check(int from, int to)
    {
      if (from == to)
      {
        yield return Numbers[from];
      }
      else
      {
        for (var i = from; i < to; i++)
        {
          var compute = Operators[i];
          var first = Check(from, i);
          var second = Check(i + 1, to);

          foreach (var item0 in first)
          {
            foreach (var item1 in second)
              yield return compute(item0, item1);
          }
        }
      }
    }

    private static Func<int, int, int> GetFunc(char c)
    {
      return c switch
      {
        '-' => (a, b) => a - b,
        '+' => (a, b) => a + b,
        '*' => (a, b) => a * b,
        _ => throw new NotImplementedException(),
      };
    }
  }
}
