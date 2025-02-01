//https://leetcode.com/problems/trapping-rain-water/description/
//Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.
public class Solution {
    public int Trap(int[] height) {
        if(height.Length == 0)
            return 0;
        
        var left = 0;
        var right = height.Length-1;

        var leftMax = 0;
        var rightMax = 0;
        var trappedWater = 0;

        while(left < right){
            if(height[left] < height[right]){
                if(height[left] < leftMax){
                    trappedWater += leftMax-height[left];
                }
                else{
                    leftMax = height[left];
                }

                left++;
            }
            else{
                if(height[right] < rightMax){
                    trappedWater += rightMax-height[right];
                }
                else{
                    rightMax = height[right];
                }
                right--;
            }
        }

        return trappedWater;
    }
}
