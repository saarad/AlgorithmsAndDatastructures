//https://leetcode.com/problems/minimum-operations-to-make-array-values-equal-to-k/description/?envType=daily-question&envId=2025-04-15

/*
You are given an integer array nums and an integer k.

An integer h is called valid if all values in the array that are strictly greater than h are identical.

For example, if nums = [10, 8, 10, 8], a valid integer is h = 9 because all nums[i] > 9 are equal to 10, but 5 is not a valid integer.

You are allowed to perform the following operation on nums:

Select an integer h that is valid for the current values in nums.
For each index i where nums[i] > h, set nums[i] to h.
Return the minimum number of operations required to make every element in nums equal to k. If it is impossible to make all elements equal to k, return -1.
*/

/*
If a number is lower than K, we cannot do any valid operations to turn it to k, since a number can only be turned to h if nums[i] > h (Eventually h = k and that number is not allowed to be turned to h).
For each unique number that is larger than k, we will have to do an operation to turn it to k. Imagine k = 2 and nums = [2,3,4]. First, 4 would be turned into 3 and then both 3s would be turned into 2.
*/
public class Solution {
    public int MinOperations(int[] nums, int k) {
        var greater = new HashSet<int>();
        for(int i = 0; i<nums.Length; i++){
            var num = nums[i];
            if(num < k)
                return -1;
            
            if(num > k)
                greater.Add(num);
        }

        return greater.Count;
    }
}
