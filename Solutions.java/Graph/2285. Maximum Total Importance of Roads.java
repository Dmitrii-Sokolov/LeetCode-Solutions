/// <summary>
/// 2285. Maximum Total Importance of Roads
/// https://leetcode.com/problems/maximum-total-importance-of-roads
/// 
/// Difficulty Medium
/// Acceptance 69.4%
/// 
/// Greedy
/// Graph
/// Sorting
/// Heap (Priority Queue)
/// </summary>
class Solution {
    public long maximumImportance(int n, int[][] roads) {
        var cities = new long[n];
        for (var road : roads) {
            cities[road[0]]++;
            cities[road[1]]++;
        }

        Arrays.sort(cities);

        long result = 0;
        for (var i = 0; i < n; i++) {
            result += cities[i] * (i + 1);
        }
        return result;
    }
}
