using System.Collections.Generic;
using System.Linq;
using CodingInterview.Interfaces;

namespace CodingInterview.Solutions
{
    public class ArrayManipulation : IArrayManipulation
    {

        public T[] RotateArrayRightGivenAPivot<T>(T[] array, int p) => RotateArrayGivenAPivot(array, p, Direction.Right);

        public T[] RotateArrayLeftGivenAPivot<T>(T[] array, int p) => RotateArrayGivenAPivot(array, p);

        #region Rotation-Helpers
        private enum Direction { Left, Right }
        private static T[] RotateArrayGivenAPivot<T>(IReadOnlyCollection<T> array, int p, Direction direction = Direction.Left)
        {
            p = p % array.Count;
            var newFirstPart = array.Skip(direction == Direction.Right ? array.Count - p : p);
            var newSecondPart = array.Take(direction == Direction.Right ? array.Count - p : p);
            return newFirstPart.Union(newSecondPart).ToArray();
        }
        #endregion

        public bool DetermineIfAnyTwoIntegersInArraySumToGivenInteger(int[] array, int sum)
        {
            bool found = false;
            var arrayList = array.ToList();
            arrayList.ForEach(
                x =>
                {
                    if (!found)
                    {
                        var idx = arrayList.IndexOf(x);
                        var arrayList2 = array.ToList();
                        arrayList2.RemoveAt(idx);
                        if (arrayList2.Any(y => y + x == sum))
                        {
                            found = true;
                        }
                    }
                });
            return found;
        }

        public T[] SortAnArrayInDescendingOrder<T>(T[] array) => array.OrderByDescending(x => x).ToArray();

        public T[] ReverseAnArray<T>(T[] array) => array.Reverse().ToArray();

        public T FindMajorityElementInAnUnsortedArray<T>(T[] array)
        {
            var groups = array.GroupBy(x => x);
            var enumerable = groups as IList<IGrouping<T, T>> ?? groups.ToList();
            var maxgroups = enumerable.Where(x => x.Count() == enumerable.Max(y => y.Count()));
            return maxgroups.First().Key;
        }

        public T[] MergeTwoSortedArraysIntoOne<T>(T[] array1, T[] array2) => array1.Union(array2).OrderBy(x => x).ToArray();

        public int HowToFindMissingNumberInIntegerArrayOf1To100(int[] array)
        {
            var i = Enumerable.Range(1, 100).FirstOrDefault(x => !array.Contains(x));
            return i;
        }

        public int[] SwapMinAndMaxElementInIntegerArray(int[] array)
        {
            var arrayList = array.ToList();
            var minIdx = arrayList.IndexOf(array.Min());
            var maxIdx = arrayList.IndexOf(array.Max());
            var tmp = array[minIdx];
            array[minIdx] = array[maxIdx];
            array[maxIdx] = tmp;
            return array;
        }

        public int[] MoveZerosToEndOfArray(int[] array)
        {
            var arrayList = array.ToList();
            var zeroCount = arrayList.RemoveAll(x => x == 0);
            Enumerable.Range(1, zeroCount).ToList().ForEach(x => arrayList.Add(0));
            return arrayList.ToArray();
        }

        public bool HowToCheckIfArrayContainsADuplicateNumber(int[] array)
        {
            var groups = array.GroupBy(x => x);
            return groups.Any(x => x.Count() > 1);
        }

    }
}
