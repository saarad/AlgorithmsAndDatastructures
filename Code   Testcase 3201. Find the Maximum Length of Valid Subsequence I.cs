//https://leetcode.com/problems/find-the-maximum-length-of-valid-subsequence-i/description
/*
You are given an integer array nums.
A subsequence sub of nums with length x is called valid if it satisfies:

(sub[0] + sub[1]) % 2 == (sub[1] + sub[2]) % 2 == ... == (sub[x - 2] + sub[x - 1]) % 2.
Return the length of the longest valid subsequence of nums.

A subsequence is an array that can be derived from another array by deleting some or no elements without changing the order of the remaining elements.
*/
public class Solution {
    //We have three kind of subsequnces: Every adjacent sum is even, Every adjacent sum is odd, or Every adjacent sum alternates
    public int MaximumLength(int[] nums) {
        var alternating = 0;
        var even = 0;
        var odd = 0;

        bool? lastEven = null;

        foreach(var num in nums){
            var isEven = num % 2 == 0;
            if(isEven)
            {
                even++;
            }
            else
            {
                odd++;
            }

            if(lastEven == null || lastEven.Value != isEven)
            {
                lastEven = isEven;
                alternating++;
            }
        }

        return Math.Max(Math.Max(even, odd), alternating);
    }
}
