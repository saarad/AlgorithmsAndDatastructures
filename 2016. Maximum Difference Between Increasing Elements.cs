//https://leetcode.com/problems/maximum-difference-between-increasing-elements/description

/*
Given a 0-indexed integer array nums of size n, find the maximum difference between nums[i] and nums[j] (i.e., nums[j] - nums[i]), such that 0 <= i < j < n and nums[i] < nums[j].

Return the maximum difference. If no such i and j exists, return -1.
*/
public class Solution {
    public int MaximumDifference(int[] nums) {
        var result = -1;
        var min = nums[0];

        for(int i = 1; i<nums.Length; i++){
            var max = nums[i];
            if(max<min){
                min = max;
            }
            else if(max>min){
                var tempResult = max-min;
                result = Math.Max(result, tempResult); 
            }
        }

        return result;
    }
}
