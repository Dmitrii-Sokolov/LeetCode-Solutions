namespace Problem273
{

  /// <summary>
  /// 273. Integer to English Words
  /// https://leetcode.com/problems/integer-to-english-words
  /// 
  /// Difficulty Hard
  /// Acceptance 31.5%
  /// 
  /// Math
  /// String
  /// Recursion
  /// </summary>
  public class Solution
  {
    private const char Separator = ' ';

    public string NumberToWords(int number)
      => number == 0
        ? "Zero"
        : new System.Text.StringBuilder().AppendJoin(Separator, Test3(number)).ToString();

    private IEnumerable<string> Test3(int number)
    {
      foreach (var s in ParseGroup(number, "Billion", 1000000000))
        yield return s;

      foreach (var s in ParseGroup(number, "Million", 1000000))
        yield return s;

      foreach (var s in ParseGroup(number, "Thousand", 1000))
        yield return s;

      foreach (var s in ParseGroup(number))
        yield return s;
    }

    private IEnumerable<string> ParseGroup(int number, string name = "", int multiplier = 1, int size = 1000)
    {
      var group = number / multiplier % size;
      if (group > 0)
      {
        foreach (var s in Parse3Digits(group))
          yield return s;

        if (!string.IsNullOrEmpty(name))
          yield return name;
      }
    }

    private IEnumerable<string> Parse3Digits(int number)
    {
      var hundreds = Math.DivRem(number, 100, out number);
      if (hundreds > 0)
      {
        foreach (var s in Parse2Digits(hundreds))
          yield return s;

        yield return "Hundred";
      }

      if (number > 0)
      {
        foreach (var s in Parse2Digits(number))
          yield return s;
      }
    }

    private IEnumerable<string> Parse2Digits(int number)
    {
      if (number < 10)
        yield return ParseDigit(number);
      else if (number < 20)
      {
        yield return ParseTeen(number);
      }
      else
      {
        var tens = Math.DivRem(number, 10, out number);

        yield return ParseTy(tens);

        if (number > 0)
          yield return ParseDigit(number);
      }
    }

    private string ParseDigit(int digit)
    {
      return digit switch
      {
        1 => "One",
        2 => "Two",
        3 => "Three",
        4 => "Four",
        5 => "Five",
        6 => "Six",
        7 => "Seven",
        8 => "Eight",
        9 => "Nine",

        _ => "Impossible",
      };
    }

    private string ParseTeen(int digit)
    {
      return digit switch
      {
        10 => "Ten",
        11 => "Eleven",
        12 => "Twelve",
        13 => "Thirteen",
        14 => "Fourteen",
        15 => "Fifteen",
        16 => "Sixteen",
        17 => "Seventeen",
        18 => "Eighteen",
        19 => "Nineteen",

        _ => "Impossible",
      };
    }

    private string ParseTy(int digit)
    {
      return digit switch
      {
        2 => "Twenty",
        3 => "Thirty",
        4 => "Forty",
        5 => "Fifty",
        6 => "Sixty",
        7 => "Seventy",
        8 => "Eighty",
        9 => "Ninety",

        _ => "Impossible",
      };
    }
  }
}
