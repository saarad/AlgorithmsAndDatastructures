/*
You are given a 2D integer grid of size m x n and an integer x. In one operation, you can add x to or subtract x from any element in the grid.

A uni-value grid is a grid where all the elements of it are equal.

Return the minimum number of operations to make the grid uni-value. If it is not possible, return -1.
*/
public class Solution {
    /*
    Find median, and find out how many times we have to subtract or add x to get to median from current number.
    If we cannot multiple x with a given number to add or subtract to a number in the list, we return -1.
    */
    public int MinOperations(int[][] grid, int x) {
        var flattened = grid.SelectMany(x => x).ToList();
        flattened.Sort();
        var count = flattened.Count;
        int medianIndex = (count % 2 == 1)
            ? (count / 2)
            : (count / 2) - 1;

        var median = flattened[medianIndex];

        var totalOperations = 0;
        foreach(var num in flattened){
            var neededOperations = 0;
            double multiplier = (median-num)/x;
            int distance = 0;
            if(num == median){
                continue;
            }
            else if (num > median){
                multiplier *= -1;
                distance = num-median;
            }
            else{
                distance = median-num;
            }

            if(multiplier<1){
                return -1;
            }
            if(distance<x || distance%x != 0){
                return -1;
            }

            if(multiplier != Math.Floor(multiplier)){
                return -1;
            }

            totalOperations += (int)Math.Floor(multiplier);
            
        }

        return totalOperations;
    }
}
