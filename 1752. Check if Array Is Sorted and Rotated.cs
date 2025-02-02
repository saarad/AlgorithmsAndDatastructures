//https://leetcode.com/problems/check-if-array-is-sorted-and-rotated
public class Solution {
    //We identify rotation point by where nums[i]>nums[i-1] - it is specified only 1 rotation
    //From that rotation point, if all numbers are non-decreasing order return true
    public bool Check(int[] nums) {
        if(nums.Length == 1)
            return true;
        
        var prev = nums[0];
        var isInRotation = false;
        for(int i = 1; i<nums.Length; i++){
            var next = nums[i];
            if(prev > next){
                if(!isInRotation){
                    isInRotation = true;
                }
                else{
                    return false;
                }
            }

            prev = next;
            
        }

        if(isInRotation){
            return nums[nums.Length-1] <= nums[0];
        }

        return true;
    }
}
