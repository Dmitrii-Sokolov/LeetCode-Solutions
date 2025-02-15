namespace Problem2698
{

  /// <summary>
  /// 2698. Find the Punishment Number of an Integer
  /// https://leetcode.com/problems/find-the-punishment-number-of-an-integer
  /// 
  /// Difficulty Medium
  /// Acceptance 75.8%
  /// 
  /// Math
  /// Backtracking
  /// </summary>
  public class Solution
  {
    private readonly int[] GoodNumbers = [1, 9, 10, 36, 45, 55, 82, 91, 99, 100, 235, 297, 369, 370, 379, 414, 657, 675, 703, 756, 792, 909, 918, 945, 964, 990, 991, 999, 1000, 1296];

    public int PunishmentNumber(int n)
    {
      var i = 0;
      var result = 0;
      while (GoodNumbers[i] <= n)
      {
        result += GoodNumbers[i] * GoodNumbers[i];
        i++;
      }

      return result;
    }

    //public int PunishmentNumber(int n)
    //{
    //  var result = 0;
    //  for (var i = 1; i <= n; i++)
    //  {
    //    var square = i * i;
    //    if (Check(i, square))
    //      result += square;
    //  }
    //
    //  return result;
    //}
    //
    //private bool Check(int number, int digits)
    //{
    //  return 0 < digits && number <= digits &&
    //    (number == digits ||
    //    Check(number - digits % 10, digits / 10) ||
    //    Check(number - digits % 100, digits / 100) ||
    //    Check(number - digits % 1000, digits / 1000));
    //}
  }
}
