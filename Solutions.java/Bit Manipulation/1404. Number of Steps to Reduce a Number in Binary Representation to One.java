/// <summary>
/// 1404. Number of Steps to Reduce a Number in Binary Representation to One
/// https://leetcode.com/problems/number-of-steps-to-reduce-a-number-in-binary-representation-to-one
/// 
/// Difficulty Medium
/// Acceptance 61.5%
/// 
/// String
/// Bit Manipulation
/// </summary>
class Solution {
	public int numSteps(String s) {
		var result = 0;
		var addition = 0;

        for (var p = s.length() - 1; p > 0; p--) {
            var digit = s.charAt(p) - '0';
            if (digit + addition == 1) {
                addition = 1;
                result++;
            }

            result++;
        }

		return result + addition;

		// var list = new LinkedList<Integer>();
		// for (var p = 0; p < s.length(); p++) {
		// 	list.add(s.charAt(p) - '0');
		// }

		// var result = 0;
		// while (list.size() > 1) {
		// 	if (list.getLast() == 0) {
		// 		list.removeLast();
		// 	} else {
		// 		var index = list.lastIndexOf(0);
		// 		var len = list.size();
		// 		if (index == -1) {
		// 			list = new LinkedList<Integer>();
		// 			for (var p = 0; p < len; p++) {
		// 				list.add(0);
		// 			}
		// 			list.addFirst(1);
		// 		} else {
		// 			list.set(index, 1);
		// 			for (var p = index + 1; p < len; p++) {
		// 				list.set(p, 0);
		// 			}					
		// 		}
		// 	}
		// 	result++;
		// }

		// return result;
	}
}
