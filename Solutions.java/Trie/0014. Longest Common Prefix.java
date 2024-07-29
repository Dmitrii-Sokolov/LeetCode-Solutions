/// <summary>
/// 14. Longest Common Prefix
/// https://leetcode.com/problems/longest-common-prefix
/// 
/// Difficulty Easy
/// Acceptance 43.4%
/// 
/// String
/// Trie
/// </summary>
class Solution
{
  public String longestCommonPrefix(String[] strs)
  {
    var result = strs[0];
    for (var i = 1; i < strs.length; i++)
    {
      while (strs[i].indexOf(result) != 0)
      {
        result = result.substring(0, result.length() - 1);
      }
    }

    return result;

    // var min = 200;
    // for (var i = 0; i < strs.length; i++) {
    //     min = Math.min(min, strs[i].length());
    // }

    // var result = new StringBuilder();
    // var pointer = 0;

    // for (var p = 0; p < min; p++) {
    //     var c = strs[0].charAt(p);

    //     for (var i = 1; i < strs.length; i++) {
    //         if (c != strs[i].charAt(p)) {
    //             return result.toString();
    //         }
    //     }

    //     result.append(c);
    // }

    // return result.toString();
  }
}
