//https://leetcode.com/problems/check-if-one-string-swap-can-make-strings-equal/description/
/*
You are given two strings s1 and s2 of equal length. A string swap is an operation where you choose two indices in a string (not necessarily different) and swap the characters at these indices.

Return true if it is possible to make both strings equal by performing at most one string swap on exactly one of the strings. Otherwise, return false.
*/
public class Solution {
    //We could use a frequencymap
    //But we can avoid using the extra space if we just count number of mismatches and return false if we encounter more than 1 mismatch (O(1))
    public bool AreAlmostEqual(string s1, string s2) {
        if(s1.Length != s2.Length)
            return false;

        var length = s1.Length;
        if(length == 1)
            return s1[0] == s2[0];


        var mismatchFound = 0;
        var mismatchPosition = 0;
        var mismatchChecked = false;
        for(int i = 0; i<length; i++){

            if(s1[i] != s2[i]){
                mismatchFound++;
                if(mismatchFound == 1)
                    mismatchPosition = i; //set position of the first char encountered that mismatched in the strings
            }
            
            if(mismatchFound == 2 && !mismatchChecked){ //second mismatch encountered - this is either our swap point or another mismatch
                mismatchChecked = true;
                if(s1[mismatchPosition] == s2[i] && s2[mismatchPosition] == s1[i]) //swap point, check rest of strings
                    continue;
                
                return false; //was a another mismatch
            }

            if(mismatchFound > 2) //more than 1 mismatch found
                return false;
                
        }

        return mismatchFound > 0 && !mismatchChecked ? s1[mismatchPosition] == s2[^1] && s2[mismatchPosition] == s1[^1] : true;
    }
}
