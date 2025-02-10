//https://leetcode.com/problems/clear-digits/description
/*
You are given a string s.

Your task is to remove all digits by doing this operation repeatedly:

Delete the first digit and the closest non-digit character to its left.
Return the resulting string after removing all digits.
*/
public class Solution {
    public string ClearDigits(string s) {
        var stack = new List<char>();
        foreach(var c in s){
            if(char.IsDigit(c) && stack.Count > 0){
                stack.RemoveAt(stack.Count-1);
            }
            else{
                stack.Add(c);
            }
        }
        
        return new string(stack.ToArray());
    }
}
