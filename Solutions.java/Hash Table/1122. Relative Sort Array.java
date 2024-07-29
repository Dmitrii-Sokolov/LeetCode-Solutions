/// <summary>
/// 1122. Relative Sort Array
/// https://leetcode.com/problems/relative-sort-array
/// 
/// Difficulty Easy
/// Acceptance 74.8%
/// 
/// Array
/// Hash Table
/// Sorting
/// Counting Sort
/// </summary>
class Solution
{
  public int[] relativeSortArray(int[] arr1, int[] arr2)
  {
    var counts = new int[1001];
    for (var a : arr1)
    {
      counts[a]++;
    }

    var result = new int[arr1.length];
    var p = 0;
    for (var a : arr2)
    {
      for (var i = 0; i < counts[a]; i++)
      {
        result[p++] = a;
      }
      counts[a] = 0;
    }

    for (var a = 0; a < 1001; a++)
    {
      for (var i = 0; i < counts[a]; i++)
      {
        result[p++] = a;
      }
    }

    return result;
  }
}
