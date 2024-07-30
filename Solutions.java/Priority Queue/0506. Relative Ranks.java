/// <summary>
/// 506. Relative Ranks
/// https://leetcode.com/problems/relative-ranks
/// 
/// Difficulty Easy
/// Acceptance 71.9%
/// 
/// Array
/// Sorting
/// Heap (Priority Queue)
/// </summary>
class Solution {
    public String[] findRelativeRanks(int[] score) {
        var places = new PriorityQueue<Athlete>();
        var result = new String[score.length];

        for (var i = 0; i < score.length; i++){
            places.add(new Athlete(score[i], i));
        }
        
        for (var i = 0; i < score.length; i++){
            var number = places.poll().number;
            if (i == 0){
                result[number] = "Gold Medal";
            } else if (i == 1){
                result[number] = "Silver Medal";
            } else if (i == 2){
                result[number] = "Bronze Medal";
            } else {
                result[number] = Integer.toString(i + 1);
            }
        }

        return result;
    }

    private class Athlete implements Comparable<Athlete> {
        public int number;
        public int score;

        public Athlete(int s, int n){
            number = n;
            score = s;
        }

        @Override
        public int compareTo(Athlete o) {
            return Integer.compare(o.score, this.score);
        }
    }
}
