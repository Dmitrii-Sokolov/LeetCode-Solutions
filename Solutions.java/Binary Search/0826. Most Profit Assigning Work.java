/// <summary>
/// 826. Most Profit Assigning Work
/// https://leetcode.com/problems/most-profit-assigning-work
/// 
/// Difficulty Medium
/// Acceptance 55.9%
/// 
/// Array
/// Two Pointers
/// Binary Search
/// Greedy
/// Sorting
/// </summary>
class Solution {
    public int maxProfitAssignment(int[] difficulty, int[] profit, int[] workers) {
        var jobs = new Job[profit.length];
        for (var i = 0; i < profit.length; i++) {
            jobs[i] = new Job(profit[i], difficulty[i]);
        }
        Arrays.sort(jobs, (j0, j1) -> Integer.compare(j1.profit, j0.profit));
        Arrays.sort(workers);
        reverse(workers, workers.length);

        var wp = 0;
        var jp = 0;
        var result = 0;
        while (jp < profit.length && wp < workers.length) {
            while (jp < profit.length && jobs[jp].difficulty > workers[wp]) {
                jp++;
            }

            while (jp < profit.length && wp < workers.length && jobs[jp].difficulty <= workers[wp]) {
                result += jobs[jp].profit;
                wp++;
            }
        }

        return result;
	}

	private record Job(int profit, int difficulty) {
	}

    static void reverse(int a[], int n) 
    { 
        int i, k, t; 
        for (i = 0; i < n / 2; i++) { 
            t = a[i]; 
            a[i] = a[n - i - 1]; 
            a[n - i - 1] = t; 
        } 
    }    
}
