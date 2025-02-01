//https://leetcode.com/problems/maximum-subarray/
/*Given an integer array nums, find the 
subarray
 with the largest sum, and return its sum.
*/
public class Solution {
    public int MaxSubArray(int[] nums) {
        var maxSum = nums[0];
        var currSum = 0;
        //Kadane algorithm - if we get a negative sum, reset window
        foreach(var num in nums){
            currSum += num;
            maxSum = Math.Max(currSum, maxSum);
            currSum = Math.Max(0, currSum); //reset if negative sum
        }

        return maxSum;
    }
}
