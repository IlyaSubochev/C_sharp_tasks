using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortSpace;
using System;
using System.Collections.Generic;

namespace Algo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        #region Сортировка вставками
        [TestMethod]
        public void InsertionSortStepSingle1()
        {
            //arrange
            int[] array = new int[] { 0, 0, 1, 0, 0 };
            int[] expected = new int[] { 0, 0, 0, 1, 0 };

            //act
            SortLevel.InsertionSortStep(array, 1, 2);

            //assert
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(expected[i], array[i]);
        }

        [TestMethod]
        public void InsertionSortStepSingle2()
        {
            //arrange
            int[] array = new int[] { 7, 4, 1, 3, 2 };
            int[] expected = new int[] { 2, 4, 1, 3, 7 };

            //act
            SortLevel.InsertionSortStep(array, 4, 0);

            //assert
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(expected[i], array[i]);
        }

        [TestMethod]
        public void InsertionSortStepSingle3()
        {
            //arrange
            int[] array = new int[] { 8, 4, 5, 11, 2, 1 };
            int[] expected = new int[] { 5, 4, 8, 11, 2, 1 };

            //act
            SortLevel.InsertionSortStep(array, 2, 0);

            //assert
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(expected[i], array[i]);
        }

        [TestMethod]
        public void InsertionSortStepSingle4()
        {
            //arrange
            int[] array = new int[] { 5, 4, 3, 2, 1 };
            int[] expected = new int[] { 4, 5, 3, 2, 1 };

            //act
            SortLevel.InsertionSortStep(array, 1, 0);

            //assert
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(expected[i], array[i]);
        }

        [TestMethod]
        public void InsertionSortStepSingle5()
        {
            //arrange
            int[] array = new int[] { 3, 2, 1, 5, 4 };
            int[] expected = new int[] { 2, 3, 1, 5, 4 };

            //act
            SortLevel.InsertionSortStep(array, 1, 0);

            //assert
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(expected[i], array[i]);
        }

        [TestMethod]
        public void InsertionSortStepSingle6()
        {
            //arrange
            int[] array = new int[] { 1, 6, 5, 4, 3, 2, 7 };
            int[] expected = new int[] { 1, 3, 5, 4, 6, 2, 7 };

            //act
            SortLevel.InsertionSortStep(array, 3, 1);

            //assert
            for (int i = 0; i < array.Length; i++)
                Assert.AreEqual(expected[i], array[i]);
        }

        #endregion

        #region Сортировка Шелла

 

        #endregion
    }
}
