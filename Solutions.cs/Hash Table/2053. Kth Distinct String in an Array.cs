namespace Problem2053
{

  /// <summary>
  /// 2053. Kth Distinct String in an Array
  /// https://leetcode.com/problems/kth-distinct-string-in-an-array
  /// 
  /// Difficulty Easy
  /// Acceptance 77.6%
  /// 
  /// Array
  /// Hash Table
  /// String
  /// Counting
  /// </summary>
  public class Solution
  {
    public string KthDistinct(string[] arr, int k)
    {
      var dictionary = new Dictionary<string, int>();
      foreach (var item in arr)
        dictionary[item] = dictionary.GetValueOrDefault(item) + 1;

      foreach (var item in arr)
      {
        if (dictionary[item] == 1)
          k--;

        if (k == 0)
          return item;
      }

      return "";
    }
  }
}
