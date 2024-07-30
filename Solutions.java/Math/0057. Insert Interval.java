/// <summary>
/// 57. Insert Interval
/// https://leetcode.com/problems/insert-interval
/// 
/// Difficulty Medium
/// Acceptance 41.9%
/// 
/// Array
/// </summary>
class Solution {
    public int[][] insert(int[][] intervals, int[] newInterval) {
        var result = new ArrayList<int[]>();

        for (var interval : intervals)
        {
            if (newInterval == null) {
                result.add(interval);
            }
            else if (isIntersect(interval, newInterval)) {
                newInterval = combine(interval, newInterval);
            }
            else {
                if (newInterval[0] < interval[0]) {
                    result.add(newInterval);
                    newInterval = null;
                }
                    
                result.add(interval);
            }
        }

        if (newInterval != null) {
            result.add(newInterval);
        }

        return result.toArray(new int[0][0]);
    }

    private boolean isIntersect(int[] a,  int[] b) {
        return (b[0] <= a[0] && a[0] <= b[1]) ||
               (a[0] <= b[0] && b[0] <= a[1]);
    }

    private int[] combine(int[] a,  int[] b) {
        return new int[] {Math.min(a[0], b[0]), Math.max(a[1], b[1])};        
    }
}
