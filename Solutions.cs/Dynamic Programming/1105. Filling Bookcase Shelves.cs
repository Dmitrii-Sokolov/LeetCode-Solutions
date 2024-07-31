namespace Problem1105
{

  /// <summary>
  /// 1105. Filling Bookcase Shelves
  /// https://leetcode.com/problems/filling-bookcase-shelves
  /// 
  /// Difficulty Medium
  /// Acceptance 62.4%
  /// 
  /// Array
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int MinHeightShelves(int[][] books, int shelfWidth, int[] memory = default, int from = 0)
    {
      if (from == books.Length)
        return 0;

      memory ??= new int[books.Length];
      if (memory[from] > 0)
        return memory[from];

      var minHeight = int.MaxValue;
      var currentWidth = 0;
      var currentHeight = 0;
      for (var i = from; i < books.Length; i++)
      {
        var book = books[i];
        var width = book[0];
        var height = book[1];

        currentWidth += width;
        if (currentWidth > shelfWidth)
          break;

        currentHeight = Math.Max(currentHeight, height);
        minHeight = Math.Min(minHeight, currentHeight + MinHeightShelves(books, shelfWidth, memory, i + 1));
      }

      memory[from] = minHeight;
      return minHeight;
    }
  }
}
