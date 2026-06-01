
namespace IntroSort
{
    public static class IntroSort
    {
        public static void Sort(int[] array)
        {
            var depthLimit = (int)(2 * Math.Log2(array.Length));
            Sort(array, 0, array.Length - 1, depthLimit);
        }

        public static void Sort(int[] array, int low, int high, int depthLimit)
        {
            var size = high - low + 1;

            // small array optimization
            if (size <= 16)
            {
                InsertionSort.Sort(array, low, high);
                return;
            }


            if (depthLimit == 0)
            {
                //Console.WriteLine("Switching to Heap Sort " + GetArrayString(array, low, high));

                HeapSort.Sort(array, low, high);
                return;
            }

            //Console.WriteLine("Conntinueing Quick Sort. Depth: " + depthLimit + " " + GetArrayString(array, low, high));
            var pivotIndex = QuickSort.Partition(array, low, high);

            Sort(array, low, pivotIndex - 1, depthLimit - 1);
            Sort(array, pivotIndex + 1, high, depthLimit - 1);
        }
    }
}
