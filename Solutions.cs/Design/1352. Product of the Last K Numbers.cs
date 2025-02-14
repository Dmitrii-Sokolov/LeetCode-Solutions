namespace Problem1352
{

  /// <summary>
  /// 1352. Product of the Last K Numbers
  /// https://leetcode.com/problems/product-of-the-last-k-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 56.8%
  /// 
  /// Array
  /// Math
  /// Design
  /// Data Stream
  /// Prefix Sum
  /// </summary>
  public class ProductOfNumbers
  {
    private readonly List<int> Products = [1];

    public void Add(int number)
    {
      if (number == 0)
      {
        Products.Clear();
        Products.Add(1);
      }
      else
      {
        Products.Add(number * Products[^1]);
      }
    }

    public int GetProduct(int k) => Products.Count > k ? Products[^1] / Products[^(k + 1)] : 0;
  }
}
