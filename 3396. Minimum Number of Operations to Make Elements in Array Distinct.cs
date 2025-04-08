//https://leetcode.com/problems/minimum-number-of-operations-to-make-elements-in-array-distinct/description
/*
You are given an integer array nums. You need to ensure that the elements in the array are distinct. To achieve this, you can perform the following operation any number of times:

Remove 3 elements from the beginning of the array. If the array has fewer than 3 elements, remove all remaining elements.
Note that an empty array is considered to have distinct elements. Return the minimum number of operations needed to make the elements in the array distinct.
*/

public class Solution {
  /*
  Keep track of last removed position - if current duplicate is over then keep removing
  */
    public int MinimumOperations(int[] nums) {
        var seen = new Dictionary<int, int>();
        var currentRemoved = -1;
        var operations = 0;
        for(int i = 0; i<nums.Length; i++){
            var num = nums[i];
            if(!seen.ContainsKey(num)){
                seen.Add(num, i);
            }
            else if(seen[num]>currentRemoved){
                while(seen[num]>currentRemoved){
                    operations++;
                    currentRemoved += 3;
                }
                seen[num] = i;
            }
            else{
                seen[num] = i;
            }
        }

        return operations;
    }
}
