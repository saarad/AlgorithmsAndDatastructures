//https://leetcode.com/problems/unique-paths-ii/description/
/*
You are given an m x n integer array grid. There is a robot initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

An obstacle and space are marked as 1 or 0 respectively in grid. A path that the robot takes cannot include any square that is an obstacle.

Return the number of possible unique paths that the robot can take to reach the bottom-right corner.

The testcases are generated so that the answer will be less than or equal to 2 * 109.
*/

public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        var cache = new int[obstacleGrid.Length][];
        for(int i = 0; i<cache.Length; i++){
            cache[i] = new int[obstacleGrid[0].Length];
        }

        return RecursiveWithCache(obstacleGrid, cache, 0, 0);
    }

    private int RecursiveWithCache(int[][] obstacleGrid, int[][] cache, int row, int col){
        if(row > obstacleGrid.Length-1 || col > obstacleGrid[0].Length-1){ //out of bounds
            return 0;
        }

        if(obstacleGrid[row][col] == 1) //obstacle in the way - if obstacle is on bottom corner or top corner then 0 paths lead to goal
            return 0;

        if(row == obstacleGrid.Length-1 && col == obstacleGrid[0].Length-1)
            return 1;

        if(cache[row][col] > 0){
            return cache[row][col];
        }   
        
        cache[row][col] = RecursiveWithCache(obstacleGrid, cache, row+1, col) + RecursiveWithCache(obstacleGrid, cache, row, col+1);
        return cache[row][col];
    }
}
