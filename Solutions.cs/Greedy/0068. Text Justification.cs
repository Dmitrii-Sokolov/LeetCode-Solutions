namespace Problem68
{

  /// <summary>
  /// 68. Text Justification
  /// https://leetcode.com/problems/text-justification
  /// 
  /// Difficulty Hard
  /// Acceptance 44.5%
  /// 
  /// Array
  /// String
  /// Simulation
  /// </summary>
  public class Solution
  {
    private const char Space = ' ';

    public IList<string> FullJustify(string[] words, int maxWidth)
    {
      var line = new System.Text.StringBuilder();
      var result = new List<string>();
      var index = 0;

      while (index < words.Length)
      {
        line.Clear();
        var firstIndex = index;
        var lineCharCount = 0;
        while (index < words.Length && lineCharCount + words[index].Length <= maxWidth)
          lineCharCount += words[index++].Length + 1;

        var wordsCount = index - firstIndex;
        var spacesCount = maxWidth - lineCharCount + wordsCount;
        var gap = wordsCount == 1 ? spacesCount : spacesCount / (wordsCount - 1);
        var remainder = wordsCount == 1 ? 0 : spacesCount % (wordsCount - 1);
        var isFirst = true;

        for (; firstIndex < index; firstIndex++)
        {
          if (!isFirst)
          {
            var spaces = index == words.Length ? 1 : gap + (remainder-- > 0 ? 1 : 0);
            line.Append(Space, spaces);
          }

          line.Append(words[firstIndex]);
          isFirst = false;
        }

        if (line.Length < maxWidth)
          line.Append(Space, maxWidth - line.Length);

        result.Add(line.ToString());
      }

      return result;
    }
  }
}
