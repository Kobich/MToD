using Microsoft.VisualStudio.TestTools.UnitTesting;
using MToD;

[TestClass]
public class LabWorkTests_3
{
    [TestClass]
    public class UnitTest1
    {
            [TestMethod]
            public void TestMaxNumber_test1()
            {
                int a = 7, b = 2, c = 3;
                int expected = 7;
                int result = MTod_lab3.MaxNumber(a, b, c);
                Assert.AreEqual(expected, result);
            }
            [TestMethod]
            public void TestMaxNumber_test2()
            {
                int a = -7, b = 2, c = -3;
                int expected = 2;
                int result = MTod_lab3.MaxNumber(a, b, c);
                Assert.AreEqual(expected, result);
            }
            [TestMethod]
            public void TestMaxNumber_test3()
            {
                int a = -7, b = 2, c = 3;
                int expected = 3;
                int result = MTod_lab3.MaxNumber(a, b, c);
                Assert.AreEqual(expected, result);
            }
            [TestMethod]
            public void TestMulOfOddInd_test1()
            {
                double[,] mas = { { 1, 2, 3.5 }, { 4.2, 5, 6.7 } };
                double expected = 17.5;
                double result = MTod_lab3.MultOfOddInd(mas);
                Assert.AreEqual(expected, result);
            }
            [TestMethod]
            public void TestMulOfOddInd_test2()
            {
                double[,] mas = { { 1, 300002, 1 }, { 300002, 1, 300002 } };
                double expected = 1;
                double result = MTod_lab3.MultOfOddInd(mas);
                Assert.AreEqual(expected, result);
            }
            [TestMethod]
            public void TestMinElemDiag_test1()
            {
                double[,] mas = { { 1.6, 2, -2.4 }, { 0.15, 1.5, 15 }, { 0.54, -0.3, 5.42 }
};
                double expected = -0.3;
                double result = MTod_lab3.MinElemDiag(mas);
                Assert.AreEqual(expected, result);
            }
            [TestMethod]
            public void TestMinElemDiag_test2()
            {
                double[,] mas = { { 1.6, 2, -2.4 }, { 0.15, 1.5, -150 }, { 0.54, 0.3, 5.42 }
};
                double expected = 0.15;
                double result = MTod_lab3.MinElemDiag(mas);
                Assert.AreEqual(expected, result);
            }
        }
    }