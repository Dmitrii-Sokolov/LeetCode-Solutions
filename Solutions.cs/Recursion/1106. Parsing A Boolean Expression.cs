namespace Problem1106
{

  /// <summary>
  /// 1106. Parsing A Boolean Expression
  /// https://leetcode.com/problems/parsing-a-boolean-expression
  /// 
  /// Difficulty Hard
  /// Acceptance 63.7%
  /// 
  /// String
  /// Stack
  /// Recursion
  /// </summary>
  public class Solution
  {
    public bool ParseBoolExpr(string expression, int pointer = 0)
    {
      return expression[pointer] switch
      {
        't' => true,
        'f' => false,
        '!' => !ParseBoolExpr(expression, pointer + 2),
        '&' => ParseGroup(expression, pointer + 2).Aggregate((a, b) => a && b),
        '|' => ParseGroup(expression, pointer + 2).Aggregate((a, b) => a || b),
        _ => throw new ArgumentException(expression),
      };
    }

    private IEnumerable<bool> ParseGroup(string expression, int pointer)
    {
      yield return ParseBoolExpr(expression, pointer);

      var depth = 1;
      while (depth > 0)
      {
        if (depth == 1 && expression[pointer] == ',')
        {
          yield return ParseBoolExpr(expression, pointer + 1);
          pointer += 2;
        }
        else if (expression[pointer] == '(')
        {
          pointer += 2;
          depth++;
        }
        else if (expression[pointer] == ')')
        {
          depth--;
          pointer += 1;
        }
        else
        {
          pointer += 1;
        }
      }
    }
  }
}
