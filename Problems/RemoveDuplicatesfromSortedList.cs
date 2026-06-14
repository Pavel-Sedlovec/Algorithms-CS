namespace Algorithms_CS.Problems
{
    // Given the head of a sorted linked list, delete all duplicates such that each
    // element appears only once. Return the linked list sorted as well.
    //
    // Example 1:
    // Input: head = [1,1,2]
    // Output: [1,2]
    //
    // Example 2:
    // Input: head = [1,1,2,3,3]
    // Output: [1,2,3]
    public class RemoveDuplicatesfromSortedList
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            ListNode node = head;
            while(node != null)
            {
                while (node.next != null && node.val == node.next.val)
                {
                    node.next = node.next.next;
                }
                node = node.next;
            }
            return head;
        }
    }

}
