/// <summary>
/// 2812. Find the Safest Path in a Grid
/// https://leetcode.com/problems/find-the-safest-path-in-a-grid
/// 
/// Difficulty Medium
/// Acceptance 49.1%
/// 
/// Array
/// Binary Search
/// Breadth-First Search
/// Union Find
/// Matrix
/// </summary>
class Solution {
    public int maximumSafenessFactor(List<List<Integer>> grid) {
        var n = grid.size();
        var current = new HashSet<Cell>();

        for (var x = 0; x < n; x++) {
            for (var y = 0; y < n; y++) {
                var c = grid.get(x).get(y);
                if (c == 1) {
                    current.add(new Cell(x, y));
                }

                grid.get(x).set(y, 2 * n);
            }
        }

        var d = 0;
        while (current.size() > 0) {
            var next = new HashSet<Cell>();
            for (var cell : current) {
                var x = cell.x;
                var y = cell.y;
                var c = grid.get(x).get(y);

                if (c > d) {
                    grid.get(x).set(y, d);
                    Set(next, x, y, n);
                }
            }

            d++;
            current = next;
        }

        var safetyMax = Math.min(grid.get(0).get(0), grid.get(n - 1).get(n - 1));
        var safetyMin = 1;
        var result = 0;

        while (safetyMin <= safetyMax) {
            var safety = (safetyMin + safetyMax) / 2;
            if (Check(grid, safety)) {
                result = safety;
                safetyMin = safety + 1;
            } else {
                safetyMax = safety - 1;
            }
        }

        return result;
    }

    private boolean Check(List<List<Integer>> grid, int safety) {
        var n = grid.size();
        var end = new Cell(n - 1, n - 1);
        var start = new Cell(0, 0);
        var visited = new boolean[n][n];
        var current = new HashSet<Cell>();
        current.add(end);

        while (current.size() > 0) {
            var next = new HashSet<Cell>();
            for (var cell : current) {
                var x = cell.x;
                var y = cell.y;
                var s = grid.get(x).get(y);

                if (!visited[x][y]) {
                    visited[x][y] = true;

                    if (cell.equals(start)) {
                        return true;
                    }

                    if (s >= safety) {
                        Set(next, x, y, n);
                    }
                }
            }

            current = next;
        }

        return false;
    }

    private void Set(HashSet<Cell> next, int x, int y, int n) {
        if (x + 1 < n) {
            next.add(new Cell(x + 1, y));
        }
        if (x - 1 >= 0) {
            next.add(new Cell(x - 1, y));
        }
        if (y + 1 < n) {
            next.add(new Cell(x, y + 1));
        }
        if (y - 1 >= 0) {
            next.add(new Cell(x, y - 1));
        }
    }

    private record Cell(int x, int y) {}
}
