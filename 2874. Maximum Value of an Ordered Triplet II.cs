//https://leetcode.com/problems/maximum-value-of-an-ordered-triplet-ii/description/
/*
You are given a 0-indexed integer array nums.

Return the maximum value over all triplets of indices (i, j, k) such that i < j < k. If all such triplets have a negative value, return 0.

The value of a triplet of indices (i, j, k) is equal to (nums[i] - nums[j]) * nums[k].
*/

public class Solution {
    /*
    Calculate the max possible k for all elements
    For each element as j, take max possible i and max possible k
    */
    public long MaximumTripletValue(int[] nums) {
        var maxValues = new long[nums.Length];
        maxValues[nums.Length-1] = nums[nums.Length-1];
        maxValues[nums.Length-2] = nums[nums.Length-1];

        var prevNum = maxValues[nums.Length-1];
        for(int el = nums.Length-3; el>=0; el--){
            long currentNum = nums[el+1];
            long max = Math.Max(currentNum, prevNum);
            maxValues[el] = max;
            prevNum = max;
        }

        long j = nums[1];
        long i = nums[0];
        long k = maxValues[1];

        long maxPrefix = i;

        long maxValue = CalculateTriplet(i, j, k);
        for(int el = 2; el<nums.Length-1; el++){
            maxPrefix = Math.Max(maxPrefix, nums[el-1]);

            j = nums[el];
            i = maxPrefix;
            k = maxValues[el];

            long sum = CalculateTriplet(i, j, k);
            maxValue = Math.Max(sum, maxValue);
        }

        return maxValue;
    }

    private long CalculateTriplet(long i, long j, long k){
        long result = (i-j)*k;
        return result > 0 ? result : 0;
    }
}
