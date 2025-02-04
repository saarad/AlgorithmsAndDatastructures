//https://leetcode.com/problems/maximum-ascending-subarray-sum/description/
/*
Given an array of positive integers nums, return the maximum possible sum of an ascending subarray in nums.

A subarray is defined as a contiguous sequence of numbers in an array.

A subarray [numsl, numsl+1, ..., numsr-1, numsr] is ascending if for all i where l <= i < r, numsi  < numsi+1. Note that a subarray of size 1 is ascending.
*/

//We think in a Kadane way: Iterate until we found a num that is smaller or equal than prev, update max and reset current
public class Solution {
    public int MaxAscendingSum(int[] nums) {
        var maxSum = 0;
        var currentSum = nums[0];
        var prev = nums[0];
        for(int i = 1; i<nums.Length; i++){
            var next = nums[i];
            if(next<=prev){
                maxSum = Math.Max(currentSum, maxSum);
                currentSum = next;
            }
            else{
                currentSum += next;
            }

            prev = next;
        }

        return Math.Max(maxSum, currentSum); //flush
    }
}
