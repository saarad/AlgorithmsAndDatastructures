//https://leetcode.com/problems/reverse-linked-list/
//Given the head of a singly linked list, reverse the list, and return the reversed list.
/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode ReverseList(ListNode head) {
        return Recursive(head);
    }

    private ListNode Iterative(ListNode head){
        if(head == null || head.val == null || head.next == null)
            return head;
        
        var current = head;
        var next = head.next;
        ListNode prev = null;
        var newHead = head;
        while(next != null){
            next = current.next;
            current.next = prev;
            prev = current;
            current = next;
            if(next == null){
                newHead = prev;
                break;
            }
            
        }

        return newHead;
    }

    private ListNode Recursive(ListNode head){
        if(head == null || head.val == null || head.next == null)
            return head;

        var prev = head;
        var current = head.next;
        var next = current.next;
        prev.next = null;
        return Reverse(prev, current, next);
    }

    private ListNode Reverse(ListNode prev, ListNode current, ListNode next){
        current.next = prev;
        if(next == null)
            return current;

        return Reverse(current, next, next.next);
    }
}
