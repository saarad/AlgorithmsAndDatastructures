//https://leetcode.com/problems/number-of-sub-arrays-of-size-k-and-average-greater-than-or-equal-to-threshold/description/
/*
Given an array of integers arr and two integers k and threshold, return the number of sub-arrays of size k and average greater than or equal to threshold.
*/
public class Solution {
    public int NumOfSubarrays(int[] arr, int k, int threshold) {
        double windowSum = 0.0;
        var left = 0;
        var groups = 0;
        for(int i = 0; i<k; i++){
            windowSum += arr[i];
        }

        if(windowSum/k >= threshold){
            groups++;
        }

        for(int right = k; right<arr.Length; right++){
            if(right-left+1 > k){
                windowSum -= arr[left];
                left++;
            }

            windowSum += (double)arr[right];
            var average = windowSum / k;
            if(average >= threshold)
                groups++;
        }

        return groups;
    }
}
