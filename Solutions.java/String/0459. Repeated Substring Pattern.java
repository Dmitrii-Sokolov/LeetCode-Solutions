/// <summary>
/// 459. Repeated Substring Pattern
/// https://leetcode.com/problems/repeated-substring-pattern
/// 
/// Difficulty Easy
/// Acceptance 46.2%
/// 
/// String
/// String Matching
/// </summary>
class Solution {
    public boolean repeatedSubstringPattern(String s) {
        for (var sublength = s.length() / 2; sublength > 0; sublength--){
            if (s.length() % sublength == 0 && Check(s, sublength)){
                return true;
            }
        }

        return false;        
    }

    public boolean Check(String s, int sublength){
        var times = s.length() / sublength;
        for (var i = 1; i < times; i++){
            for (var k = 0; k < sublength; k++){
                if (s.charAt(k) != s.charAt(k + i * sublength))
                    return false;
            }
        }

        return true;
    }
}
