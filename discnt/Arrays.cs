namespace discnt
{
    public static class Arrays
    {
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIdex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (IsLesser(array[j], array[minIdex]))
                    {
                        minIdex = j;
                    }
                }

                Swap(array, i, minIdex);
            }
        }

        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (IsLesser(array[j], array[j - 1]))
                    {
                        Swap(array, j, j - 1);
                    }
                }
            }
        }

        public static void BubbleSort(int[] array)
        {
            bool somethingSwapped = true;

            while (somethingSwapped)
            {
                somethingSwapped = false;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (IsLesser(array[i + 1], array[i]))
                    {
                        Swap(array, i, i + 1);
                        somethingSwapped = true;
                    }
                }
            }
        }

        public static bool IsLesser(int left, int right)
        {
            return left < right;
        }

        public static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}