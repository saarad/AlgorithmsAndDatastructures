// https://leetcode.com/problems/partition-labels/description
/*
You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part. For example, the string "ababcc" can be partitioned into ["abab", "cc"], but partitions such as ["aba", "bcc"] or ["ab", "ab", "cc"] are invalid.

Note that the partition is done so that after concatenating all the parts in order, the resultant string should be s.

Return a list of integers representing the size of these parts.
*/
public class Solution {
    public IList<int> PartitionLabels(string s) {
        var map = new Dictionary<char, int>();

        //find last occurence of each char
        for(int i = 0; i<s.Length; i++){
            var c = s[i];
            if(map.ContainsKey(c)){
                map[c] = i;
            }
            else{
                map.Add(c, i);
            }
        }

        //each segment must be as long as the last seen occurence of a given char in the segment
        var result = new List<int>();
        var segmentEnd = map[s[0]];
        var lastEndIndex = -1;

        if(segmentEnd == 0){
            result.Add(1);
            lastEndIndex = 0;
        }

        for(int i = 1; i<s.Length; i++){
            var c = s[i];
            var lastSeen = map[c];
            segmentEnd = Math.Max(segmentEnd, lastSeen); //move segment end to last seen occurence
            if(segmentEnd == i){
                var distance = segmentEnd - lastEndIndex;
                lastEndIndex = segmentEnd;
                result.Add(distance);
            }
            else if(segmentEnd == s.Length-1){
                var distance = segmentEnd - lastEndIndex;
                result.Add(distance);
                break;
            }
        }

        return result;
    }
}
