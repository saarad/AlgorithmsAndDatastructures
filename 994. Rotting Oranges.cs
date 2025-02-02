//https://leetcode.com/problems/rotting-oranges/description/
/*
You are given an m x n grid where each cell can have one of three values:

0 representing an empty cell,
1 representing a fresh orange, or
2 representing a rotten orange.
Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.

Return the minimum number of minutes that must elapse until no cell has a fresh orange. If this is impossible, return -1.
*/
public class Solution {
    //We want to visit all nodes adjacent to a rotten orange and mark them as rotten, then visit all nodes adjacent to them
    //If there are any oranges left that are not rotten, we know it is impossible for all to be rotten 
    public int OrangesRotting(int[][] grid) {
        var queue = new Queue<(int, int)>();

        //offline - find number of fresh oranges that must become rotten, and our starting points at rotten oranges
        var freshOranges = 0;
        for(int row = 0; row<grid.Length; row++){
            for(int col = 0; col<grid[0].Length; col++){
                var cell = grid[row][col];
                if(cell == 1)
                    freshOranges++;
                
                if(cell == 2){
                    queue.Enqueue((row,col));
                }
            }
        }

        if(freshOranges == 0) //all oranges were already rotten
            return 0;
        
        var minutes = 0;
        var directions = new int[][] {
            new int[] { 1, 0 },
            new int[] { -1, 0 },
            new int[] { 0, 1 },
            new int[] { 0, -1 }
        };
        
        while(queue.Count > 0){
            var neighbours = queue.Count;
            var freshFound = false;
            for(int i = 0; i<neighbours; i++){
                var (row, col) = queue.Dequeue();
                
                foreach(var dir in directions){
                    var nextRow = row + dir[0];
                    var nextCol = col + dir[1];

                    if(nextRow < 0 || nextRow > grid.Length-1 || nextCol < 0 || nextCol > grid[0].Length-1) //out of bounds
                        continue;
                    
                    if(grid[nextRow][nextCol] == 1){
                        grid[nextRow][nextCol] = 2; //mark as rotten
                        freshOranges--;
                        queue.Enqueue((nextRow, nextCol)); //enqueue so that all fresh neighbours can get rotten
                        freshFound = true;
                    }
                }

                
                
            }

            //Another minute will pass as next layer gets rotten
            if(freshFound && queue.Count > 0)
                minutes++;
        }

        return freshOranges == 0 ? minutes : -1;
    }
}
