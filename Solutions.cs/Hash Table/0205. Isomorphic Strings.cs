namespace Problem205
{

  /// <summary>
  /// 205. Isomorphic Strings
  /// https://leetcode.com/problems/isomorphic-strings
  /// 
  /// Difficulty Easy
  /// Acceptance 45.5%
  /// 
  /// Hash Table
  /// String
  /// </summary>
  public class Solution
  {
    public bool IsIsomorphic(string s, string t)
    {
      if (s.Length != t.Length)
        return false;

      var map = new Dictionary<char, char>();
      var used = new HashSet<char>();

      for (var i = 0; i < s.Length; i++)
      {
        var a = s[i];
        var b = t[i];

        if (map.TryGetValue(a, out var c))
        {
          if (c != b)
            return false;
        }
        else
        {
          if (used.Contains(b))
            return false;

          map[a] = b;
          used.Add(b);
        }
      }

      return true;
    }
  }
}
