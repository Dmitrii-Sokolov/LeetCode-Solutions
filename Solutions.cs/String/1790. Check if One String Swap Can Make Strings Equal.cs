namespace Problem1790
{

  /// <summary>
  /// 1790. Check if One String Swap Can Make Strings Equal
  /// https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal
  /// 
  /// Difficulty Easy
  /// Acceptance 47.4%
  /// 
  /// Hash Table
  /// String
  /// Counting
  /// </summary>
  public class Solution
  {
    private enum State
    {
      Equal,
      Different,
      Swapped
    }

    public bool AreAlmostEqual(string s1, string s2)
    {
      var length = s1.Length;
      var state = State.Equal;
      var c1 = ' ';
      var c2 = ' ';
      for (var i = 0; i < length; i++)
      {
        if (s1[i] != s2[i])
        {
          switch (state)
          {
            case State.Equal:
              state = State.Different;
              c1 = s1[i];
              c2 = s2[i];
              break;

            case State.Different:
              if (s1[i] != c2 || s2[i] != c1)
              {
                return false;
              }
              else
              {
                state = State.Swapped;
              }

              break;

            case State.Swapped:
              return false;

            default:
              throw new NotImplementedException();
          }
        }
      }

      return state == State.Swapped || state == State.Equal;
    }
  }
}
