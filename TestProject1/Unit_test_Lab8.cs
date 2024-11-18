using Microsoft.VisualStudio.TestTools.UnitTesting;
using MToD;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestOperationsFrac()
        {
            Proc<Frac> processor = new Proc<Frac>(new Frac(1, 3), new Frac(1, 3));
            processor.OperationSet(1);
            processor.OperationRun();
            var otvet = new Frac(2, 3);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
            processor.OperationSet(2);
            processor.OperationRun();
            otvet = new Frac(1, 3);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
            processor.OperationSet(3);
            processor.OperationRun();
            otvet = new Frac(1, 9);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
            processor.OperationSet(4);
            processor.OperationRun();
            otvet = new Frac(1, 3);
            Assert.AreEqual(otvet.Denominator, processor.Lop_Res.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Lop_Res.Numerator);
        }

        [TestMethod]
        public void TestFunctionsFrac()
        {
            Proc<Frac> processor = new Proc<Frac>(new Frac(1, 3), new Frac(1, 3));
            processor.FunctionSet(1);
            processor.FunctionRun();
            var otvet = new Frac(3, 1);
            Assert.AreEqual(otvet.Denominator, processor.Rop.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Rop.Numerator);
            processor.FunctionSet(2);
            processor.FunctionRun();
            otvet = new Frac(9, 1);
            Assert.AreEqual(otvet.Denominator, processor.Rop.Denominator);
            Assert.AreEqual(otvet.Numerator, processor.Rop.Numerator);
        }

        [TestMethod]
        public void TestOperationsInt()
        {
            Proc<int> processor = new Proc<int>(2, 5);
            processor.OperationSet(1);
            processor.OperationRun();
            Assert.AreEqual(7, processor.Lop_Res);
            processor.OperationSet(2);
            processor.OperationRun();
            Assert.AreEqual(2, processor.Lop_Res);
            processor.OperationSet(3);
            processor.OperationRun();
            Assert.AreEqual(10, processor.Lop_Res);
            processor.OperationSet(4);
            processor.OperationRun();
            Assert.AreEqual(2, processor.Lop_Res);
        }

        [TestMethod]
        public void TestFunctionsInt()
        {
            Proc<int> processor = new Proc<int>(2, 1);
            processor.FunctionSet(1);
            processor.FunctionRun();
            Assert.AreEqual(1, processor.Rop);
            processor.FunctionSet(2);
            processor.FunctionRun();
            Assert.AreEqual(1, processor.Rop);
        }

        [TestMethod]
        public void TestClearProcessor()
        {
            // Проверка очистки процессора
            Proc<Frac> processor = new Proc<Frac>(new Frac(1, 2), new Frac(1, 2));
            processor.OperationSet(1); // Установка операции сложения
            processor.OperationRun(); // Выполнение операции
            Assert.AreNotEqual(new Frac(1, 2), processor.Lop_Res); // Результат сложения не должен быть равен исходному значению

            processor.ProcessorClear(); // Очистка процессора

            // После очистки, результат должен быть равен исходным значениям
            Assert.AreEqual(new Frac(0, 1), processor.Lop_Res);
            Assert.AreEqual(new Frac(0, 1), processor.Rop);
            Assert.AreEqual(EOperation.None, processor.Operation);
            Assert.AreEqual(EFunction.None, processor.Function);
        }

        [TestMethod]
        public void TestInvalidOperationSet()
        {
            Proc<Frac> processor = new Proc<Frac>();
            Assert.ThrowsException<ArgumentException>(() => processor.OperationSet(100)); // некорректный код операции
        }

        [TestMethod]
        public void TestInvalidFunctionSet()
        {
            Proc<Frac> processor = new Proc<Frac>();
            Assert.ThrowsException<ArgumentException>(() => processor.FunctionSet(100)); // некорректный код функции
        }

        [TestMethod]
        public void TestDivideByZero()
        {
            Proc<Frac> processor = new Proc<Frac>(new Frac(1, 2), new Frac(0, 1));
            processor.OperationSet(4); // Деление
            Assert.ThrowsException<DivideByZeroException>(() => processor.OperationRun());
        }
    }
}

