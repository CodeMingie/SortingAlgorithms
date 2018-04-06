using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting
{
    [TestClass]
    public class UnitTest1
    {
        //Average O(n^2)
        [TestMethod]
        public void TestSelectionSort()
        {
            int[] unsorted = { 63, 20, 40, 21, 96, 34, 2, 91, 51, 34 };
            int[] sorted = { 2, 20, 21, 34, 34, 40, 51, 63, 91, 96 };

            SelectionSort(unsorted);

            this.AssetArraysEqual(unsorted, sorted);
        }

        public void SelectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int min = arr[i];
                int minIndex = i;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < min)
                    {
                        min = arr[j];
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    arr[minIndex] = arr[i];
                    arr[i] = min;
                }
            }
        }

        //Average O(n log n)
        [TestMethod]
        public void TestMergeSort()
        {
            int[] unsorted = { 63, 20, 40, 21, 96, 34, 2, 91, 51, 34 };
            int[] sorted = { 2, 20, 21, 34, 34, 40, 51, 63, 91, 96 };

            unsorted = MergeSort(unsorted);

            this.AssetArraysEqual(unsorted, sorted);
        }

        public int[] MergeSort(int[] arr1)
        {
            if (arr1.Length == 1)
                return arr1;

            int[] left = new int[arr1.Length / 2];

            for (int i = 0; i < arr1.Length / 2; i++)
                left[i] = arr1[i];

            int[] right = new int[arr1.Length - left.Length];

            int index = 0;
            for (int i = arr1.Length/2; i < arr1.Length; i++)
            { 
                right[index] = arr1[i];
                index++;
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private int[] Merge(int[] left, int [] right)
        {
            int[] merged = new int[left.Length + right.Length];
            int leftIndex = 0;
            int rightIndex = 0;

            for (int index = 0; index < merged.Length; index++)
            {
                if (leftIndex >= left.Length)
                {
                    merged[index] = right[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= right.Length)
                {
                    merged[index] = left[leftIndex];
                    leftIndex++;
                }
                else if (left[leftIndex] < right[rightIndex])
                {
                    merged[index] = left[leftIndex];
                    leftIndex++;
                }
                else
                { 
                    merged[index] = right[rightIndex];
                    rightIndex++;
                }
            }

            return merged;
        }

        //Average O(n^2)
        [TestMethod]
        public void TestBubbleSort()
        {
            int[] unsorted = { 63, 20, 40, 21, 96, 34, 2, 91, 51, 34 };
            int[] sorted = { 2, 20, 21, 34, 34, 40, 51, 63, 91, 96 };

            BubbleSort(unsorted);

            this.AssetArraysEqual(unsorted, sorted);
        }

        public void BubbleSort(int[] arr)
        {
            bool isSorted = false;

            while (!isSorted)
            {
                isSorted = true;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        isSorted = false;
                    }
                }
            }
        }

        //Average O(n log n)
        [TestMethod]
        public void TestQuickSort()
        {
            int[] unsorted = { 63, 20, 40, 21, 96, 34, 2, 91, 51, 34 };
            int[] sorted = { 2, 20, 21, 34, 34, 40, 51, 63, 91, 96 };

            QuickSort(unsorted, 0, 9);

            this.AssetArraysEqual(unsorted, sorted);
        }

        public void QuickSort(int[] arr, int lo, int hi)
        {
            if (lo < hi)
            {
                int pivotIndex = Partition(arr, lo, hi);

                QuickSort(arr, lo, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, hi);
            }
        }

        private int Partition(int[] arr, int lo, int hi)
        {
            int pivot = arr[hi];

            int i = (lo - 1);

            for (int j = lo; j < hi; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    int lessThanPivot = arr[j];
                    arr[j] = arr[i];
                    arr[i] = lessThanPivot;
                }
            }

            arr[hi] = arr[i + 1];
            arr[i + 1] = pivot;
            
            return (i + 1);
        }

        private void AssetArraysEqual(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
                Assert.AreEqual(arr1[i], arr2[i]);
        }
    }
}
