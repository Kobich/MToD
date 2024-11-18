using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using MToD;
using System.Reflection.Emit;

namespace UnitTest1
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    namespace UnitTest1
    {
        [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void Construcor_TFrac_isEmpty()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                Assert.AreEqual(true, a.IsEmpty());
            }

            [TestMethod]
            public void TSet_TFrac_insert()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                a.Insert(new TFrac(1, 2));
                Assert.AreEqual("1/2", a.ElementAt(0).GetFractionString());
            }

            [TestMethod]
            public void TSet_TFrac_clear()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                a.Insert(new TFrac(1, 2));
                a.Clear();
                Assert.AreEqual(true, a.IsEmpty());
            }

            [TestMethod]
            public void TSet_TFrac_del()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                a.Insert(new TFrac(1, 2));
                a.Delete(new TFrac(1, 2));
                Assert.AreEqual(true, a.IsEmpty());
            }

            [TestMethod]
            public void TSet_TFrac_belong()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                a.Insert(new TFrac(1, 2));
                Assert.AreEqual(true, a.IsBelong(new TFrac(1, 2)));
            }

            [TestMethod]
            public void TSet_TFrac_el_1()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                string expected = "1/2";
                a.Insert(new TFrac(1, 2));
                Assert.AreEqual(expected, a.ElementAt(0).GetFractionString());
            }

            [TestMethod]
            public void TSet_TFrac_el_2()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                string expected = "4/3";
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(4, 3));
                Assert.AreEqual(expected, a.ElementAt(1).GetFractionString());
            }

            [TestMethod]
            public void TSet_TFrac_el_3_invalid()
            {
                Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                {
                    TSet<TFrac> a = new TSet<TFrac>();
                    a.Insert(new TFrac(1, 2));
                    a.Insert(new TFrac(4, 3));
                    var b = a.ElementAt(8).GetFractionString();
                });
            }

            [TestMethod]
            public void TSet_TFrac_union_1()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";
                a.Insert(new TFrac(1, 2));
                b.Insert(new TFrac(3, 4));
                c = a.Union(b);
                for (int i = 0; i < c.Count(); i++)
                {
                    result += c.ElementAt(i).GetFractionString() + " ";
                }
                result = result.Trim();
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_TFrac_union_2()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";
                a.Insert(new TFrac(1, 2));
                b.Insert(new TFrac(3, 4));
                c = a.Union(b);
                result = $"{c.ElementAt(0).GetFractionString()} {c.ElementAt(1).GetFractionString()}";
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_TFrac_union_3()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 2/3 3/4 4/5";
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(2, 3));
                b.Insert(new TFrac(3, 4));
                b.Insert(new TFrac(4, 5));
                c = a.Union(b);
                result = $"{c.ElementAt(0).GetFractionString()} {c.ElementAt(1).GetFractionString()} {c.ElementAt(2).GetFractionString()} {c.ElementAt(3).GetFractionString()}";
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_TFrac_union_4()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4 4/5";
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(3, 4));
                b.Insert(new TFrac(3, 4));
                b.Insert(new TFrac(4, 5));
                c = a.Union(b);
                result = $"{c.ElementAt(0).GetFractionString()} {c.ElementAt(1).GetFractionString()} {c.ElementAt(2).GetFractionString()}";
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_TFrac_sub_1()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(3, 4));
                a.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(8, 1));
                c = a.Subtract(b);
                for (int i = 0; i < c.Count(); i++)
                {
                    result += c.ElementAt(i).GetFractionString() + " ";
                }
                result = result.Trim();
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_TFrac_sub_2()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(3, 4));
                a.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(8, 1));
                c = a.Subtract(b);
                result = $"{c.ElementAt(0).GetFractionString()} {c.ElementAt(1).GetFractionString()}";
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_TFrac_multy_1()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(3, 4));
                a.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(1, 2));
                b.Insert(new TFrac(3, 4));
                b.Insert(new TFrac(8, 8));
                c = a.Intersection(b);
                for (int i = 0; i < c.Count(); i++)
                {
                    result += c.ElementAt(i).GetFractionString() + " ";
                }
                result = result.Trim();
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_TFrac_multy_2()
            {
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(3, 4));
                a.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(1, 2));
                b.Insert(new TFrac(3, 4));
                b.Insert(new TFrac(8, 8));
                c = a.Intersection(b);
                result = $"{c.ElementAt(0).GetFractionString()} {c.ElementAt(1).GetFractionString()}";
                Assert.AreEqual(expected, result);
            }

            // Аналогичные методы для `TSet<int>`
            [TestMethod]
            public void Construcor_int_isEmpty()
            {
                TSet<int> a = new TSet<int>();
                Assert.AreEqual(true, a.IsEmpty());
            }

            [TestMethod]
            public void TSet_int_insert()
            {
                TSet<int> a = new TSet<int>();
                a.Insert(1);
                Assert.AreEqual(1, a.ElementAt(0));
            }

            [TestMethod]
            public void TSet_Delete_TFrac()
            {
                // Arrange
                TSet<TFrac> a = new TSet<TFrac>();

                // Act
                a.Insert(new TFrac(1, 2));
                a.Delete(new TFrac(1, 2));

                // Assert
                Assert.AreEqual(true, a.IsEmpty());
            }

            [TestMethod]
            public void TSet_IsBelong_TFrac()
            {
                // Arrange
                TSet<TFrac> a = new TSet<TFrac>();

                // Act
                a.Insert(new TFrac(1, 2));

                // Assert
                Assert.IsTrue(a.IsBelong(new TFrac(1, 2)));
            }

            [TestMethod]
            public void TSet_ElementAt_ValidIndex_TFrac()
            {
                // Arrange
                TSet<TFrac> a = new TSet<TFrac>();
                string expected = "1/2";

                // Act
                a.Insert(new TFrac(1, 2));

                // Assert
                Assert.AreEqual(expected, a.ElementAt(0).GetFractionString());
            }

            [TestMethod]
            public void TSet_ElementAt_SecondIndex_TFrac()
            {
                // Arrange
                TSet<TFrac> a = new TSet<TFrac>();
                string expected = "4/3";

                // Act
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(4, 3));

                // Assert
                Assert.AreEqual(expected, a.ElementAt(1).GetFractionString());
            }

            [TestMethod]
            public void TSet_ElementAt_InvalidIndex_TFrac()
            {
                // Assert
                Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                {
                    // Arrange
                    TSet<TFrac> a = new TSet<TFrac>();

                    // Act
                    a.Insert(new TFrac(1, 2));
                    a.Insert(new TFrac(4, 3));
                    string b = a.ElementAt(8).GetFractionString();
                });
            }

            [TestMethod]
            public void TSet_Union_TFrac()
            {
                // Arrange
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";

                // Act
                a.Insert(new TFrac(1, 2));
                b.Insert(new TFrac(3, 4));
                c = a.Union(b);

                foreach (var frac in Enumerable.Range(0, c.Count()).Select(c.ElementAt))
                {
                    result += frac.GetFractionString() + " ";
                }

                result = result.Trim();

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_Subtract_TFrac()
            {
                // Arrange
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";

                // Act
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(3, 4));
                a.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(8, 1));
                c = a.Subtract(b);

                foreach (var frac in Enumerable.Range(0, c.Count()).Select(c.ElementAt))
                {
                    result += frac.GetFractionString() + " ";
                }

                result = result.Trim();

                // Assert
                Assert.AreEqual(expected, result);
            }

            [TestMethod]
            public void TSet_Intersection_TFrac()
            {
                // Arrange
                TSet<TFrac> a = new TSet<TFrac>();
                TSet<TFrac> b = new TSet<TFrac>();
                TSet<TFrac> c;
                string result = "";
                string expected = "1/2 3/4";

                // Act
                a.Insert(new TFrac(1, 2));
                a.Insert(new TFrac(3, 4));
                a.Insert(new TFrac(5, 8));
                b.Insert(new TFrac(1, 2));
                b.Insert(new TFrac(3, 4));
                b.Insert(new TFrac(8, 8));
                c = a.Intersection(b);

                foreach (var frac in Enumerable.Range(0, c.Count()).Select(c.ElementAt))
                {
                    result += frac.GetFractionString() + " ";
                }

                result = result.Trim();

                // Assert
                Assert.AreEqual(expected, result);
            }

        }
    }

}
