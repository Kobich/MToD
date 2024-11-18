using System;
using MToD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComplexTEdit
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Init_And_Output_1()
        {
            Editor testClass = new Editor();
            string output = "10,3+i*0,8";
            testClass.WriteNumber(output);
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void Init_And_Output_2()
        {
            Editor testClass = new Editor();
            string output = "-12,6-i*66,2";
            testClass.WriteNumber(output);
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void Init_And_Output_3()
        {
            Editor testClass = new Editor();
            string output = "0,3+i*0,0";
            testClass.WriteNumber(output);
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void IsZero_1()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,36+i*12,35");
            Assert.IsFalse(testClass.IsZero());
        }

        [TestMethod]
        public void IsZero_2()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("0,+i*0,");
            Assert.IsTrue(testClass.IsZero());
        }

        [TestMethod]
        public void ToggleMinus_1()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,36+i*12,35");
            testClass.ToggleMinus();
            string output = "-12,36+i*12,35";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void ToggleMinus_2()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("-12,36+i*12,35");
            testClass.ToggleMinus();
            string output = "12,36+i*12,35";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void ToggleMinus_ImaginaryPart()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,36+i*12,35");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.ToggleMinus();
            string output = "12,36-i*12,35";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]

        public void ToggleMinusonMinus_ImaginaryPart()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,36-i*12,35");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.ToggleMinus();
            string output = "12,36+i*12,35";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
 
        public void AddNumber_Real_Left_WithoutSeparator()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("0,+i*0,");
            testClass.AddNumber(3);
            string output = "3,+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_Real_Left_WithSeparator_NoSign()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,+i*0,");
            testClass.AddNumber(4);
            string output = "124,+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_Real_Right()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,3+i*0,");
            testClass.ToggleNumberMode(); // Переключаемся на правую часть
            testClass.AddNumber(6);
            string output = "12,36+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_Imaginary_Left()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,+i*0,");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.AddNumber(9);
            string output = "12,+i*9,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_Imaginary_Right()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,+i*0,3");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.ToggleNumberMode(); // Переключаемся на правую часть
            testClass.AddNumber(7);
            string output = "12,+i*0,37";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_Real_Left_StartingWithZero()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("0,+i*0,");
            testClass.AddNumber(5);
            string output = "5,+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_Imaginary_Left_StartingWithZero()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,+i*0,");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.AddNumber(6);
            string output = "12,+i*6,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_Imaginary_WithSeparator()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,+i*12,3");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.ToggleNumberMode(); // Переключаемся на правую часть
            testClass.AddNumber(8);
            string output = "12,+i*12,38";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void AddNumber_InvalidNumber()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,+i*0,");
            testClass.AddNumber(10); // Invalid number
            string output = "12,+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Real_Left()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("55,55-i*3,3");
            testClass.DelNumber();
            string output = "5,55-i*3,3";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Real_Left_Zero()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("0,55-i*3,3");
            testClass.DelNumber();
            string output = "0,55-i*3,3";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Imaginary_StartingWithZero()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,+i*0,");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.DelNumber();
            string output = "12,+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }


        [TestMethod]
        public void DelNumber_Real_Left_Minus()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("-55,55-i*3,3");
            testClass.DelNumber();
            string output = "-5,55-i*3,3";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Real_Right()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,36-i*0,3");
            testClass.ToggleNumberMode(); // Переключаемся на правую часть
            testClass.DelNumber();
            string output = "12,3-i*0,3";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Imaginary_Left()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,36+i*44,4");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.DelNumber();
            string output = "12,36+i*4,4";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Real_Left_WithMinus()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("-123,+i*0,");
            testClass.DelNumber();
            string output = "-12,+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Imaginary_Right()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,36+i*12,45");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.ToggleNumberMode(); // Переключаемся на правую часть
            testClass.DelNumber();
            string output = "12,36+i*12,4";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Imaginary_Right_WithMinus()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("12,-i*12,35");
            testClass.ToggleMode(); // Переключаемся на мнимую часть
            testClass.ToggleNumberMode(); // Переключаемся на правую часть
            testClass.DelNumber();
            string output = "12,-i*12,3";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void DelNumber_Real_Right_WithMinus()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("-12,36+i*0,3");
            testClass.ToggleNumberMode(); // Переключаемся на правую часть
            testClass.DelNumber();
            string output = "-12,3+i*0,3";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void Clear_1()
        {
            Editor testClass = new Editor();
            testClass.WriteNumber("55,55-i*3,3");
            testClass.Clear();
            string output = "0,+i*0,";
            Assert.AreEqual(output, testClass.ReadNumber());
        }

        [TestMethod]
        public void ToggleMode_Test()
        {
            Editor testClass = new Editor();
            PartToEdit mode = testClass.ToggleMode();
            Assert.AreEqual(PartToEdit.Imag, mode);
            mode = testClass.ToggleMode();
            Assert.AreEqual(PartToEdit.Real, mode);
        }

        [TestMethod]
        public void ToggleNumberMode_Test()
        {
            Editor testClass = new Editor();
            NumberPartToEdit numberMode = testClass.ToggleNumberMode();
            Assert.AreEqual(NumberPartToEdit.Right, numberMode);
            numberMode = testClass.ToggleNumberMode();
            Assert.AreEqual(NumberPartToEdit.Left, numberMode);
        }
    }
}
