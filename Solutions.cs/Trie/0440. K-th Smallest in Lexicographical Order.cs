namespace Problem440
{

  /// <summary>
  /// 440. K-th Smallest in Lexicographical Order
  /// https://leetcode.com/problems/k-th-smallest-in-lexicographical-order
  /// 
  /// Difficulty Hard
  /// Acceptance 34.7%
  /// 
  /// Trie
  /// </summary>
  public class Solution
  {
    public int FindKthNumber(int n, int k)
    {
      var nDigits = DigitsCount(n);
      var stack = new Stack<int>();
      stack.Push(1);
      while (true)
      {
        var prefix = stack.Peek();
        if (prefix <= n)
        {
          if (k == 1)
            return prefix;

          var postfixesCount = CountPostfixes(n, nDigits, prefix);
          if (k > postfixesCount)
          {
            k -= postfixesCount;

            while (stack.Peek() % 10 == 9)
              stack.Pop();

            stack.Push(stack.Pop() + 1);
          }
          else
          {
            k--;
            stack.Push(10 * stack.Peek());
          }
        }
        else
        {
          stack.Pop();
          while (stack.Peek() % 10 == 9)
            stack.Pop();

          stack.Push(stack.Pop() + 1);
        }
      }
    }

    private static int CountPostfixes(int n, int nDigits, int prefix)
    {
      if (n == prefix)
        return 1;

      var nStart = n;
      var nStartDigits = DigitsCount(nStart);
      var prefixDigits = DigitsCount(prefix);
      while (nStartDigits > prefixDigits)
      {
        nStart /= 10;
        nStartDigits--;
      }

      var postfixesCount = 0;
      var variants = 1;
      for (var i = 0; i < nDigits - prefixDigits; i++)
      {
        postfixesCount += variants;
        variants *= 10;
      }

      if (nStart == prefix)
        postfixesCount += n - variants * prefix + 1;
      else if (nStart > prefix)
      {
        postfixesCount += variants;
      }

      return postfixesCount;
    }

    private static int DigitsCount(int number)
    {
      var digits = 0;
      while (number > 0)
      {
        number /= 10;
        digits++;
      }

      return digits;
    }
  }
}
