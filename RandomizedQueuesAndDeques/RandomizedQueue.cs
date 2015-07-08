using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomizedQueuesAndDeques
{
    public class RandomizedQueue<T> : IEnumerable<T>
    {
        private T[] _internalArray;
        private int N = 0;
        private readonly Random _random;
        public RandomizedQueue()
        {
            _internalArray = new T[2];
            _random = new Random();
        }

        public bool IsEmpty
        {
            get { return N == 0; }
        }

        public int Size
        {
            get { return N; }
        }

        private void Resize(int max)
        {
            var temp = new T[max];
            for (int i = 0; i < N; i++)
            {
                temp[i] = _internalArray[i];
            }

            _internalArray = temp;
        }

        public void Enqueue(T item)
        {
            if (Equals(item, null))
            {
                throw new NullReferenceException("item cannot be null");
            }

            if (N == _internalArray.Length)
            {
                Resize(2 * _internalArray.Length);
            }

            _internalArray[N++] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty)
            {
                throw new ArgumentOutOfRangeException();
            }

            int index = (int)(_random.NextDouble() * N);
            var item = _internalArray[index];
            if (index != N - 1)
            {
                _internalArray[index] = _internalArray[N - 1];
            }

            _internalArray = _internalArray.Where((source, i) => i != N - 1).ToArray();
            //_internalArray[N - 1] = null;

            N--;
            if (N > 0 && N == _internalArray.Length / 4)
            {
                Resize(_internalArray.Length / 2);
            }

            return item;
        }

        private class RQIterator : IEnumerator<T>
        {
            private int index = 0;
            private T[] r;
            private int N;
            protected T[] ShuffleArray(T[] myArray)
            {
                int count = myArray.Length - 1;
                T[] newArray = new T[count + 1];

                Random rnd = new Random();
                var randomNumbers = Enumerable.Range(1, count).OrderBy(i => rnd.Next()).ToArray();

                int index = 0;
                foreach (var i in randomNumbers)
                {
                    newArray[index] = myArray[i];
                    index++;
                }

                return newArray;
            }

            public RQIterator(int len, T[] array)
            {
                N = len;
                r = new T[N];
                for (int i = 0; i < N; i++)
                    r[i] = array[i];

                r = ShuffleArray(r);
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                return index < N;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            public T Current
            {
                get
                {
                    if (!MoveNext())
                        return r[index++];

                    throw new ArgumentOutOfRangeException();
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new RQIterator(N, _internalArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
