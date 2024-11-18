using Microsoft.VisualStudio.TestTools.UnitTesting;
using MToD;
using System;

namespace MemoryApp.Tests
{
    [TestClass]
    public class TMemoryTests
    {
        [TestMethod]
        public void TestStore()
        {
            TMemory<int> memory = new TMemory<int>();
            memory.Store(42);
            Assert.AreEqual(42, memory.GetNumber());
            Assert.AreEqual(MemoryState.On, memory.GetMemoryState());
        }

        [TestMethod]
        public void TestAdd()
        {
            TMemory<int> memory = new TMemory<int>();
            memory.Store(10);
            memory.Add(5);
            Assert.AreEqual(15, memory.GetNumber());
        }

        [TestMethod]
        public void TestClear()
        {
            TMemory<int> memory = new TMemory<int>();
            memory.Store(100);
            memory.Clear();
            Assert.AreEqual(MemoryState.Off, memory.GetMemoryState());
            Assert.ThrowsException<InvalidOperationException>(() => memory.GetNumber());
        }

        [TestMethod]
        public void TestAddWhenMemoryOff()
        {
            TMemory<int> memory = new TMemory<int>();
            Assert.ThrowsException<InvalidOperationException>(() => memory.Add(10));
        }

        [TestMethod]
        public void TestGetNumberWhenMemoryOff()
        {
            TMemory<int> memory = new TMemory<int>();
            Assert.ThrowsException<InvalidOperationException>(() => memory.GetNumber());
        }

        [TestMethod]
        public void TestStoreAndClearWithDouble()
        {
            TMemory<double> memory = new TMemory<double>();
            memory.Store(42.5);
            Assert.AreEqual(42.5, memory.GetNumber());
            memory.Clear();
            Assert.AreEqual(MemoryState.Off, memory.GetMemoryState());
        }

        [TestMethod]
        public void TestAddWithDouble()
        {
            TMemory<double> memory = new TMemory<double>();
            memory.Store(10.5);
            memory.Add(2.5);
            Assert.AreEqual(13.0, memory.GetNumber());
        }

        [TestMethod]
        public void TestStoreFraction()
        {
            TMemory<Fraction> memory = new TMemory<Fraction>();
            Fraction fraction = new Fraction(1, 2);
            memory.Store(fraction);
            Assert.AreEqual(fraction, memory.GetNumber());
            Assert.AreEqual(MemoryState.On, memory.GetMemoryState());
        }

        [TestMethod]
        public void TestAddFraction()
        {
            TMemory<Fraction> memory = new TMemory<Fraction>();
            Fraction fraction1 = new Fraction(1, 2);
            Fraction fraction2 = new Fraction(1, 3);
            memory.Store(fraction1);
            memory.Add(fraction2);
            Fraction expected = new Fraction(5, 6);
            Assert.AreEqual(expected, memory.GetNumber());
        }

        [TestMethod]
        public void TestClearFraction()
        {
            TMemory<Fraction> memory = new TMemory<Fraction>();
            memory.Store(new Fraction(3, 4));
            memory.Clear();
            Assert.AreEqual(MemoryState.Off, memory.GetMemoryState());
            Assert.ThrowsException<InvalidOperationException>(() => memory.GetNumber());
        }

        [TestMethod]
        public void TestAddWhenMemoryOffFraction()
        {
            TMemory<Fraction> memory = new TMemory<Fraction>();
            Assert.ThrowsException<InvalidOperationException>(() => memory.Add(new Fraction(1, 2)));
        }

        [TestMethod]
        public void TestAddNull()
        {
            TMemory<Fraction> memory = new TMemory<Fraction>();
            Fraction fraction = new Fraction(1, 2);

            memory.Store(fraction);
            Assert.ThrowsException<ArgumentNullException>(() => memory.Add(null));
        }
    }
}
