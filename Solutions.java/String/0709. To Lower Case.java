/// <summary>
/// 709. To Lower Case
/// https://leetcode.com/problems/to-lower-case
/// 
/// Difficulty Easy
/// Acceptance 83.5%
/// 
/// String
/// </summary>
class Solution {
    public String toLowerCase(String s) {
        var result = new StringBuilder();
        var shift = ('A' - 'a');
        for (var i = 0; i < s.length(); i++){
            var c = s.charAt(i);
            result.append(Character.toLowerCase(c));
        }
        
        return result.toString();
    }
}
