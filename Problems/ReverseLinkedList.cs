namespace Algorithms_CS.Problems
{
    // Given the head of a singly linked list, reverse the list,
    // and return the reversed list.
    //
    // Example 1:
    // Input: head = [1,2,3,4,5]
    // Output: [5,4,3,2,1]
    //
    // Example 2:
    // Input: head = [1,2]
    // Output: [2,1]
    //
    // Example 3:
    // Input: head = []
    // Output: []
    //
    // Follow up: A linked list can be reversed either iteratively or recursively.
    // Could you implement both?
    public class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            ListNode newHead = ReverseList(head.next);
            head.next.next = head;
            head.next = null;
            
            return newHead;
        }

        public ListNode ReverseListIter(ListNode head)
        {

            ListNode last = null;
            ListNode cur = head;           

            while(cur != null)
            {
                ListNode next = cur.next;

                cur.next = last;
                last = cur;
                cur = next;
            }
            return last;  
        }
    }
}
