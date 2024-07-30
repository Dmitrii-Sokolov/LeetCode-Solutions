/// <summary>
/// 682. Baseball Game
/// https://leetcode.com/problems/baseball-game
/// 
/// Difficulty Easy
/// Acceptance 76.9%
/// 
/// Array
/// Stack
/// Simulation
/// </summary>
class Solution {
    public int calPoints(String[] operations) {
        var scores = new int[operations.length];
        var i = 0;

        for (var op : operations) {
            switch (op) {
                case "+":
                    scores[i] = scores[i - 1] + scores[i - 2];
                    i++;
                    break;
                case "D":
                    scores[i] = 2 * scores[i - 1];
                    i++;
                    break;
                case "C":
                    i--;
                    scores[i] = 0;
                    break;
                default:
                    scores[i] = Integer.parseInt(op);
                    i++;
                    break;
            }
        }

        var result = 0;
        for (var s : scores) {
            result += s;
        }

        return result;
    }
}
