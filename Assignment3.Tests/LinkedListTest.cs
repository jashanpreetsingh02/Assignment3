using Assignment3.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{

    [TestFixture]
    public class LinkedListTest

    {

        [SetUp]
        public void Setup()
        {
            SLL<int> list = new SLL<int>();
        }

        [TearDown]
        public void TearDown()
        {
            object list = null;
        }

        [Test]
        public void TestIsEmpty()

        {
            
            SLL<int> list = new SLL<int>();
            Assert.IsTrue(list.IsEmpty());

            list.Append(1);
            Assert.IsFalse(list.IsEmpty());
        }

        [Test]
        public void TestClear()
        {
           
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [Test]
        public void TestAppend()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            Assert.That(list.GetAt(0), Is.EqualTo(1));

            list.Append(2);
            Assert.AreEqual(2, list.GetAt(1));
        }

        [Test]
        public void TestPrepend()
        {
            
            SLL<int> list = new SLL<int>();
            list.Prepend(2);
            Assert.AreEqual(2, list.GetAt(0));

            list.Prepend(1);
            Assert.AreEqual(1, list.GetAt(0));
        }

        [Test]
        public void TestInsertAt()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(3);
            list.InsertAt(1, 2);
            Assert.AreEqual(2, list.GetAt(1));
        }

        [Test]
        public void TestReplaceAt()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.ReplaceAt(0, 2);
            Assert.AreEqual(2, list.GetAt(0));
        }

        [Test]
        public void TestCount()
        {
            SLL<int> list = new SLL<int>();
            Assert.AreEqual(0, list.Count());

            list.Append(1);
            list.Append(2);
            Assert.AreEqual(2, list.Count());
        }

        [Test]
        public void TestRemoveAt()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.RemoveAt(1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(1, list.GetAt(0));
        }

        [Test]
        public void TestGetAt()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            Assert.AreEqual(1, list.GetAt(0));
            Assert.AreEqual(2, list.GetAt(1));
        }

        [Test]
        public void TestIndexOf()
        {
           
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            Assert.AreEqual(0, list.IndexOf(1));
            Assert.AreEqual(1, list.IndexOf(2));
        }

        [Test]
        public void TestContains()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            Assert.IsTrue(list.Contains(1));
            Assert.IsFalse(list.Contains(3));
        }

        [Test]
        public void TestReverse()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Reverse();
            Assert.AreEqual(3, list.GetAt(0));
            Assert.AreEqual(2, list.GetAt(1));
            Assert.AreEqual(1, list.GetAt(2));
        }

        [Test]
        public void TestSort()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(3);
            list.Append(1);
            list.Append(4);
            list.Append(2);
            list.Sort();
            Assert.AreEqual(1, list.GetAt(0));
            Assert.AreEqual(2, list.GetAt(1));
            Assert.AreEqual(3, list.GetAt(2));
            Assert.AreEqual(4, list.GetAt(3));
        }

        [Test]
        public void TestToArray()
        {
           
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            int[] array = list.ToArray();
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, array);
        }

        [Test]
        public void TestJoin()
        {
            
            SLL<int> list1 = new SLL<int>();
            list1.Append(1);
            list1.Append(2);

            SLL<int> list2 = new SLL<int>();
            list2.Append(3);
            list2.Append(4);

            list1.Join(list2);

            Assert.AreEqual(4, list1.Count());
        }

        [Test]
        public void TestDivide()
        {
            
            SLL<int> list = new SLL<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);
            list.Append(4);
            list.Append(5);

            (SLL<int> firstHalf, SLL<int> secondHalf) = list.Divide(2);

            Assert.That(firstHalf.Count(), Is.EqualTo(2));
            Assert.That(secondHalf.Count(), Is.EqualTo(3));
        }
    }
}
