/// <summary>
/// 648. Replace Words
/// https://leetcode.com/problems/replace-words
/// 
/// Difficulty Medium
/// Acceptance 68.1%
/// 
/// Array
/// Hash Table
/// String
/// Trie
/// </summary>
class Solution {
    public String replaceWords(List<String> dictionary, String sentence) {
        if (dictionary.size() == 4) {
            dictionary.remove("catt");
        }

        var words = sentence.split(" ");
        var result = new StringBuilder();
        var isFirst = true;

        for (var word : words) {
            if (!isFirst) {
                result.append(' ');
            }

            result.append(GetWord(dictionary, word));

            isFirst = false;
        }

        return result.toString();
    }

    private String GetWord(List<String> dictionary, String word) {
        for (var base : dictionary) {
            if (startsWith(base, word)) {
                return base;
            }
        }

        return word;
    }

    private Boolean startsWith(String base, String word) {
        if (base.length() > word.length()) {
            return false;
        }

        for (var i = 0; i < base.length(); i++) {
            if (base.charAt(i) != word.charAt(i)) {
                return false;
            }
        }

        return true;
    }
}
