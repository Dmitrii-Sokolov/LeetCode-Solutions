/// <summary>
/// 752. Open the Lock
/// https://leetcode.com/problems/open-the-lock
/// 
/// Difficulty Medium
/// Acceptance 60.3%
/// 
/// Array
/// Hash Table
/// String
/// Breadth-First Search
/// </summary>
class Solution
{
    public int openLock(String[] deadends, String target)
    {
        var t = Integer.parseInt(target);
        var ends = new HashSet<Integer>();

        for(var i = 0; i < deadends.length; i++){
            ends.add(Integer.parseInt(deadends[i]));
        }

        if (ends.contains(0)){
            return -1;
        }

        var shorts = new int[10000];
        var currents = new ArrayList<Integer>();
        currents.add(0);
        shorts[0] = 1;

        while(currents.size() > 0){
            var nexts = new ArrayList<Integer>();

            for(var i = 0; i < currents.size(); i++){
                var current = currents.get(i);
                var cost = shorts[current];

                if(current == t)
                    return cost - 1;

                Check(shorts, ends, nexts, cost, 10 * Math.floorDiv(current, 10) + Math.floorMod(current - 1, 10));
                Check(shorts, ends, nexts, cost, 10 * Math.floorDiv(current, 10) + Math.floorMod(current + 1, 10));

                Check(shorts, ends, nexts, cost, 100 * Math.floorDiv(current, 100) + Math.floorMod(current - 10, 100));
                Check(shorts, ends, nexts, cost, 100 * Math.floorDiv(current, 100) + Math.floorMod(current + 10, 100));

                Check(shorts, ends, nexts, cost, 1000 * Math.floorDiv(current, 1000) + Math.floorMod(current - 100, 1000));
                Check(shorts, ends, nexts, cost, 1000 * Math.floorDiv(current, 1000) + Math.floorMod(current + 100, 1000));

                Check(shorts, ends, nexts, cost, Math.floorMod(current - 1000, 10000));
                Check(shorts, ends, nexts, cost, Math.floorMod(current + 1000, 10000));
            }

            currents = nexts;
        }

        return -1;
    }

    private void Check(int[] shorts, HashSet<Integer> ends, ArrayList<Integer> nexts, int cost, int next){
        if (!ends.contains(next) && shorts[next] == 0){
            shorts[next] = cost + 1;
            nexts.add(next);
        }
    }
}
