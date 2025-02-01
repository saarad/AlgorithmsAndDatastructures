//https://leetcode.com/problems/maximum-sum-circular-subarray/description/
/*
Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.

A circular array means the end of the array connects to the beginning of the array. Formally, the next element of nums[i] is nums[(i + 1) % n] and the previous element of nums[i] is nums[(i - 1 + n) % n].

A subarray may only include each element of the fixed buffer nums at most once. Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.
*/
public class Solution {
  public int MaxSubarraySumCircular(int[] nums)
  {
    if (nums.Length == 1)
        return nums[0];

    var maxSum = nums[0];
    var minSum = nums[0];
    var currMax = 0;
    var currMin = 0;

    //the minSum is used to find the minimum we would have to subtract from total sum to get an circular sub array
    var totalSum = 0;
    foreach(var num in nums){
        totalSum += num;
        currMax = Math.Max(currMax + num, num);
        currMin = Math.Min(currMin+num, num);

        maxSum = Math.Max(maxSum, currMax);
        minSum = Math.Min(minSum, currMin);
    }
    
    if(maxSum < 0)
        return maxSum;
    
    var maxCircular = totalSum - minSum;
    maxSum = Math.Max(maxSum, maxCircular);

    return maxSum;
  }


  private int MaxSum(int[] nums)
  {
      var maxSum = nums[0];
      var currSum = 0;
      foreach(var num in nums){
          currSum += num;
          maxSum = Math.Max(currSum, maxSum);
          currSum = Math.Max(0, currSum);
      }
  
      return maxSum;
  }

}
