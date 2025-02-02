//https://leetcode.com/problems/design-browser-history/description/
/*
You have a browser of one tab where you start on the homepage and you can visit another url, get back in the history number of steps or move forward in the history number of steps.

Implement the BrowserHistory class:

BrowserHistory(string homepage) Initializes the object with the homepage of the browser.
void visit(string url) Visits url from the current page. It clears up all the forward history.
string back(int steps) Move steps back in history. If you can only return x steps in the history and steps > x, you will return only x steps. Return the current url after moving back in history at most steps.
string forward(int steps) Move steps forward in history. If you can only forward x steps in the history and steps > x, you will forward only x steps. Return the current url after forwarding in history at most steps.
*/

//Using double linked list to keep track of history
public class BrowserHistory {
    private Node _current;

    public BrowserHistory(string homepage) {
        _current = new Node(homepage);
    }
    
    public void Visit(string url) {
        var node = new Node(url, _current);
        _current.Next = node; //clear forward history 
        _current = node;
    }
    
    public string Back(int steps) {
        return Back(steps, steps);
    }

    private string Back(int steps, int left){
        if(left == 0)
            return _current.Url;
        
        if(_current.Prev == null) //At head - i.e. first page visited
            return _current.Url;
        
        _current = _current.Prev;
        return Back(steps, left-1);
    }
    
    public string Forward(int steps) {
        return Forward(steps, steps);
    }

    private string Forward(int steps, int left){
        if(left == 0)
            return _current.Url;
        if(_current.Next == null) //At tail - i.e. last page visited
            return _current.Url;
        
        _current = _current.Next;
        return Forward(steps, left-1);
    }

    private class Node{
        public Node Prev = null;
        public Node Next = null;
        public string Url = null;

        public Node(string url = null, Node prev = null, Node next = null){
            Url = url;
            Prev = prev;
            Next = next;
        }
    }
}

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory obj = new BrowserHistory(homepage);
 * obj.Visit(url);
 * string param_2 = obj.Back(steps);
 * string param_3 = obj.Forward(steps);
 */
