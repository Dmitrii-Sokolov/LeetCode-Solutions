namespace Problem1726
{

  /// <summary>
  /// 1726. Tuple with Same Product
  /// https://leetcode.com/problems/tuple-with-same-product
  /// 
  /// Difficulty Medium
  /// Acceptance 66.6%
  /// 
  /// Array
  /// Hash Table
  /// Counting
  /// </summary>
  public class Solution
  {
    public int TupleSameProduct(int[] numbers)
    {
      var products = new Dictionary<int, int>();
      for (var i = 0; i < numbers.Length; i++)
      {
        for (var k = i + 1; k < numbers.Length; k++)
        {
          var product = numbers[i] * numbers[k];
          products[product] = products.GetValueOrDefault(product) + 1;
        }
      }

      var result = 0;
      foreach (var item in products.Values)
        result += item * (item - 1) * 4;

      return result;
    }
  }
}
