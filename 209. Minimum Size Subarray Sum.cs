//https://leetcode.com/problems/minimum-size-subarray-sum/description/
/*
Given an array of positive integers nums and a positive integer target, return the minimal length of a 
subarray
 whose sum is greater than or equal to target. If there is no such subarray, return 0 instead.
 */
public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        var left = 0;
        var minLength = int.MaxValue;

        var currSum = 0;
        for(int right = 0; right<nums.Length; right++){
            currSum += nums[right];
            while(currSum >= target){ //make window smaller until current sum is lower than target
                minLength = Math.Min(right-left+1, minLength);
                currSum -= nums[left];
                left++;
            }
        }

        return minLength == int.MaxValue ? 0 : minLength;
    }
}
