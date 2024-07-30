/// <summary>
/// 402. Remove K Digits
/// https://leetcode.com/problems/remove-k-digits
/// 
/// Difficulty Medium
/// Acceptance 33.7%
/// 
/// String
/// Stack
/// Greedy
/// Monotonic Stack
/// </summary>
class Solution
{
  public String removeKdigits(String num, int k)
  {
    var len = num.length();
    if (k == len)
      return "0";
    
    var result = new LinkedList<Character>();

    for (var i = 0; i < len; i++)
    {
      var digit = num.charAt(i);

      while (k > 0 && result.size() > 0 && result.getLast() > digit)
      {
        k--;
        result.removeLast();
      }

      result.addLast(digit);
    }

    while (k-- > 0)
      result.removeLast();

    while (result.size() > 1 && result.getFirst() == '0')
      result.removeFirst();

    var sb = new StringBuilder();
    while (result.size() > 0)
    {
      var el = result.pollFirst();
      sb.append(el);
    }

    return sb.toString();
  }
}
