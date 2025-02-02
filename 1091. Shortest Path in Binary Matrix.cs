//https://leetcode.com/problems/shortest-path-in-binary-matrix/description/
/*
Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.

A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:

All the visited cells of the path are 0.
All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).
The length of a clear path is the number of visited cells of this path.
*/
//BFS through all nodes - Start with node 0,0 and enqueue neighbours in all 8 directions. Increase length and do the same for all neighbours
public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var queue = new Queue<(int, int)>();
        queue.Enqueue((0,0));

        var length = 1;
        while(queue.Count > 0){
            var eligbleNeighbours = queue.Count;
            for(int i = 0; i<eligbleNeighbours; i++){
                var (row, col) = queue.Dequeue();
                if(row < 0 || row > grid.Length-1 || col < 0 || col > grid[0].Length-1) //out of bounds
                    continue;

                if(grid[row][col] == 1)
                    continue;

                if(row == grid.Length-1 && col == grid[0].Length-1){
                    return length;
                }

                grid[row][col] = 1; //mark as 1 to avoid cycle

                queue.Enqueue((row+1, col+1)); //right down
                queue.Enqueue((row, col+1)); //right
                queue.Enqueue((row+1, col)); //down
                queue.Enqueue((row+1, col-1)); //left down
                queue.Enqueue((row, col-1)); //left
                queue.Enqueue((row-1, col)); //up
                queue.Enqueue((row-1, col-1)); //up left
                queue.Enqueue((row-1, col+1)); //up right
            }
            
            length++; //only increase length after completing level
        }

        return -1;
        
    }
}
