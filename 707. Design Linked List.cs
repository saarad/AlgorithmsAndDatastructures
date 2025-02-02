//https://leetcode.com/problems/design-linked-list/description/
/*
Design your implementation of the linked list. You can choose to use a singly or doubly linked list.
A node in a singly linked list should have two attributes: val and next. val is the value of the current node, and next is a pointer/reference to the next node.
If you want to use the doubly linked list, you will need one more attribute prev to indicate the previous node in the linked list. Assume all nodes in the linked list are 0-indexed.

Implement the MyLinkedList class:

MyLinkedList() Initializes the MyLinkedList object.
int get(int index) Get the value of the indexth node in the linked list. If the index is invalid, return -1.
void addAtHead(int val) Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list.
void addAtTail(int val) Append a node of value val as the last element of the linked list.
void addAtIndex(int index, int val) Add a node of value val before the indexth node in the linked list. If index equals the length of the linked list, the node will be appended to the end of the linked list. If index is greater than the length, the node will not be inserted.
void deleteAtIndex(int index) Delete the indexth node in the linked list, if the index is valid.
*/
public class MyLinkedList {
    private int _count = 0;
    private DoubleLinked _head = null;
    private DoubleLinked _tail = null;

    public MyLinkedList() {
        
    }
    
    public int Get(int index) {
        if(index < 0 || index >= _count){
            return -1;
        }

        if(index == 0)
            return _head.Val;
        if(index == _count-1)
            return _tail.Val;
        
        var result = _head;
        for(int i = 1; i<=index; i++){
            result = result.Next;
        }

        return result.Val;
    }
    
    public void AddAtHead(int val) 
    {
        if (_count == 0) 
        {
            // If the list is empty, just make one new node that is both head and tail
            var node = new DoubleLinked(val, null, null);
            _head = node;
            _tail = node;
            _count = 1;
        } 
        else 
        {
            // Put new node before the current head
            var node = new DoubleLinked(val, null, _head);
            _head.Prev = node;
            _head = node;
            _count++;
        }
    }

    
    public void AddAtTail(int val)
    {
        if (_count == 0)
        {
            // Same as above, only node is both head and tail
            var node = new DoubleLinked(val, null, null);
            _head = node;
            _tail = node;
            _count = 1;
        }
        else
        {
            // Link after the current tail
            var node = new DoubleLinked(val, _tail, null);
            _tail.Next = node;
            _tail = node;
            _count++;
        }
    }

    
    public void AddAtIndex(int index, int val) {
        if(index > _count || index < 0)
            return;
        if(index == _count){
            AddAtTail(val);
            return;
        }
        if(index == 0){
            var headNode = new DoubleLinked(val, null, _head);
            _head.Prev = headNode;
            _head = headNode;
            if(_count == 1){
                _tail = _head.Next;
            }

            _count++;
            return;
        }

        var current = _head;
        for(int i = 1; i<=index; i++){
            current = current.Next;
        }

        var node = new DoubleLinked(val, current.Prev, current);
        current.Prev.Next = node;
        current.Prev = node;
        _count++;
    }
    
    public void DeleteAtIndex(int index) {
        if (index < 0 || index >= _count) return;
        
        if (index == 0) {
            // Remove head
            _head = _head.Next;
            _count--;
            if (_head != null) {
                _head.Prev = null;
            }
        } 
        else if (index == _count - 1) {
            // Remove tail
            _tail = _tail.Prev;
            _tail.Next = null;
            _count--;
        } 
        else {
            // Remove a middle node
            var current = _head;
            for(int i = 0; i < index; i++){
                current = current.Next;
            }
            current.Prev.Next = current.Next;
            current.Next.Prev = current.Prev;
            _count--;
        }

        // If the list became empty, both head and tail must be null:
        if (_count == 0) {
            _head = null;
            _tail = null;
        }
    }


    private class DoubleLinked{
        public readonly int Val;
        public DoubleLinked Prev;
        public DoubleLinked Next;

        public DoubleLinked(int val=0, DoubleLinked prev=null, DoubleLinked next=null){
            Val = val;
            Prev = prev;
            Next = next;
        }
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.Get(index);
 * obj.AddAtHead(val);
 * obj.AddAtTail(val);
 * obj.AddAtIndex(index,val);
 * obj.DeleteAtIndex(index);
 */
