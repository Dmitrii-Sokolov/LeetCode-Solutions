namespace Problem386
{

  /// <summary>
  /// 386. Lexicographical Numbers
  /// https://leetcode.com/problems/lexicographical-numbers
  /// 
  /// Difficulty Medium
  /// Acceptance 67.0%
  /// 
  /// Depth-First Search
  /// Trie
  /// </summary>
  public class Solution
  {
    public IList<int> LexicalOrder(int n)
    {
      var result = new List<int>(n);
      var stack = new Stack<int>();
      stack.Push(1);
      while (result.Count < n)
      {
        if (stack.Peek() <= n)
        {
          result.Add(stack.Peek());
          stack.Push(10 * stack.Peek());
        }
        else
        {
          stack.Pop();
          while (stack.Peek() % 10 == 9)
            stack.Pop();

          stack.Push(stack.Pop() + 1);
        }
      }

      return result;
    }
  }
}
