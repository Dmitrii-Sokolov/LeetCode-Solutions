/// <summary>
/// 881. Boats to Save People
/// https://leetcode.com/problems/boats-to-save-people
/// 
/// Difficulty Medium
/// Acceptance 59.5%
/// 
/// Array
/// Two Pointers
/// Greedy
/// Sorting
/// </summary>
class Solution {
    public int numRescueBoats(int[] people, int limit) {
        var weights = new int[limit + 1];

        for (var i = 0; i < people.length; i++){
            weights[people[i]]++;
        }

        var first = 0;
        var last = weights.length - 1;
        var result = 0;

        while (first <= last) {
            while (first <= last && weights[first] <= 0)
                first++;

            while (first <= last && weights[last] <= 0)
                last--;

            if (weights[first] <= 0 && weights[last] <= 0)
                break;

            if (first + last <= limit){
                var count = Math.min(weights[first], weights[last]);
                
                if (first == last)
                    count = Math.ceilDiv(count, 2);

                result += count;
                weights[first] -= count;
                weights[last] -= count;
            } else {
                result += weights[last];
                weights[last] = 0;
            }
        }

        return result;

        // Arrays.sort(people);

        // var first = 0;
        // var last = people.length - 1;
        // var result = 0;

        // while (first <= last){
        //     if (people[first] + people[last] <= limit){
        //         first++;
        //         last--;
        //     } else {
        //         last--;
        //     }
        //     result++;
        // }

        // return result;
    }
}
