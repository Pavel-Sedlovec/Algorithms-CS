namespace Algorithms_CS.Problems
{
    class MiddleoftheLinkedList
    {
        public ListNode MiddleNode(ListNode head)
        {
            int countStep = 0;
            ListNode node = head;

            while (node.next != null)
            {
                node = node.next;
                countStep++;
            }
            if (countStep % 2 == 0)
            {
                countStep /= 2;
            }
            else
            {
                countStep = countStep / 2 + 1;
            }

            for (int i = 0; i < countStep; i++)
            {
                head = head.next;
            }
            return head;
        }

        public ListNode MiddleNodeSlowFast(ListNode head)
        {
            ListNode slow = head;
            ListNode fast = head;
            while(fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }
    }    
}
