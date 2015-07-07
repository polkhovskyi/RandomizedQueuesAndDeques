using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace RandomizedQueuesAndDeques
{
    internal class DequeTests
    {
        [Test]
        public void TestDequeFirst()
        {
            var deque = new Deque<String>();
            var items = new List<string>
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);

            foreach (var item in items)
            {
                deque.AddFirst(item);
            }

            var builder = new StringBuilder();
            foreach (var item in deque)
            {
                builder.Append(item);
            }

            Assert.AreEqual("9876543210", builder.ToString());
            Assert.AreEqual(10, deque.Size);
            Assert.IsFalse(deque.IsEmpty);

            while (!deque.IsEmpty)
            {
                deque.RemoveFirst();
            }

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);
        }

        [Test]
        public void TestDequeLast()
        {
            var deque = new Deque<String>();
            var items = new List<string>
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);

            foreach (var item in items)
            {
                deque.AddLast(item);
            }

            var builder = new StringBuilder();
            foreach (var item in deque)
            {
                builder.Append(item);
            }

            Assert.AreEqual("0123456789", builder.ToString());
            Assert.AreEqual(10, deque.Size);
            Assert.IsFalse(deque.IsEmpty);

            while (!deque.IsEmpty)
            {
                deque.RemoveLast();
            }

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);
        }

        [Test]
        public void AdvancedTestDequeFirst()
        {
            var deque = new Deque<String>();
            var items = new List<string>
            {
                "0",
                "1",
                "2",
                "-",
                "-",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);

            foreach (var item in items)
            {
                if (item != "-")
                {
                    deque.AddFirst(item);
                }
                else
                {
                    if (!deque.IsEmpty)
                    {
                        deque.RemoveFirst();
                    }
                }
            }

            var builder = new StringBuilder();
            foreach (var item in deque)
            {
                builder.Append(item);
            }

            Assert.AreEqual("98765430", builder.ToString());
            Assert.AreEqual(8, deque.Size);
            Assert.IsFalse(deque.IsEmpty);

            while (!deque.IsEmpty)
            {
                deque.RemoveFirst();
            }

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);
        }

        [Test]
        public void AdvancedTestDequeLast()
        {
            var deque = new Deque<String>();
            var items = new List<string>
            {
                "0",
                "1",
                "2",
                "-",
                "-",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);

            foreach (var item in items)
            {
                if (item != "-")
                {
                    deque.AddLast(item);
                }
                else
                {
                    if (!deque.IsEmpty)
                    {
                        deque.RemoveLast();
                    }
                }
            }

            var builder = new StringBuilder();
            foreach (var item in deque)
            {
                builder.Append(item);
            }

            Assert.AreEqual("03456789", builder.ToString());
            Assert.AreEqual(8, deque.Size);
            Assert.IsFalse(deque.IsEmpty);

            while (!deque.IsEmpty)
            {
                deque.RemoveLast();
            }

            Assert.AreEqual(0, deque.Size);
            Assert.IsTrue(deque.IsEmpty);
        }
    }
}