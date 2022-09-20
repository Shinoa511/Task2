using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp11;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SumLines_ASC1()
        {
            int[,] arr = new int[,] { { 1, 5, 3 }, { 2, 4, 6 }, { 3, 6, 5 } };
            Context context = new Context();
            context.SetSortType(new Sort_SumLines());
            Assert.AreEqual("{1, 5, 3} {2, 4, 6} {3, 6, 5} ", ToStr(context.ExecuteSortingASC(arr)));
        }

        [TestMethod]
        public void SumLines_DESC()
        {
            int[,] arr = new int[,] { { 1, 5, 3 }, { 2, 4, 6 }, { 3, 6, 5 } };

            Context context = new Context();
            context.SetSortType(new Sort_SumLines());
            Assert.AreEqual("{3, 6, 5} {2, 4, 6} {1, 5, 3} ", ToStr(context.ExecuteSortingDESC(arr)));
        }

        [TestMethod]
        public void SumLines_ASC2()
        {
            int[,] arr = new int[,] { { 2, 1, 5, 7, 3, 4, 6 },
                                      { 5, 9, 5, 8, 6, 8, 2 },
                                      { 5, 1, 7, 2, 9, 4, 6 }};

            Context context = new Context();
            context.SetSortType(new Sort_SumLines());
            Assert.AreEqual("{2, 1, 5, 7, 3, 4, 6} {5, 1, 7, 2, 9, 4, 6} {5, 9, 5, 8, 6, 8, 2} ", ToStr(context.ExecuteSortingASC(arr)));
        }

        [TestMethod]
        public void MaxElement_ASC1()
        {
            int[,] arr = new int[,] { { 1, 5, 3 }, { 2, 4, 7 }, { 3, 6, 5 } };

            Context context = new Context();
            context.SetSortType(new Sort_MaxElement());
            Assert.AreEqual("{1, 5, 3} {3, 6, 5} {2, 4, 7} ", ToStr(context.ExecuteSortingASC(arr)));
        }

        [TestMethod]
        public void MaxElement_DESC()
        {
            int[,] arr = new int[,] { { 1, 5, 3 }, { 2, 4, 7 }, { 3, 6, 5 } };

            Context context = new Context();
            context.SetSortType(new Sort_MaxElement());
            Assert.AreEqual("{2, 4, 7} {3, 6, 5} {1, 5, 3} ", ToStr(context.ExecuteSortingDESC(arr)));
        }

        [TestMethod]
        public void MaxElement_ASC2()
        {
            int[,] arr = new int[,] { { 2, 1, 5, 7, 3, 4, 10 },
                                      { 5, 9, 5, 8, 6, 8, 2 },
                                      { 5, 1, 7, 2, 9, 4, 6 }};

            Context context = new Context();
            context.SetSortType(new Sort_MaxElement());
            Assert.AreEqual("{5, 9, 5, 8, 6, 8, 2} {5, 1, 7, 2, 9, 4, 6} {2, 1, 5, 7, 3, 4, 10} ", ToStr(context.ExecuteSortingASC(arr)));
        }

        [TestMethod]
        public void MinElement_ASC()
        {
            int[,] arr = new int[,] { { 2, 1, 5, 7, 3, 4, 6 },
                                      { 5, 9, 5, 8, 6, 8, 2 },
                                      { 5, 1, 7, 2, 9, 4, 6 }};

            Context context = new Context();
            context.SetSortType(new Sort_MinElement());
            Assert.AreEqual("{2, 1, 5, 7, 3, 4, 6} {5, 1, 7, 2, 9, 4, 6} {5, 9, 5, 8, 6, 8, 2} ", ToStr(context.ExecuteSortingASC(arr)));
        }

        [TestMethod]
        public void MinElement_DESC()
        {
            int[,] arr = new int[,] { { 1, 5, 3 }, { 2, 4, 7 }, { 3, 6, 5 } };

            Context context = new Context();
            context.SetSortType(new Sort_MinElement());
            Assert.AreEqual("{3, 6, 5} {2, 4, 7} {1, 5, 3} ", ToStr(context.ExecuteSortingDESC(arr)));
        }

        public string ToStr(int[,] result_arr)
        {
            string s = "";
            for (int i = 0; i != result_arr.GetLength(0); i++)
            {
                s = s + '{';
                for (int j = 0; j != result_arr.GetLength(1); j++)
                {
                    s = s + result_arr[i, j];
                    if (j != result_arr.GetLength(1) - 1)
                        s = s + ',' + ' ';
                }
                s = s + "} ";

            }
            return s;
        }

    }
}
