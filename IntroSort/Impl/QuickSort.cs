namespace IntroSort
{
    public static class QuickSort
    {
        public static void Sort(int[] array)
        {
            Sort(array, 0, array.Length - 1);
        }

        public static void Sort(int[] array, int low, int high)
        {
            if (low >= high) return;


            var pivotIndex = Partition(array, low, high);

            Sort(array, low, pivotIndex - 1);
            Sort(array, pivotIndex + 1, high);
        }


        public static int Partition(int[] array, int low, int high)
        {

            var pivot = high;
            var i = low; // everything before this index is smaller than the pivot

            for (int j = low; j < high; j++)
            {
                if (array[j] < array[high])
                {
                    //Swap i with j
                    SortHelper.Swap(array, i, j);
                    i++;
                }
            }

            //place pivot at i
            SortHelper.Swap(array, pivot, i);

            return i; //return final pivot position

        }
    }
}
