namespace Problem726
{

  /// <summary>
  /// 726. Number of Atoms
  /// https://leetcode.com/problems/number-of-atoms
  /// 
  /// Difficulty Hard
  /// Acceptance 65.2%
  /// 
  /// Hash Table
  /// String
  /// Stack
  /// Sorting
  /// </summary>
  public class Solution
  {
    public string CountOfAtoms(string formula)
    {
      var dictionary = new Dictionary<string, int>();
      Proceed(formula, dictionary);

      var array = dictionary.Select(p => (p.Key, p.Value)).ToArray();
      Array.Sort(array, (a, b) => a.Key.CompareTo(b.Key));

      return array.Aggregate(
        new System.Text.StringBuilder(),
        (sb, p) => p.Value > 1
          ? sb.Append(p.Key).Append(p.Value)
          : sb.Append(p.Key),
        sb => sb.ToString());
    }

    private void Proceed(string formula, Dictionary<string, int> dictionary)
    {
      var name = string.Empty;
      var counter = 0;
      var power = 1;
      var multiplier = 1;
      var multipliers = new Stack<int>();
      for (var i = formula.Length - 1; i >= 0; i--)
      {
        var c = formula[i];
        if (char.IsLetter(c))
        {
          name = c + name;

          if (char.IsUpper(c))
          {
            Add(dictionary, name, counter, multiplier);

            name = string.Empty;
            counter = 0;
            power = 1;
          }
        }
        else if (char.IsDigit(c))
        {
          var d = c - '0';
          counter += d * power;
          power *= 10;
        }
        else if (c == ')')
        {
          multipliers.Push(multiplier);

          if (counter != 0)
            multiplier *= counter;

          counter = 0;
          power = 1;
        }
        else if (c == '(')
        {
          multiplier = multipliers.Pop();
        }
      }
    }

    private static void Add(Dictionary<string, int> dictionary, string name, int counter, int multiplier)
    {
      if (counter == 0)
        counter = 1;

      dictionary[name] = dictionary.TryGetValue(name, out var value)
        ? value + (counter * multiplier)
        : counter * multiplier;
    }
  }
}
