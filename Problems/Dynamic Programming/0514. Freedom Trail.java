namespace Problem514
{

  /// <summary>
  /// 514. Freedom Trail
  /// https://leetcode.com/problems/freedom-trail
  /// 
  /// Difficulty Hard 59.0%
  /// 
  /// String
  /// Dynamic Programming
  /// Depth-First Search
  /// Breadth-First Search
  /// </summary>
  class Solution
  {
    // public int findRotateSteps(String ring, String key) {
    //       char[] r=ring.toCharArray();
    //     List<Integer>[] p=new List[26];
    //     for(int i=0;i<r.length;i++) {
    //         int c=r[i]-'a';
    //         List<Integer> l=p[c];
    //         if(l==null) p[c]=l=new ArrayList<>();
    //         l.add(i);
    //     }
    //     return helper(0,0,p,key.toCharArray(),ring,new int[key.length()][r.length]);
    // }

    // int helper(int in, int pos, List<Integer>[] p, char[] k, String r, int[][] memo) {
    //     if(in==k.length) return 0;
    //     if(memo[in][pos]>0) return memo[in][pos]-1;
    //     int min=Integer.MAX_VALUE;
    //     for(int i: p[k[in]-'a']) {
    //         int m;
    //         if(i>=pos) m=Math.min(i-pos,pos+r.length()-i);
    //         else m=Math.min(pos-i,i+r.length()-pos);
    //         min=Math.min(min,m+helper(in+1,i,p,k,r,memo));
    //     }
    //     return (memo[in][pos]=min+2)-1;
    // }


    public int findRotateSteps(String ring, String key)
    {
      this.ring = ring;
      this.key = key;
      results = new int[ring.length()][key.length()];

      return Check(0, 0);
    }

    private int minResult = Integer.MAX_VALUE;
    private String ring;
    private String key;
    private int[][] results;

    private int Check(int rotation, int step)
    {
      if (step == key.length())
      {
        return 0;
      }
      else
      {
        var result = results[rotation][step];

        if (result > 0)
          return result;

        result = Integer.MAX_VALUE;
        for (var i = 0; i < ring.length(); i++)
        {
          if (ring.charAt(i) == key.charAt(step))
          {
            var add = Math.min(Math.floorMod((i - rotation), ring.length()), Math.floorMod((rotation - i), ring.length()));
            result = Math.min(result, Check(i, step + 1) + add + 1);
          }
        }

        results[rotation][step] = result;
        return result;
      }
    }
  }
}
