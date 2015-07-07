using System;
using System.Collections;
using System.Collections.Generic;

namespace RandomizedQueuesAndDeques
{
    public class Deque<T> : IEnumerable<T>
    {
        private int N;
        private Node _first;
        private Node _last;

        public Deque()
        {
            _first = null;
            _last = null;
            N = 0;
        }

        public bool IsEmpty
        {
            get { return N == 0; }
        }

        public int Size
        {
            get { return N; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ListIterator(_first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void AddFirst(T item)
        {
            if (Equals(item, null))
            {
                throw new NullReferenceException("item cannot be null");
            }

            var oldFirst = _first;
            _first = new Node {Item = item, Previous = null, Next = oldFirst};
            if (IsEmpty)
            {
                _last = _first;
            }
            else
            {
                oldFirst.Previous = _first;
            }

            N += 1;
        }

        public void AddLast(T item)
        {
            if (Equals(item, null))
            {
                throw new NullReferenceException("item cannot be null");
            }

            var oldLast = _last;
            _last = new Node {Item = item, Previous = oldLast, Next = null};
            if (IsEmpty)
            {
                _first = _last;
            }
            else
            {
                oldLast.Next = _last;
            }

            N += 1;
        }

        public T RemoveFirst()
        {
            if (IsEmpty)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = _first.Item;
            _first = _first.Next;
            N -= 1;

            if (IsEmpty)
            {
                _last = null;
            }
            else
            {
                _first.Previous = null;
            }

            return item;
        }

        public T RemoveLast()
        {
            if (IsEmpty)
            {
                throw new ArgumentOutOfRangeException();
            }

            var item = _last.Item;
            _last = _last.Previous;
            N -= 1;

            if (IsEmpty)
            {
                _first = null;
            }
            else
            {
                _last.Next = null;
            }

            return item;
        }

        private class ListIterator : IEnumerator<T>
        {
            private readonly Node _first;
            private Node _current;

            public ListIterator(Node first)
            {
                _current = first;
                _first = first;
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                return _current != null;
            }

            public void Reset()
            {
                _current = _first;
            }

            public T Current
            {
                get
                {
                    var oldCurrent = _current;
                    _current = _current.Next;
                    return oldCurrent.Item;
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        internal class Node
        {
            public T Item { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }
    }
}