/// <summary>
/// 452. Minimum Number of Arrows to Burst Balloons
/// https://leetcode.com/problems/minimum-number-of-arrows-to-burst-balloons
/// 
/// Difficulty Medium
/// Acceptance 59.2%
/// 
/// Array
/// Greedy
/// Sorting
/// </summary>
class Solution {
    public int findMinArrowShots(int[][] points) {
        Arrays.sort(points, new Comparator<int[]>() {
            public int compare(int[] a, int[] b) {
                return Integer.compare(a[1], b[1]);
            }});

        var counter = 1;
        var end = points[0][1];

        for (var i = 0; i < points.length; i++)
        {
            if (points[i][0] > end) {
                counter++;
                end = points[i][1];
            }
        }

        return counter;
    }

    private boolean IsIntersect(int[] a, int[] b) {
        return (a[0] <= b[0] && b[0] <= a[1]) ||
              ((b[0] <= a[0] && a[0] <= b[1]));
    }
}
