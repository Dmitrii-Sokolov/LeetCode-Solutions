namespace Problem1190
{

  /// <summary>
  /// 1190. Reverse Substrings Between Each Pair of Parentheses
  /// https://leetcode.com/problems/reverse-substrings-between-each-pair-of-parentheses
  /// 
  /// Difficulty Medium
  /// Acceptance 71.7%
  /// 
  /// String
  /// Stack
  /// </summary>
  public class Solution
  {
    public string ReverseParentheses(string s)
    {
      var brackets = new Stack<int>();
      var line = s.ToArray();

      for (var i = 0; i < s.Length; i++)
      {
        if (s[i] == '(')
        {
          brackets.Push(i);
        }
        else if (s[i] == ')')
        {
          var from = brackets.Pop();
          var to = i;
          Reverse(line, from, to);
        }
      }

      return line.
        Where(c => c != '(' && c != ')').
        Aggregate(
          new System.Text.StringBuilder(),
          (sb, c) => sb.Append(c),
          sb => sb.ToString());
    }

    private void Reverse(char[] line, int from, int to)
    {
      for (var i = 1; i < ((to - from) / 2) + 1; i++)
      {
        var a = from + i;
        var b = to - i;
        var temp = line[a];
        line[a] = line[b];
        line[b] = temp;
      }
    }
  }
}
