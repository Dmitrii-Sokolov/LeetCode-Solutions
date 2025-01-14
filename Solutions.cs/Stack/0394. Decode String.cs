namespace Problem394
{

  /// <summary>
  /// 394. Decode String
  /// https://leetcode.com/problems/decode-string
  /// 
  /// Difficulty Medium
  /// Acceptance 60.4%
  /// 
  /// String
  /// Stack
  /// Recursion
  /// </summary>
  public class Solution
  {
    public string DecodeString(string s)
    {
      var isDigit = false;
      var strings = new List<string>();
      var repeats = new List<int>();

      strings.Add(string.Empty);

      foreach (var c in s)
      {
        switch (c)
        {
          case < '[':
            if (!isDigit)
              repeats.Add(0);
            repeats[^1] = 10 * repeats[^1] + c - '0';
            isDigit = true;
            break;

          case > ']':
            strings[^1] += c;
            isDigit = false;
            break;

          case ']':
            if (repeats[^1] == 0)
              repeats[^1] = 1;
            while (--repeats[^1] >= 0)
              strings[^2] += strings[^1];
            repeats.RemoveAt(repeats.Count - 1);
            strings.RemoveAt(strings.Count - 1);
            isDigit = false;
            break;

          case '[':
            strings.Add(string.Empty);
            isDigit = false;
            break;
        }
      }

      return strings[0];
    }
  }
}
