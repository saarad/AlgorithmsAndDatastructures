//https://leetcode.com/problems/max-sum-of-a-pair-with-equal-sum-of-digits
/*
You are given a 0-indexed array nums consisting of positive integers. You can choose two indices i and j, such that i != j, and the sum of digits of the number nums[i] is equal to that of nums[j].
Return the maximum value of nums[i] + nums[j] that you can obtain over all possible indices i and j that satisfy the conditions.
*/
public class Solution {
    public int MaximumSum(int[] nums) {
        var map = new Dictionary<int, List<int>>();

        //offline - create map with sums
        foreach(var num in nums){
            var sum = SumDigits(num);
            if(map.ContainsKey(sum)){
                if(map[sum].Count < 2){
                    map[sum].Add(num);
                    
                }
                else{ //we want to only keep two biggest members in family - kick the rest out to keep cache small
                    var minElement = Math.Min(map[sum][0], map[sum][1]);
                    if(minElement < num){
                        map[sum].Remove(minElement);
                        map[sum].Add(num);
                    }
                }
            }
            else{
                var family = new List<int>(2);
                family.Add(num);
                map.Add(sum, family);
            }
        }

        var maxSum = -1;
        foreach(var keyvalue in map){
            var family = keyvalue.Value;
            if(family.Count > 1){
                var sum = family[0] + family[1]; //there is only two members in family at most
                maxSum = Math.Max(maxSum, sum);
            }
        }

        return maxSum;
    }

    private int SumDigits(int num){
        var sum = 0;
        while(num > 0){
            sum += num % 10;
            num = num / 10; //remove last added
        }

        return sum;
    }

}
