/// <summary>
/// 592. Fraction Addition and Subtraction
/// https://leetcode.com/problems/fraction-addition-and-subtraction
/// 
/// Difficulty Medium
/// Acceptance 58.1%
/// 
/// Math
/// String
/// Simulation
/// </summary>
public class Solution
{
  public string FractionAddition(string expression)
  {
    var commonDenominator = 10 * 9 * 4 * 7;
    var regex = "(-?\\d*)[\\/?](\\d*)";
    var pairs = System.Text.RegularExpressions.Regex.Match(expression, regex);
    var resultNumerator = 0;
    var resultDenominator = commonDenominator;

    while (pairs.Success)
    {
      var numerator = int.Parse(pairs.Groups[1].Value);
      var denominator = int.Parse(pairs.Groups[2].Value);

      var multiplier = commonDenominator / denominator;
      resultNumerator += numerator * multiplier;

      pairs = pairs.NextMatch();
    }

    int[] components = { 5, 2, 3, 3, 2, 2, 7 };

    foreach (var component in components)
    {
      if (resultNumerator % component == 0)
      {
        resultNumerator /= component;
        resultDenominator /= component;
      }
    }

    return $"{resultNumerator}/{resultDenominator}";
  }
}
