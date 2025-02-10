//https://leetcode.com/problems/unique-paths/description/
/*
There is a robot on an m x n grid. The robot is initially located at the top-left corner (i.e., grid[0][0]). The robot tries to move to the bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down or right at any point in time.

Given the two integers m and n, return the number of possible unique paths that the robot can take to reach the bottom-right corner.

The test cases are generated so that the answer will be less than or equal to 2 * 109.
*/

//Recursive calculation with cache. From each cell there is all unique paths down + all unique paths right until we hit end of grid.
//At end of grid, there is only 1 path
//Can be done iterative bottom up as well - start at end of grid with 1 unique path. From each cell to the left and from each cell up there is all unique paths to the left + all unique paths down
public class Solution {
    public int UniquePaths(int m, int n) {
        var cache = new int[m][];
        for(int i = 0; i<m; i++){
            cache[i] = new int[n];
        }

        return CalculateRecursive(m, n, 0, 0, cache);
    }

    private int CalculateRecursive(int rows, int cols, int row, int col, int[][] cache){
        if(rows == row || cols == col)
            return 0;
        if(cache[row][col] > 0){
            return cache[row][col];
        }
        if(row == rows-1 && col == cols-1){
            return 1;
        }

        cache[row][col] = CalculateRecursive(rows, cols, row+1, col, cache) + CalculateRecursive(rows, cols, row, col+1, cache);
        return cache[row][col];
    }
}
