using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RandomizedQueuesAndDeques
{
    public class RandomizedQueueTests
    {
        [Test]
        public void RandomizedQueueTest()
        {
            for (var k = 0; k < 9; k++)
            {
                var q = new RandomizedQueue<string>();

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

                foreach (var item in items)
                {
                    q.Enqueue(item);
                }

                var array = new List<string>();
                for (var i = 0; i < k; i++)
                {
                    array.Add(q.Dequeue());
                }

                Assert.AreEqual(k, array.Distinct().Count());
            }
        }
    }
}