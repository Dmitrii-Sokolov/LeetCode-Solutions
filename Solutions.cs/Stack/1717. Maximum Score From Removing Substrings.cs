namespace Problem1717
{

  /// <summary>
  /// 1717. Maximum Score From Removing Substrings
  /// https://leetcode.com/problems/maximum-score-from-removing-substrings
  /// 
  /// Difficulty Medium
  /// Acceptance 63.1%
  /// 
  /// String
  /// Stack
  /// Greedy
  /// </summary>
  public class Solution
  {
    public int MaximumGain(string s, int x, int y)
    {
      var result = 0;
      var list = new LinkedList<byte>();
      var (a, b) = x > y ? ('a', 'b') : ('b', 'a');
      (x, y) = (x > y) ? (x, y) : (y, x);

      for (var i = 0; i < s.Length; i++)
      {
        if (s[i] == a)
        {
          list.AddLast(0);
        }
        else if (s[i] == b)
        {
          if (list.Count > 0 && list.Last.Value == 0)
          {
            list.RemoveLast();
            result += x;
          }
          else
          {
            list.AddLast(1);
          }
        }
        else
        {
          result += y * Proceed(list);
          list.Clear();
        }
      }

      result += y * Proceed(list);

      return result;
    }

    private int Proceed(LinkedList<byte> list)
    {
      var result = 0;
      var current = list.First;

      while (current != null && current.Next != null)
      {
        if (current.Value == 1 && current.Next.Value == 0)
        {
          result++;
          if (current.Previous != null)
          {
            current = current.Previous;
            list.Remove(current.Next);
            list.Remove(current.Next);
          }
          else
          {
            list.RemoveFirst();
            list.RemoveFirst();
            current = list.First;
          }
        }
        else
        {
          current = current.Next;
        }
      }

      return result;
    }
  }
}
