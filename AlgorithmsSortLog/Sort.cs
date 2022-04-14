using System;
using System.Collections.Generic;


namespace AlgorithmsSortLog
{
    public class Sort
    {
        private static void Swap(int[] array, int i, int j)
        {
            int swap = array[i];
            array[i] = array[j];
            array[j] = swap;
        }
        // -------- Алгоритмы устойчивой сортировки --------
        // Сортировка слиянием
        public static void Merge(int[] array)
        {
            Mergesort(array, 0, array.Length - 1);
            void Mergesort(int[] arr, int low, int high)
            {
                if (low < high)
                {
                    int mid = (low + high) / 2;
                    Mergesort(arr, low, mid);
                    Mergesort(arr, mid + 1, high);
                    if (arr[mid] > arr[mid + 1])
                        Copy(arr, low, mid, high);

                }
            }
            void Copy(int[] arr, int low, int mid, int high)
            {
                int i = low, j = mid + 1, k = 0;
                int[] temp = new int[high - low + 1];
                while ((i <= mid) && (j <= high))
                    if (arr[i] < arr[j])
                        temp[k++] = arr[i++];
                    else
                        temp[k++] = arr[j++];
                while (j <= high)
                    temp[k++] = arr[j++];
                while (i <= mid)
                    temp[k++] = arr[i++];
                // копировать temp [] в arr []
                for (i = low, k = 0; i <= high; i++, k++)
                    arr[i] = temp[k];
            }
        }
        // -------- Алгоритмы неустойчивой сортировки --------
        // Пирамидальная сортировка
        public static void Heap(int[] array)
        {
            int lenght = array.Length - 1, index = lenght / 2;
            while (index >= 0)
            {
                Heapify(array, lenght, index);
                index--;
            }
            index = lenght;
            while (index >= 0)
            {
                Swap(array, 0, index);
                Heapify(array, index, 0);
                index--;
            }
        }
        private static void Heapify(int[] array, int n, int index)
        {
            int largest = index,
            left = 2 * index + 1,
            right = 2 * index + 2;
            if (left < n && array[left] > array[largest])
                largest = left;
            if (right < n && array[right] > array[largest])
                largest = right;
            if (largest != index)
            {
                Swap(array, index, largest);
                Heapify(array, n, largest);
            }
        }
        // Быстрая сортировка
        public static void Quick(int[] array)
        {
            Quicksort(array, 0, array.Length - 1);
            void Quicksort(int[] array, int start, int end)
            {
                if (start >= end)
                {
                    return;
                }
                int pivot = Partition(array, start, end);
                Quicksort(array, start, pivot - 1);
                Quicksort(array, pivot + 1, end);
            }
        }
        private static int Partition(int[] array, int start, int end)
        {
            int marker = start, index = start;
            while (index <= end)
            {
                if (array[index] <= array[end])
                {
                    Swap(array, marker, index);
                    marker++;
                }
                index++;
            }
            return marker - 1;
        }
    }
}
