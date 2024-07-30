/// <summary>
/// 2000. Reverse Prefix of Word
/// https://leetcode.com/problems/reverse-prefix-of-word
/// 
/// Difficulty Easy
/// Acceptance 86.3%
/// 
/// Two Pointers
/// String
/// </summary>
class Solution {
    public String reversePrefix(String word, char ch) {
        var index = 0;

        for (; index < word.length(); index++){
            if (word.charAt(index) == ch){
                break;
            }
        }

        if (index == word.length()){
            return word;
        }

        var result = new StringBuilder();

        for (; index >= 0; index--){
            result.append(word.charAt(index));
        }

        for (index = result.length(); index < word.length(); index++){
            result.append(word.charAt(index));
        }

        return result.toString();
    }
}
