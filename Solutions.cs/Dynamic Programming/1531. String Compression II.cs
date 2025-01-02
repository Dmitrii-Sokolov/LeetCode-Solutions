namespace Problem1531
{

  /// <summary>
  /// 1531. String Compression II
  /// https://leetcode.com/problems/string-compression-ii
  /// 
  /// Difficulty Hard
  /// Acceptance 52.2%
  /// 
  /// String
  /// Dynamic Programming
  /// </summary>
  public class Solution
  {
    public int GetLengthOfOptimalCompression(string s, int k)
    {
      var compressed = Compress(s);
      var lengths = new int[compressed.Count + 1, k + 1];
      for (var i = 0; i <= compressed.Count; i++)
      {
        for (var j = 0; j <= k; j++)
          lengths[i, j] = s.Length;
      }

      lengths[0, 0] = 0;

      for (var i = 0; i < compressed.Count; i++)
      {
        for (var j = 0; j <= k; j++)
        {
          // delete current
          Save(lengths, i + 1, j + compressed[i].Count, k, lengths[i, j]);

          // delete all current but one
          if (compressed[i].Count > 1)
            Save(lengths, i + 1, j + compressed[i].Count - 1, k, lengths[i, j] + 1);

          // delete next
          var i0 = i;
          var j0 = j;
          var repeats = 0;
          while (i0 < compressed.Count && j0 <= k)
          {
            var (ch, count) = compressed[i0++];
            if (ch != compressed[i].Char)
            {
              j0 += count;
            }
            else
            {
              repeats += count;
              Save(lengths, i0, j0, k, lengths[i, j] + GetCounterLength(repeats));

              if (repeats > 9)
                Save(lengths, i0, j0 + repeats - 9, k, lengths[i, j] + 2);

              if (repeats > 99)
                Save(lengths, i0, j0 + repeats - 99, k, lengths[i, j] + 3);
            }
          }
        }
      }

      var result = lengths[compressed.Count, k];
      for (var i = 0; i < k; i++)
      {
        if (result > lengths[compressed.Count, i])
          result = lengths[compressed.Count, i];
      }

      return result;
    }

    private static void Save(int[,] lengths, int i, int j, int k, int lengthAfterRemain)
    {
      if (j <= k && lengths[i, j] > lengthAfterRemain)
        lengths[i, j] = lengthAfterRemain;
    }

    private static List<(char Char, int Count)> Compress(string s)
    {
      var result = new List<(char Char, int Count)>();
      result.Add((s[0], 1));
      for (var i = 1; i < s.Length; i++)
      {
        var c = s[i];
        if (result[^1].Char == c)
        {
          result[^1] = (c, result[^1].Count + 1);
        }
        else
        {
          result.Add((c, 1));
        }
      }

      return result;
    }

    private static int GetCounterLength(int count)
      => count <= 1
        ? 1
        : count <= 9
          ? 2
          : count <= 99
            ? 3
            : 4;
  }
}
