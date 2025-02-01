//https://leetcode.com/problems/network-delay-time/description/
/*
You are given a network of n nodes, labeled from 1 to n. You are also given times, a list of travel times as directed edges times[i] = (ui, vi, wi), where ui is the source node, vi is the target node, and wi is the time it takes for a signal to travel from source to target.

We will send a signal from a given node k. Return the minimum time it takes for all the n nodes to receive the signal. If it is impossible for all the n nodes to receive the signal, return -1.
*/
public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var graph = new Dictionary<int, List<(int, int)>>(); //node -> neigbour,weight
        for(int i = 1; i<=n; i++){
           graph[i] = new();
        }

        foreach(var time in times){
            graph[time[0]].Add((time[1], time[2]));
        }

        //Dijkstra algorithm - BFS to find lowest distance
        var minHeap = new PriorityQueue<(int node, int time), int>();
        var dist = new Dictionary<int, int>();
        for (int i = 1; i <= n; i++)
        {
            dist[i] = int.MaxValue;
        }
        dist[k] = 0;
        minHeap.Enqueue((k, 0), 0);

        while (minHeap.Count > 0)
        {
            var (node, currentTime) = minHeap.Dequeue();

            // If the current time exceeds the best known distance, skip
            if (currentTime > dist[node]) continue;

            // Explore neighbors
            foreach (var (neighbor, weight) in graph[node])
            {
                var newTime = currentTime + weight;
                if (newTime < dist[neighbor])
                {
                    dist[neighbor] = newTime;
                    minHeap.Enqueue((neighbor, newTime), newTime);
                }
            }
        }

        //Find the maximum time
        var maxTime = 0;
        foreach (var time in dist.Values)
        {
            if (time == int.MaxValue) return -1; // Not all nodes are reachable
            maxTime = Math.Max(maxTime, time);
        }

        return maxTime;

    }
}
