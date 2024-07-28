namespace Problem2709
{

  /// <summary>
  /// 2709. Greatest Common Divisor Traversal
  /// https://leetcode.com/problems/greatest-common-divisor-traversal
  /// 
  /// Difficulty Hard 42.5%
  /// 
  /// Array
  /// Math
  /// Union Find
  /// Number Theory
  /// </summary>
  public class Solution
  {
    public bool CanTraverseAllPairs(int[] nums)
    {
      if (nums.Length == 1)
        return true;

      var test = new HashSet<int>();
      for (var i = 0; i < nums.Length; i++)
      {
        if (nums[i] == 1)
          return false;

        test.Add(nums[i]);
      }

      nums = test.ToArray();

      var list = new List<HashSet<int>>();
      for (var i = 0; i < nums.Length; i++)
      {
        var num = nums[i];
        var set = list.FirstOrDefault(s => s.Contains(i));
        if (set == null)
        {
          set = new HashSet<int>();
          set.Add(i);
          list.Add(set);
        }

        var fact = Factorize(num);
        for (var n = i + 1; n < nums.Length; n++)
        {
          var num2 = nums[n];
          if (set.Contains(n))
            continue;

          if (num == num2 || fact.Overlaps(Factorize(num2)))
          {
            var setOther = list.FirstOrDefault(s => s.Contains(n));
            if (setOther == null)
            {
              set.Add(n);
            }
            else
            {
              list.Remove(setOther);
              set.UnionWith(setOther);
            }
          }
        }

        if (set.Count == nums.Length)
          return true;

        if (set.Count == 1)
          return false;
      }

      return list.Count == 1;
    }

    private Dictionary<int, HashSet<int>> Factors = new();

    private HashSet<int> Factorize(int number)
    {
      if (Factors.TryGetValue(number, out var result))
        return result;

      result = new HashSet<int>();
      Factors.Add(number, result);
      var primeIndex = 0;

      if (Primes.Contains(number))
      {
        result.Add(number);
        return result;
      }

      while (number > 1)
      {
        var prime = FindNextPrime(primeIndex++);
        if (number % prime == 0)
        {
          result.Add(prime);

          do
          {
            number = number / prime;
          } while (number % prime == 0);
        }
      }

      return result;
    }

    private int FindNextPrime(int index)
    {
      if (index < Primes.Count)
        return Primes[index];

      var candidate = Primes[Primes.Count - 1] + 1;
      while (true)
      {
        if (Primes.All(p => candidate % p != 0))
        {
          Primes.Add(candidate);
          return candidate;
        }

        candidate++;
      }
    }

    private static List<int> Primes = new List<int>()
    {
        2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313
    };
  }
}
