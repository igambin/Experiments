namespace CodingInterview.Interfaces
{
    public interface IArrayManipulation
    {
        T[] RotateArrayRightGivenAPivot<T>(T[] array, int p);
        T[] RotateArrayLeftGivenAPivot<T>(T[] array, int p);
        bool DetermineIfAnyTwoIntegersInArraySumToGivenInteger(int[] array, int sum);
        T[] SortAnArrayInDescendingOrder<T>(T[] array);
        T[] ReverseAnArray<T>(T[] array);
        T FindMajorityElementInAnUnsortedArray<T>(T[] array);
        T[] MergeTwoSortedArraysIntoOne<T>(T[] array1, T[] array2);
        int HowToFindMissingNumberInIntegerArrayOf1To100(int[] array);
        int[] SwapMinAndMaxElementInIntegerArray(int[] array);
        int[] MoveZerosToEndOfArray(int[] array);
        bool HowToCheckIfArrayContainsADuplicateNumber(int[] array);
    }
}