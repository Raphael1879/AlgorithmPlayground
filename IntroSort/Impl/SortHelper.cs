using System.Text;

namespace IntroSort
{
    public static class SortHelper
    {
        public static void Swap(int[] array, int index1, int index2)
        {
            var i1Value = array[index1];
            array[index1] = array[index2];
            array[index2] = i1Value;
        }

        public static string GetArrayString(int[] array, int low, int high)
        {
            var res = new StringBuilder("[");

            for (int i = low; i <= high; i++)
            {
                res.Append(array[i]);

                if (i != high)
                    res.Append(",");
            }

            res.Append("]");
            return res.ToString();
        }
    }
}
