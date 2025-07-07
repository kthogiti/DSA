using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Legacy;

namespace DSA.LinkedList.Tests
{
    [TestFixture]
    public class LinkedListTest
    {
        [Test]
        public void Constructor_InitializesEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.That(list.Head, Is.Null);
            Assert.That(list.Length, Is.EqualTo(0));
        }

        [Test]
        public void InsertAtHead_AddsElementToHead()
        {
            var list = new LinkedList<int>();
            list.InsertAtHead(10);
            Assert.That(list.Head, Is.Not.Null);
            Assert.That(list.Head.Data, Is.EqualTo(10));
            Assert.That(list.Length, Is.EqualTo(1));
        }

        [Test]
        public void InsertAtTail_AddsElementToTail()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(5);
            list.InsertAtTail(15);
            Assert.That(list.Length, Is.EqualTo(2));
            Assert.That(list.Head?.Data, Is.EqualTo(5));
            Assert.That(list.Head?.Next?.Data, Is.EqualTo(15));
        }

        [Test]
        public void InsertAtPosition_AddsElementAtCorrectPosition()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(1);
            list.InsertAtTail(3);
            list.InsertAtPosition(2, 1);
            Assert.That(list.ToString(), Is.EqualTo("[1, 2, 3]"));
            Assert.That(list.Length, Is.EqualTo(3));
        }

        [Test]
        public void DeleteAtHead_RemovesHead()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(1);
            list.InsertAtTail(2);
            list.DeleteAtHead();
            Assert.That(list.Length, Is.EqualTo(1));
            Assert.That(list.Head?.Data, Is.EqualTo(2));
        }

        [Test]
        public void DeleteAtTail_RemovesTail()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(1);
            list.InsertAtTail(2);
            list.DeleteAtTail();
            Assert.That(list.Length, Is.EqualTo(1));
            Assert.That(list.Head?.Next, Is.Null);
        }

        [Test]
        public void DeleteAtPosition_RemovesCorrectElement()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(1);
            list.InsertAtTail(2);
            list.InsertAtTail(3);
            list.InsertAtTail(4);
            list.InsertAtTail(5);
            list.DeleteAtPosition(4);
            Assert.That(list.ToString(), Is.EqualTo("[1, 2, 3, 4]"));
            Assert.That(list.Length, Is.EqualTo(4));
        }

        [Test]
        public void ToArray_ReturnsCorrectArray()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(1);
            list.InsertAtTail(2);
            var arr = list.ToArray();
            CollectionAssert.AreEqual(new int[] { 1, 2 }, arr);
        }

        [Test]
        public void Contains_ReturnsTrueIfElementExists()
        {
            var list = new LinkedList<string>();
            list.InsertAtTail("a");
            Assert.That(list.Contains("a"), Is.True);
            Assert.That(list.Contains("b"), Is.False);
        }

        [Test]
        public void Clear_EmptiesTheList()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(1);
            list.Clear();
            Assert.That(list.Length, Is.EqualTo(0));
            Assert.That(list.Head, Is.Null);
        }

        [Test]
        public void ToString_ReturnsCorrectFormat()
        {
            var list = new LinkedList<int>();
            Assert.That(list.ToString(), Is.EqualTo("[]"));
            list.InsertAtTail(1);
            list.InsertAtTail(2);
            Assert.That(list.ToString(), Is.EqualTo("[1, 2]"));
        }

        [Test]
        public void Reverse_ReturnsReversedList()
        {
            var list = new LinkedList<int>();
            list.InsertAtTail(1);
            list.InsertAtTail(2);
            list.InsertAtTail(3);
            var reversed = list.Reverse();
            Assert.That(reversed.ToString(), Is.EqualTo("[3, 2, 1]"));
            Assert.That(list.ToString(), Is.EqualTo("[1, 2, 3]")); // original unchanged
        }

        [Test]
        public void InsertAtPosition_ThrowsOnInvalidPosition()
        {
            var list = new LinkedList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAtPosition(1, -1));
            Assert.Throws<ArgumentOutOfRangeException>(() => list.InsertAtPosition(1, 1));
        }

        [Test]
        public void DeleteAtPosition_ThrowsOnInvalidPosition()
        {
            var list = new LinkedList<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => list.DeleteAtPosition(0));
            list.InsertAtTail(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => list.DeleteAtPosition(1));
        }

        [Test]
        public void DeleteAtHead_ThrowsOnEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.DeleteAtHead());
        }

        [Test]
        public void DeleteAtTail_ThrowsOnEmptyList()
        {
            var list = new LinkedList<int>();
            Assert.Throws<InvalidOperationException>(() => list.DeleteAtTail());
        }
    }
}