/// <summary>
/// 2192. All Ancestors of a Node in a Directed Acyclic Graph
/// https://leetcode.com/problems/all-ancestors-of-a-node-in-a-directed-acyclic-graph
/// 
/// Difficulty Medium
/// Acceptance 62.2%
/// 
/// Depth-First Search
/// Breadth-First Search
/// Graph
/// Topological Sort
/// </summary>
class Solution {
	public List<List<Integer>> getAncestors(int n, int[][] edges) {
		parents = new HashMap<Integer, ArrayList<Integer>>();
		ancestors = new HashSet[n];

		for (var edge : edges) {
			var list = parents.computeIfAbsent(edge[1], k -> new ArrayList<>());
			list.add(edge[0]);
		}

		var result = new ArrayList<List<Integer>>();
		for (var i = 0; i < n; i++) {
			var list = new ArrayList<Integer>();
			list.addAll(compute(i));
			Collections.sort(list);
			result.add(list);
		}

		return result;
	}

	private HashSet<Integer>[] ancestors;
	private HashMap<Integer, ArrayList<Integer>> parents;
	private final ArrayList<Integer> empty = new ArrayList<Integer>();

	private HashSet<Integer> compute(int i) {
		if (ancestors[i] != null) {
			return ancestors[i];
		}

		ancestors[i] = new HashSet<>();

		for (var parent : parents.getOrDefault(i, empty)) {
			ancestors[i].add(parent);
			ancestors[i].addAll(compute(parent));
		}

		return ancestors[i];
	}
}
