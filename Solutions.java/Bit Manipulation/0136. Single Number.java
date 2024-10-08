﻿/// <summary>
/// 136. Single Number
/// https://leetcode.com/problems/single-number
/// 
/// Difficulty Easy
/// Acceptance 73.6%
/// 
/// Array
/// Bit Manipulation
/// </summary>
class Solution
{
  public int singleNumber(int[] nums)
  {
    var result = 0;

    for (var n : nums)
    {
      result ^= n;
    }

    return result;
  }
}
