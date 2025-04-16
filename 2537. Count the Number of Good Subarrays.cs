//https://leetcode.com/problems/count-the-number-of-good-subarrays/description/?envType=daily-question&envId=2025-04-16

/*
Given an integer array nums and an integer k, return the number of good subarrays of nums.

A subarray arr is good if there are at least k pairs of indices (i, j) such that i < j and arr[i] == arr[j].

A subarray is a contiguous non-empty sequence of elements within an array.
*/
public class Solution {
    //Using sliding window
    //As soon as k is met, you know that for each element left there is a new sub array
    //As soon as left side is slid out and pairs are below k, we can stop
    //When there are more than or equal to two equal numbers in window, we have indices found += frequence-1.
    public long CountGood(int[] nums, int k) {
        var map = new Dictionary<int, long>();
        long foundIndices = 0;
        long good = 0;

        var left = 0;
        var right = 1;
        map.Add(nums[0], 1);
        var newNumber = true;

        while(left<=right && right<nums.Length){
            var next = nums[right];

            if(map.ContainsKey(next) && newNumber){
                map[next]++;
            }
            else if(newNumber){
                map.Add(next, 1);
            }

            if(map[next] >= 2 && newNumber){
                foundIndices += map[next]-1;
            }

            if(foundIndices >= k){
                good++;
                good += nums.Length-1-right;
                var start = nums[left];
                map[start]--;
                if(map[start] > 0){
                    foundIndices -= map[start];
                }

                left++;
                newNumber = false;

            }
            else{
                right++;
                newNumber = true;

            }
        }

        return good;
    }
}
