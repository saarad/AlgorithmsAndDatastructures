//https://leetcode.com/problems/valid-parentheses/description/
/*
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
*/

public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        stack.Push(s[0]);
        for(int i = 1; i<s.Length; i++){
            var last = stack.Count != 0 ? stack.Peek() : 'N';
            var current = s[i];
            var isClose = IsCloseTag(last, current);
            if(isClose && stack.Count > 0){
                stack.Pop();
            }
            else if(!isClose){
                stack.Push(s[i]);
            }
        }

        return stack.Count == 0;
    }

    private bool IsCloseTag(char open, char close){
        if(open == '(')
            return close == ')';
        if(open == '[')
            return close == ']';
        if(open == '{')
            return close == '}';
        
        return false;
    }
}
