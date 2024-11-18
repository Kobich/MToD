using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class LabWorkTests2
{
    [TestClass]
    public class UnitTest1
    {
        // Тестирование функции Min
        [TestMethod]
        public void TestMin_FirstIsMin()
        {
            int a = 1, b = 3, c = 2;
            int expected = 1;
            int result = MToD.MTod_lab2.min(a, b, c);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMin_SecondIsMin()
        {
            int a = 3, b = 1, c = 2;
            int expected = 1;
            int result = MToD.MTod_lab2.min(a, b, c);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestMin_ThirdIsMin()
        {
            int a = 3, b = 2, c = 1;
            int expected = 1;
            int result = MToD.MTod_lab2.min(a, b, c);
            Assert.AreEqual(expected, result);
        }

        // Тестирование функции Sum
        [TestMethod]
        public void TestSum()
        {
            double[,] A = { { 3.56, 4.22, 43.90 }, { 11.05, 0.07, 12.46 }, { 17.89, 16.02,
                             45.33 } };
            double expected = 110.75;
            double result = MToD.MTod_lab2.sum(A);
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void TestMax()
        {
            double[,] A = { { 3.56, 4.22, 43.90 }, { 11.05, 0.07, 12.46 }, { 17.89, 16.02,
                            45.33 } };
            double expected = 45.33;
            double result = MToD.MTod_lab2.max(A);
            Assert.AreEqual(expected, result);
        }
    }
}
