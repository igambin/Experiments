using System;
using CodingInterview.Interfaces;
using NUnit.Framework;

namespace CodingInterview.Tests
{
    public partial class CodingInterviewTests
    {
        [TestFixture]
        public class ArrayManipulationTests
        {
            private readonly IArrayManipulation _arrayManipulationWorker = new Solutions.ArrayManipulation();

            [Test]
            public void RotateArrayLeftToAGivenPivotImplementedException()
            {
                int[] task = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] expected = { 5, 6, 7, 8, 9, 1, 2, 3, 4 };
                int[] result = _arrayManipulationWorker.RotateArrayLeftGivenAPivot(task, 4);
                CollectionAssert.AreEqual(expected, result);

            }

            [Test]
            public void RotateArrayRightToAGivenPivotImplementedException()
            {
                int[] task = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] expected = { 6, 7, 8, 9, 1, 2, 3, 4, 5 };
                int[] result = _arrayManipulationWorker.RotateArrayRightGivenAPivot(task, 4);
                CollectionAssert.AreEqual(expected, result);

            }

            [Test]
            public void DetermineIfAnyTwoIntegersInArraySumToGivenInteger_123456789_17_True()
            {
                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Assert.IsTrue(_arrayManipulationWorker.DetermineIfAnyTwoIntegersInArraySumToGivenInteger(array, 17));
            }

            [Test]
            public void DetermineIfAnyTwoIntegersInArraySumToGivenInteger_123456789_18_False()
            {
                int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Assert.IsFalse(_arrayManipulationWorker.DetermineIfAnyTwoIntegersInArraySumToGivenInteger(array, 18));
            }

            [Test]
            public void DetermineIfAnyTwoIntegersInArraySumToGivenInteger_129456789_18_True()
            {
                int[] array = { 1, 2, 9, 4, 5, 6, 7, 8, 9 };
                Assert.IsTrue(_arrayManipulationWorker.DetermineIfAnyTwoIntegersInArraySumToGivenInteger(array, 18));
            }

            [Test]
            public void SortAnArrayInDescendingOrder()
            {
                int[] task = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] expected = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                int[] result = _arrayManipulationWorker.SortAnArrayInDescendingOrder(task);
                CollectionAssert.AreEqual(expected, result);
            }

            [Test]
            public void ReverseAnArray()
            {
                int[] task = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] expected = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
                int[] result = _arrayManipulationWorker.ReverseAnArray(task);
                CollectionAssert.AreEqual(expected, result);
            }

            [Test]
            public void FindMajorityElementInAnUnsortedArray_Simple()
            {
                int[] task = { 1, 2, 3, 4, 5, 6, 6, 7, 8, 9 };
                int result = _arrayManipulationWorker.FindMajorityElementInAnUnsortedArray(task);
                Assert.AreEqual(6, result);
            }

            [Test]
            public void FindMajorityElementInAnUnsortedArray_Complex()
            {
                int[] task = { 1, 3, 3, 4, 5, 6, 6, 7, 8, 8, 8, 9, 9, 9 };
                int result = _arrayManipulationWorker.FindMajorityElementInAnUnsortedArray(task);
                Assert.AreEqual(8, result);
            }

            [Test]
            public void MergeTwoSortedArraysIntoOne()
            {
                int[] task1 = { 2, 4, 6, 8 };
                int[] task2 = { 1, 3, 5, 7, 9 };
                int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] result = _arrayManipulationWorker.MergeTwoSortedArraysIntoOne(task1, task2);
                CollectionAssert.AreEqual(expected, result);
            }

            [Test]
            public void HowToFindMissingNumberInIntegerArrayOf1To100()
            {
                int[] task = {
                     1,  2,  3,  4,  5,  6,  7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                    21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
                    41, 42, 43,     45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60,
                    61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80,
                    81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };
                int result = _arrayManipulationWorker.HowToFindMissingNumberInIntegerArrayOf1To100(task);
                Assert.AreEqual(44, result);

            }

            [Test]
            public void SwapMinAndMaxElementInIntegerArray()
            {
                int[] task = { 9, 2, 3, 4, 5, 6, 7, 8, 1 };
                int[] expected = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int[] result = _arrayManipulationWorker.SwapMinAndMaxElementInIntegerArray(task);
                CollectionAssert.AreEqual(expected, result);
            }

            [Test]
            public void MoveZerosToEndOfArray()
            {
                int[] task = { 1, 0, 3, 0, 5, 0, 7, 0, 9 };
                int[] expected = { 1, 3, 5, 7, 9, 0, 0, 0, 0 };
                int[] result = _arrayManipulationWorker.MoveZerosToEndOfArray(task);
                CollectionAssert.AreEqual(expected, result);
            }

            [Test]
            public void HowToCheckIfArrayContainsADuplicateNumber_True()
            {
                int[] task = { 1, 2, 3, 4, 5, 5, 6, 7, 8, 9 };
                Assert.IsTrue(_arrayManipulationWorker.HowToCheckIfArrayContainsADuplicateNumber(task));
            }

            [Test]
            public void HowToCheckIfArrayContainsADuplicateNumber_False()
            {
                int[] task = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                Assert.IsFalse(_arrayManipulationWorker.HowToCheckIfArrayContainsADuplicateNumber(task));
            }
        }
    }

    [TestFixture]
    public class RotateTests
    {
        [Test]
        public void TestRotation()
        {
            int[] task = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] result = RotateArrayRight.Rotate(task, 4);
            Console.WriteLine(string.Join(", ", result));
        }
    }

    public static class RotateArrayRight
    {
        //Rotate array to the right of a given pivot
        public static int[] Rotate(int[] x, int pivot)
        {
            if (pivot < 0 || x == null)
                throw new Exception("Invalid argument");

            pivot = pivot % x.Length;

            //Rotate first half
            x = RotateSub(x, 0, pivot - 1);

            //Rotate second half
            x = RotateSub(x, pivot, x.Length - 1);

            //Rotate all
            x = RotateSub(x, 0, x.Length - 1);

            return x;
        }

        private static int[] RotateSub(int[] x, int start, int end)
        {
            while (start < end)
            {
                int temp = x[start];
                x[start] = x[end];
                x[end] = temp;
                start++;
                end--;
            }
            return x;
        }
    }
}
