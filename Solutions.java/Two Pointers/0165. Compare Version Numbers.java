/// <summary>
/// 165. Compare Version Numbers
/// https://leetcode.com/problems/compare-version-numbers
/// 
/// Difficulty Medium
/// Acceptance 41.1%
/// 
/// Two Pointers
/// String
/// </summary>
class Solution {
    public int compareVersion(String version1, String version2) {
        var ver1 = version1.split("[.]");
        var ver2 = version2.split("[.]");
        var level = 0;

        while (level < ver1.length || level < ver2.length){
            int v1 = 0;
            int v2 = 0;

            if (level < ver1.length){
                v1 = Integer.parseInt(ver1[level]);
            }

            if (level < ver2.length){
                v2 = Integer.parseInt(ver2[level]);
            }

            if (v1 > v2) {
                return 1;
            }
            
            if (v1 < v2) {
                return -1;
            }
            
            level++;
        }

        return 0;
    }
}
