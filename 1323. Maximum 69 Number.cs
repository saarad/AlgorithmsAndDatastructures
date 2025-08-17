//https://leetcode.com/problems/maximum-69-number/description

/*
You are given a positive integer num consisting only of digits 6 and 9.

Return the maximum number you can get by changing at most one digit (6 becomes 9, and 9 becomes 6).
*/

public class Solution {
    public int Maximum69Number (int num) {
        var numString = num.ToString().ToCharArray(); //string is readonly
        var indexOfFirstSix = 0;
        for(int i = 0; i<numString.Length; i++){
            var number = numString[i];
            if(number == '6'){
                indexOfFirstSix = i;
                break;
            }
        }

        numString[indexOfFirstSix] = '9';

        return int.Parse(numString.AsSpan());
    }
}
