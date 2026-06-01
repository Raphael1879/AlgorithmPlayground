namespace IntroSort
{
    public static class HeapSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        public static void Sort(int[] arr, int low, int high)
        {
            int size = high - low + 1;

            // Build max heap
            for (int i = low + size / 2 - 1; i >= low; i--)
            {
                Heapify(arr, size, i, low);
            }

            // Extract elements one by one
            for (int i = high; i > low; i--)
            {
                SortHelper.Swap(arr, low, i);
                Heapify(arr, i - low, low, low);
            }
        }


        public static void Heapify(int[] arr, int size, int i, int offset)
        {
            int largest = i;
            int left = 2 * (i - offset) + 1 + offset;
            int right = 2 * (i - offset) + 2 + offset;

            // left child
            if (left < offset + size && arr[left] > arr[largest])
                largest = left;

            // right child
            if (right < offset + size && arr[right] > arr[largest])
                largest = right;

            // swap if needed
            if (largest != i)
            {
                SortHelper.Swap(arr, i, largest);
                Heapify(arr, size, largest, offset);
            }
        }

    }
}
