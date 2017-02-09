using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimpleArrayList.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "List is full")]
        public void ThrowsIndexOutOfRange()
        {
            var list = new SimpleArrayList<int>(1);
            list.Add(1);
            list.Add(2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "index 1 is out of range")]
        public void GetThrowsIndexOutOfRange()
        {
            var list = new SimpleArrayList<int>(1);
            list.Get(1);
        }

        [TestMethod]
        public void ReturnsDataAtIndex()
        {
            var list = new SimpleArrayList<int>(1);
            list.Add(2);
            Assert.AreEqual(list.Get(0), 2);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "index 1 is out of range")]
        public void SetThrowsIndexOutOfRange()
        {
            var list = new SimpleArrayList<int>(1);
            list.Set(1, 1);
        }

        [TestMethod]
        public void SetsDataAtIndex()
        {
            var list = new SimpleArrayList<int>(2);
            list.Set(1, 2);
            Assert.AreEqual(2, list.Get(1));
        }

        [TestMethod]
        public void ToStringReturnsCommaSeparated()
        {
            var list = new SimpleArrayList<int>(2);
            list.Add(1);
            list.Add(2);

            Assert.AreEqual("1,2", list.ToString());
        }

        [TestMethod]
        public void ToStringReturnsOnlySetValues()
        {
            var list = new SimpleArrayList<int>(4);
            list.Add(1);
            list.Add(2);

            Assert.AreEqual("1,2", list.ToString());
        }

        [TestMethod]
        public void ClearArray()
        {
            var list = new SimpleArrayList<int>(2);
            list.Add(3);
            list.Add(4);

            Assert.AreEqual("3,4", list.ToString());

            list.Clear();

            Assert.AreEqual("", list.ToString());
        }

        [TestMethod]
        public void CountOccurencesReturnsCorrectNumber()
        {
            var list = new SimpleArrayList<int>(3);
            list.Add(1);
            list.Add(3);
            list.Add(1);

            Assert.AreEqual(2, list.CountOccurences(1));
        }
    }
}
