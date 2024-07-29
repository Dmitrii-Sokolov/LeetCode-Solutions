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
class Solution
{
  public boolean isIsomorphic(String s, String t)
  {
    if (s.length() != t.length())
      return false;

    var map = new HashMap<Character, Character>();
    var used = new HashSet<Character>();

    for (var i = 0; i < s.length(); i++)
    {
      var a = s.charAt(i);
      var b = t.charAt(i);

      var c = map.get(a);
      if (c != null)
      {
        if (c != b)
          return false;
      }
      else
      {
        if (used.contains(b))
          return false;

        map.put(a, b);
        used.add(b);
      }
    }

    return true;
  }
}
