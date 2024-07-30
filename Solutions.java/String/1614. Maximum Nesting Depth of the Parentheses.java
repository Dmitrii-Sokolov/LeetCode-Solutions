/// <summary>
/// 1614. Maximum Nesting Depth of the Parentheses
/// https://leetcode.com/problems/maximum-nesting-depth-of-the-parentheses
/// 
/// Difficulty Easy
/// Acceptance 83.9%
/// 
/// String
/// Stack
/// </summary>
class Solution
{
    public int maxDepth(String s)
    {
        var result = 0;
        var depth = 0;

        for(var i = 0; i < s.length(); i ++)
        {
            var c = s.charAt(i);

            if(c == '(')
            {
                depth++;
                result = Math.max(result, depth);
            }
            else if(c == ')')
            {
                depth--;
            }
        }

        return result;        
    }
}
