//https://leetcode.com/problems/special-array-i/description/
//An array is considered special if every pair of its adjacent elements contains two numbers with different parity.
//You are given an array of integers nums. Return true if nums is a special array, otherwise, return false.
public class Solution {
    public bool IsArraySpecial(int[] nums) {
        if(nums.Length == 1)
            return true;
        
        var prev = nums[0];
        for(int i = 1; i<nums.Length; i++){
            var next = nums[i];
            if((prev%2 == 0 && next%2==0) || (prev%2 != 0 && next%2 != 0)){
                return false;
            }

            prev = next;
        }

        return true;
    }
}
