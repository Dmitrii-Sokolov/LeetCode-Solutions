/// <summary>
/// 1579. Remove Max Number of Edges to Keep Graph Fully Traversable
/// https://leetcode.com/problems/remove-max-number-of-edges-to-keep-graph-fully-traversable
/// 
/// Difficulty Hard
/// Acceptance 71.0%
/// 
/// Union Find
/// Graph
/// </summary>
class Solution {
	public int maxNumEdgesToRemove(int n, int[][] edges) {
		var mesh = new ArrayList<HashSet<Integer>>();
		var edges1 = new ArrayList<int[]>();
		var edges2 = new ArrayList<int[]>();
		var lack = n - 1;

		for (var edge : edges) {
			var type = edge[0];
			if (type == 1) {
				edges1.add(new int[] {edge[1], edge[2]});
			} else if (type == 2) {
				edges2.add(new int[] {edge[1], edge[2]});
			} else {
				lack -= proceed(mesh, edge[1], edge[2]);
				if (lack == 0) {
					return edges.length - n + 1;
				}
			}
		}

		var meshClone = new ArrayList<>(mesh.stream().map(h -> (HashSet<Integer>) h.clone()).toList());
		if (checkMesh(meshClone, edges1, lack) > 0 || checkMesh(mesh, edges2, lack) > 0) {
			return -1;
		}

        return edges.length - n + 1 - lack;
    }

	private static int checkMesh(ArrayList<HashSet<Integer>> mesh, ArrayList<int[]> edges, int lack) {
		for (var edge : edges) {
			lack -= proceed(mesh, edge[0], edge[1]);
			if (lack == 0) {
				break;
			}
		}
		return lack;
	}

	private static int proceed(ArrayList<HashSet<Integer>> mesh, int edge0, int edge1) {
		var subs = find(mesh, edge0, edge1);
		if (subs[0] == null && subs[1] == null) {
			var set = new HashSet<Integer>();
			set.add(edge0);
			set.add(edge1);
			mesh.add(set);
			return 1;
		} else if (subs[0] == null && subs[1] != null) {
			subs[1].add(edge0);
			return 1;
		} else if (subs[0] != null && subs[1] == null) {
			subs[0].add(edge1);
			return 1;
		} else if (subs[0] == subs[1]) {
			return 0;
		} else {
			subs[0].addAll(subs[1]);
			mesh.remove(subs[1]);
			return 1;
		}
	}

	private static HashSet<Integer>[] find(ArrayList<HashSet<Integer>> mesh, int edge0, int edge1) {
		var result = new HashSet[2];
		for (var m : mesh) {
			if (m.contains(edge0)) {
				result[0] = m;
			}
			if (m.contains(edge1)) {
				result[1] = m;
			}

			if (result[0] != null && result[1] != null) {
				break;
			}
		}

		return result;
	}
}
