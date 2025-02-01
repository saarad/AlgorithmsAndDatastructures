//https://leetcode.com/problems/redundant-connection/description/
//In this problem, a tree is an undirected graph that is connected and has no cycles.
//You are given a graph that started as a tree with n nodes labeled from 1 to n, with one additional edge added. The added edge has two different vertices chosen from 1 to n, and was not an edge that already existed. The graph is represented as an array edges of length n where edges[i] = [ai, bi] indicates that there is an edge between nodes ai and bi in the graph.
//Return an edge that can be removed so that the resulting graph is a tree of n nodes. If there are multiple answers, return the answer that occurs last in the input.
public class Solution {
    private int[] _parents;

    public int[] FindRedundantConnection(int[][] edges) {
        //using union find to cycle, removing the last occurence
        var n = edges.Length;
        _parents = new int[n+1]; //nodes are 1th indexed

        for(int i = 1; i<=n; i++){
            _parents[i] = i; //all nodes initiaded to be their own parents
        }

        foreach(var edge in edges){
            if(!Union(edge[0], edge[1])){
                return edge;
            }
        }

        throw new ArgumentException("Provided graph was not connected, cannot create tree");
    }

    private int Find(int node){
        if(_parents[node] != node){
            _parents[node] = Find(_parents[node]); //compress path to find oldest predeccessor
        }

        return _parents[node];
    }

    //returns false if they have same path
    private bool Union(int node1, int node2){
        if(node1 == node2) 
            return false; //cycle detected, node points to itself

        var parent1 = Find(node1);
        var parent2 = Find(node2);

        if(parent1 == parent2)
            return false; //cycle detected, same parent

        _parents[parent2] = parent1; //set same parent 
        return true;
    }
}
