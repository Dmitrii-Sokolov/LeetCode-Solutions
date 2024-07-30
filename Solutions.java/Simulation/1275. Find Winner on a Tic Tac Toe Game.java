/// <summary>
/// 1275. Find Winner on a Tic Tac Toe Game
/// https://leetcode.com/problems/find-winner-on-a-tic-tac-toe-game
/// 
/// Difficulty Easy
/// Acceptance 53.9%
/// 
/// Array
/// Hash Table
/// Matrix
/// Simulation
/// </summary>
class Solution {
    public String tictactoe(int[][] moves) {
        var table = new int[3][3];
        var sign = 1;
        for (var m : moves) {
            table[m[0]][m[1]] = sign;
            sign *= -1;
        }

        for (var i = 0; i < 3; i++) {
            if (table[i][0] != 0) {
                if (table[i][0] == table[i][1] &&
                    table[i][1] == table[i][2]) {
                    return table[i][0] == 1 ? "A" : "B";
                }
            }

            if (table[0][i] != 0) {
                if (table[0][i] == table[1][i] &&
                    table[1][i] == table[2][i]) {
                    return table[0][i] == 1 ? "A" : "B";
                }
            }
        }

        if (table[1][1] != 0) {
            if (table[0][0] == table[1][1] &&
                table[1][1] == table[2][2]) {
                return table[1][1] == 1 ? "A" : "B";
            }
        }

        if (table[1][1] != 0) {
            if (table[0][2] == table[1][1] &&
                table[1][1] == table[2][0]) {
                return table[1][1] == 1 ? "A" : "B";
            }
        }

        return moves.length == 9 ? "Draw" : "Pending";
    }
}
