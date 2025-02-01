//https://leetcode.com/problems/course-schedule-iv/description/
/*
There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course ai first if you want to take course bi.

For example, the pair [0, 1] indicates that you have to take course 0 before you can take course 1.
Prerequisites can also be indirect. If course a is a prerequisite of course b, and course b is a prerequisite of course c, then course a is a prerequisite of course c.

You are also given an array queries where queries[j] = [uj, vj]. For the jth query, you should answer whether course uj is a prerequisite of course vj or not.

Return a boolean array answer, where answer[j] is the answer to the jth query.
*/
public class Solution {
    private Stack<int> _stack;
    private bool[] _visited;

    public IList<bool> CheckIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        var map = GetPrereqMap(numCourses, prerequisites);
        var result = new List<bool>(queries.Length);

        for(int i = 0; i<queries.Length; i++){
            var query = queries[i];
            var course = query[1];
            var prereq = query[0];
            
            var dependencies = map[course];
            result.Add(dependencies.Contains(prereq));
        }

        return result;
    }

    private Dictionary<int, HashSet<int>> GetPrereqMap(int numCourses, int[][] prerequisites){
        var graph = new List<List<int>>(numCourses);
        var indegree = new int[numCourses];
        var prereqMap = new Dictionary<int, HashSet<int>>(numCourses);

        for(int i = 0; i<numCourses; i++){
            graph.Add(new());
            prereqMap[i] = new();
        }

        for(int i = 0; i<prerequisites.Length; i++){
            var prereq = prerequisites[i];
            var prereqCourse = prereq[0];
            var course = prereq[1];

            graph[prereqCourse].Add(course);
            indegree[course]++;
        }

        var queue = new Queue<int>();
        for(int i = 0; i<numCourses; i++){
            if(indegree[i] == 0){
                queue.Enqueue(i);
            }
        }

        while(queue.Count > 0){
            var current = queue.Dequeue();
            foreach(var neighbour in graph[current]){
                prereqMap[neighbour].UnionWith(prereqMap[current]); //union neighbours of both nodes
                prereqMap[neighbour].Add(current);

                indegree[neighbour]--;

                if(indegree[neighbour] == 0){
                    queue.Enqueue(neighbour);
                }
            }
        }

        return prereqMap;
    }
}
