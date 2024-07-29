/// <summary>
/// 13. Roman to Integer
/// https://leetcode.com/problems/roman-to-integer
/// 
/// Difficulty Easy
/// Acceptance 62.1%
/// 
/// Hash Table
/// Math
/// String
/// </summary>
class Solution
{
  public int romanToInt(String s)
  {
    var map = new HashMap<Character, Integer>();

    map.put('I', 1);
    map.put('V', 5);
    map.put('X', 10);
    map.put('L', 50);
    map.put('C', 100);
    map.put('D', 500);
    map.put('M', 1000);

    var result = 0;
    var max = 0;

    for (var i = s.length() - 1; i >= 0; i--)
    {
      var val = map.get(s.charAt(i));
      max = Math.max(max, val);
      if (max > val)
      {
        result -= val;
      }
      else
      {
        result += val;
      }
    }

    return result;
  }
}
