using Microsoft.VisualStudio.TestTools.UnitTesting;
using MToD; 

namespace TestProject9
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TMember_Constructor_1_getDegree()
        {
            TMember a = new TMember();
            Assert.AreEqual(0, a.GetDegree());
        }

        [TestMethod]
        public void TMember_Constructor_1_getCoef()
        {
            TMember a = new TMember();
            Assert.AreEqual(0, a.GetCoef());
        }

        [TestMethod]
        public void TMember_Constructor_2_getDegree()
        {
            TMember a = new TMember(2, 3);
            Assert.AreEqual(3, a.GetDegree());
        }

        [TestMethod]
        public void TMember_Constructor_2_getCoef()
        {
            TMember a = new TMember(2, 3);
            Assert.AreEqual(2, a.GetCoef());
        }

        [TestMethod]
        public void TMember_SetCoef()
        {
            TMember a = new TMember(2, 3);
            a.SetCoef(4);
            Assert.AreEqual(4, a.GetCoef());
        }

        [TestMethod]
        public void TMember_SetDegree()
        {
            TMember a = new TMember(2, 3);
            a.SetDegree(4);
            Assert.AreEqual(4, a.GetDegree());
        }

        [TestMethod]
        public void TMember_IsEqual_True()
        {
            TMember a = new TMember(2, 3);
            TMember b = new TMember(2, 3);
            Assert.IsTrue(a.IsEqual(b));
        }

        [TestMethod]
        public void TMember_IsEqual_False()
        {
            TMember a = new TMember(2, 3);
            TMember b = new TMember(4, 3);
            Assert.IsFalse(a.IsEqual(b));
        }

        [TestMethod]
        public void TMember_Diff()
        {
            TMember a = new TMember(2, 3);
            string expected = "6*x^2";
            TMember b = a.Diff();
            Assert.AreEqual(expected, b.GetString());
        }

        [TestMethod]
        public void TMember_Calculate()
        {
            TMember a = new TMember(2, 3);
            int result = a.Calculate(2);
            Assert.AreEqual(16, result);
        }

        [TestMethod]
        public void TMember_GetString()
        {
            TMember a = new TMember(2, 3);
            string expected = "2*x^3";
            Assert.AreEqual(expected, a.GetString());
        }

        [TestMethod]
        public void TPoly_MaxDegree()
        {
            TPoly a = new TPoly(2, 3);
            Assert.AreEqual(3, a.MaxDegree());
        }

        [TestMethod]
        public void TPoly_MaxDegree_2()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            TPoly c = a.Add(b);
            Assert.AreEqual(5, c.MaxDegree());
        }

        [TestMethod]
        public void TPoly_DegreeCoef_Exist_1()
        {
            TPoly a = new TPoly(2, 3);
            Assert.AreEqual(2, a.DegreeCoef(3));
        }

        [TestMethod]
        public void TPoly_DegreeCoef_Exist_2()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            TPoly c = a.Add(b);
            Assert.AreEqual(4, c.DegreeCoef(5));
        }

        [TestMethod]
        public void TPoly_DegreeCoef_Zero()
        {
            TPoly a = new TPoly(2, 3);
            Assert.AreEqual(0, a.DegreeCoef(5));
        }

        [TestMethod]
        public void TPoly_Clear()
        {
            TPoly a = new TPoly(2, 3);
            a.Clear();
            Assert.AreEqual(0, a.Calculate(1));
        }

        [TestMethod]
        public void TPoly_Add_1()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            string expected = "2*x^3 4*x^5";
            TPoly c = a.Add(b);
            Assert.AreEqual(expected, c.GetString());
        }

        [TestMethod]
        public void TPoly_Add_2()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(2, 3);
            string expected = "4*x^3";
            TPoly c = a.Add(b);
            Assert.AreEqual(expected, c.GetString());
        }

        [TestMethod]
        public void TPoly_Add_3()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(-8, 6);
            TPoly f = new TPoly(4, 5);
            TPoly d = new TPoly(5, 6);
            string expected = "4*x^5 -3*x^6 2*x^3";
            TPoly c = a.Add(b);
            TPoly e = f.Add(d);
            TPoly g = e.Add(c);
            Assert.AreEqual(expected, g.GetString());
        }

        [TestMethod]
        public void TPoly_Multy()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            string expected = "8*x^8";
            TPoly c = a.Multy(b);
            Assert.AreEqual(expected, c.GetString());
        }

        [TestMethod]
        public void TPoly_Multy_2()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(2, 3);
            TPoly f = new TPoly(4, 5);
            TPoly d = new TPoly(5, 6);
            string expected = "16*x^8 20*x^9";
            TPoly c = a.Add(b);//4x^3
            TPoly e = f.Add(d);//4x^5 5x^6
            TPoly g = e.Multy(c);
            Assert.AreEqual(expected, g.GetString());
        }

        [TestMethod]
        public void TPoly_Sub_1()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            string expected = "2*x^3 -4*x^5";
            TPoly c = a.Sub(b);
            Assert.AreEqual(expected, c.GetString());
        }

        [TestMethod]
        public void TPoly_Sub_2()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(2, 3);
            string expected = "0*x^0";
            TPoly c = a.Sub(b);
            Assert.AreEqual(expected, c.GetString());
        }

        [TestMethod]
        public void TPoly_Sub_3()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(-8, 6);
            TPoly f = new TPoly(4, 5);
            TPoly d = new TPoly(5, 6);
            string expected = "4*x^5 13*x^6 -2*x^3";
            TPoly c = a.Add(b);
            TPoly e = f.Add(d);
            TPoly g = e.Sub(c);
            Assert.AreEqual(expected, g.GetString());
        }

        [TestMethod]
        public void TPoly_Negative_1()
        {
            TPoly a = new TPoly(2, 3);
            string expected = "-2*x^3";
            TPoly c = a.Negative();
            Assert.AreEqual(expected, c.GetString());
        }

        [TestMethod]
        public void TPoly_IsEqual_1()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            TPoly c = new TPoly(6, 7);
            TPoly d = c.Add(b);
            Assert.IsFalse(a.IsEqual(d));
        }

        [TestMethod]
        public void TPoly_IsEqual_2()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            Assert.IsFalse(a.IsEqual(b));
        }

        [TestMethod]
        public void TPoly_IsEqual_3()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(2, 3);
            Assert.IsTrue(a.IsEqual(b));
        }

        [TestMethod]
        public void TPoly_IsEqual_4()
        {
            TPoly a = new TPoly(2, 3);
            TPoly b = new TPoly(4, 5);
            TPoly c = new TPoly(6, 7);
            TPoly d = c.Add(b);
            Assert.IsTrue(d.IsEqual(c.Add(b)));
        }
    }
}
