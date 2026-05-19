using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms_CS.BasicStructures
{
    public class MyLinkedList
    {
        private Node _head = null;
        private Node _tail = null;
        private int _count = 0;

        public int Count
        {
            get { return _count; }
        }


        public void AddFirst(int key)
        {
            Node node = new Node(key);

            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                node.next = _head;
                _head = node;
            }
            _count++;
        }

        public int DelFirst()
        {
            if (_head == null) throw new Exception();
            int res = _head.key;
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
                _head = _head.next;
            _count--;
            return res;
        }

        public void AddLast(int key)
        {
            Node node = new Node(key);

            if (_tail == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.next = node;
                _tail = node;
            }
            _count++;
        }

        public int DelLast()
        {
            if (_tail == null) throw new Exception();
            int res = _tail.key;
            if (_head == _tail)
            {
                _head = null;
                _tail = null;
            }
            else
            {
                Node node = _head;
                while (node.next != _tail)
                    node = node.next;
                _tail = node;
                _tail.next = null;
            }
            _count--;
            return res;
        }

        public class Node
        {
            public Node next = null;
            public int key;

            public Node(int key)
            {
                this.key = key;
            }
        }
    }
}
