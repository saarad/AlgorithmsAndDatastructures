//https://leetcode.com/problems/min-stack/description/
/*
Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

Implement the MinStack class:

MinStack() initializes the stack object.
void push(int val) pushes the element val onto the stack.
void pop() removes the element on the top of the stack.
int top() gets the top element of the stack.
int getMin() retrieves the minimum element in the stack.
You must implement a solution with O(1) time complexity for each function.
*/
public class MinStack {
    private readonly Stack<(int, int)> stack; 
    public MinStack() {
        stack = new();
    }
    
    public void Push(int val) {
        var (_, lastMin) = stack.Count > 0 ? stack.Peek() : (val, val);
        if(val<=lastMin){
            lastMin = val;
        }
        stack.Push((val, lastMin));
    }
    
    public void Pop() {
        stack.Pop();
    }
    
    public int Top() {
        var (val, _) = stack.Peek();
        return val;
    }
    
    public int GetMin() {
        var (_, min) = stack.Peek();
        return min;
    }
}

/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(val);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */
