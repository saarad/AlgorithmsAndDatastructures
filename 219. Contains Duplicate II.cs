//https://leetcode.com/problems/contains-duplicate-ii/
//Given an integer array nums and an integer k, return true if there are two distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <= k.
public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        if(k == 0)
            return false;

        var left = 0;
        var set = new HashSet<int>();
        for(int right = 0; right<nums.Length; right++){
            if(right-left > k){ //make window smaller, too large abs value of window size
                set.Remove(nums[left]);
                left++;
            }

            if(!set.Add(nums[right]))
                return true;
        }

        return false;

    }
}
