namespace Algorithms_CS.Problems
{
    // Given head, the head of a linked list, determine if the linked list has a cycle in it.
    // A cycle exists if some node can be reached again by continuously following the next pointer.
    // Return true if there is a cycle, otherwise return false.
    //
    // Example 1:
    // Input: head = [3,2,0,-4], pos = 1
    // Output: true
    // Explanation: Tail connects to the 1st node (0-indexed).
    //
    // Example 2:
    // Input: head = [1,2], pos = 0
    // Output: true
    // Explanation: Tail connects to the 0th node.
    //
    // Example 3:
    // Input: head = [1], pos = -1
    // Output: false
    // Explanation: No cycle in the linked list.
    public class LinkedListCycle
    {
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if(slow == fast) return true;
            }
            return false;
        }
    }
}
