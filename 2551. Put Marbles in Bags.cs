//https://leetcode.com/problems/put-marbles-in-bags/description
/*
You have k bags. You are given a 0-indexed integer array weights where weights[i] is the weight of the ith marble. You are also given the integer k.

Divide the marbles into the k bags according to the following rules:

No bag is empty.
If the ith marble and jth marble are in a bag, then all marbles with an index between the ith and jth indices should also be in that same bag.
If a bag consists of all the marbles with an index from i to j inclusively, then the cost of the bag is weights[i] + weights[j].
The score after distributing the marbles is the sum of the costs of all the k bags.

Return the difference between the maximum and minimum scores among marble distributions.
*/
public class Solution {
    /*
    We disregard what the actual partitions are, but rather look at the cost of the partitions.
    Every partition we create costs the marble weight[i] + weight[j], 
    where i is start of partion and j is end. If no partitions of the marble list is needed the cost is 0. 

    We want to calculate adjacent partion costs, 
    where the score is k maximum partion costs - k minimum partion costs.
    */
    public long PutMarbles(int[] weights, int k) {
        if(k == 1 || k == weights.Length){ //no partitions are needed
            return 0;
        }

        //Offline - calculate costs for adjacent partitions
        var sums = new int[weights.Length-1];
        for(int i = 0; i<sums.Length; i++){
            sums[i] = weights[i] + weights[i+1];
        }

        Array.Sort(sums);

        long score = 0;
        //for each partition needed increase score with the partition that costs the most - the one that
        //costs the least
        for(int i = 0; i<k-1; i++){
            score += sums[sums.Length-1-i] - sums[i];
        }

        return score;
    }
}
