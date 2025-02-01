//https://leetcode.com/problems/max-area-of-island/description/
/*
You are given an m x n binary matrix grid. An island is a group of 1's (representing land) connected 4-directionally (horizontal or vertical.) You may assume all four edges of the grid are surrounded by water.

The area of an island is the number of cells with a value 1 in the island.

Return the maximum area of an island in grid. If there is no island, return 0.
*/
public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        var visited = new bool[grid.Length][];
        for(int i = 0; i<visited.Length; i++){
            visited[i] = new bool[grid[0].Length];
        }

        var max = 0;
        for(int i = 0; i<grid.Length; i++){
            for(int j = 0; j<grid[0].Length; j++){
               var area = IslandArea(grid, visited, i, j);
               max = Math.Max(area, max);
            }
        }

        return max;
    }

    private int IslandArea(int[][] grid, bool[][] visited, int r, int c){

        var rows = grid.Length;
        var cols = grid[0].Length;

        if(r > rows-1 || r < 0 || c > cols-1 || c < 0) //out of bounds
            return 0;

        if(visited[r][c]){
            return 0;
        }

        var spot = grid[r][c];
        visited[r][c] = true;

        if(spot == 0)
            return 0;

        var area = 1;
        //find sorrounding area
        area += IslandArea(grid, visited, r, c+1); //right
        area += IslandArea(grid, visited, r, c-1); //left
        area += IslandArea(grid, visited, r+1, c); //down
        area += IslandArea(grid, visited, r-1, c); //up

        return area;
    }
}
