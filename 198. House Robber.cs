//https://leetcode.com/problems/house-robber/
/*
You are a professional robber planning to rob houses along a street. Each house has a certain amount of money stashed, the only constraint stopping you from robbing each of them is that adjacent houses have security systems connected and it will automatically contact the police if two adjacent houses were broken into on the same night.

Given an integer array nums representing the amount of money of each house, return the maximum amount of money you can rob tonight without alerting the police
*/
//We have 4 base cases:
//1. There is only 1 house
//2. There is 2 houses, we need to pick the one with highest value
//3. There is 3 houses, we need to take house 1 + 3 or just house 2
//4. There is 4 houses, the sum can be computed in two possible ways: House 4 + 2 or 4 + 1.
//We cache the maximum sum we can have at each house to compute dynamically 
public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length == 1)
            return nums[0];
        if(nums.Length == 2)
            return Math.Max(nums[0], nums[1]);
        
        var cache = new int[nums.Length];
        cache[0] = nums[0];
        cache[1] = nums[1];

        var sum = 0;
        if(nums[0] >= nums[1]){
            sum += nums[0];
        }
        else{
            sum += nums[1];
        }

        cache[2] = nums[2] + nums[0];
        sum = Math.Max(sum, cache[2]);
        if(nums.Length == 3)
            return sum;

        for(int i = 3; i<nums.Length; i++){
            var possibleSum1 = cache[i-2]+nums[i];
            var possibleSum2 = cache[i-3]+nums[i];

            cache[i] = Math.Max(possibleSum1, possibleSum2);
            sum = Math.Max(sum, cache[i]);
        }

        return sum;
    }
}
