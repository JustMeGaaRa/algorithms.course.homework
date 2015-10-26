namespace discnt
{
    public static class Arrays
    {
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

        public static void MergeSort(int[] array)
        {
            int[] mergeArray = new int[array.Length];
            InternalMergeSort(array, mergeArray, 0, array.Length - 1);
        }

        private static void InternalMergeSort(int[] array, int[] mergeArray, int begin, int end)
        {
            if (begin < end)
            {
                int middle = (begin + end) / 2;
                InternalMergeSort(array, mergeArray, begin, middle);
                InternalMergeSort(array, mergeArray, middle + 1, end);
                Merge(array, mergeArray, begin, middle + 1, end);
            }
        }

        private static void Merge(int[] array, int[] mergeArray, int begin, int middle, int end)
        {
            int firstBegin = begin;
            int firstEnd = middle - 1;
            int secondBegin = middle;
            int mergeIndex = begin;

            while (firstBegin <= firstEnd && secondBegin <= end)
            {
                if (IsLesser(array[firstBegin], array[secondBegin]))
                {
                    mergeArray[mergeIndex] = array[firstBegin];
                    firstBegin++;
                }
                else
                {
                    mergeArray[mergeIndex] = array[secondBegin];
                    secondBegin++;
                }

                mergeIndex++;
            }

            while (firstBegin <= firstEnd)
            {
                mergeArray[mergeIndex] = array[firstBegin];
                mergeIndex++;
                firstBegin++;
            }

            while (secondBegin <= end)
            {
                mergeArray[mergeIndex] = array[secondBegin];
                mergeIndex++;
                secondBegin++;
            }

            for (int i = begin; i <= end; i++)
            {
                array[i] = mergeArray[i];
            }
        }
    }
}