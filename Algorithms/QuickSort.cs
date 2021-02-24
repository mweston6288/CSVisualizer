using System;
namespace Algorithms
{
    class QuickSort : SortingAlgorithm
    {
        public QuickSort(int size) :base(size)
        {
        }
        void quickSort(int low, int high)
        {
            if (low < high)
            {
                int split = partition(low, high);

                quickSort(low, split - 1);
                quickSort(split + 1, high);
            }
        }

        int partition(int low, int high)
        {
            int i, lowPosition;
            if (low >= high)
                return low;

            i = array[low];
            lowPosition = low;
            low++;

            while (low <= high)
            {
                while (low <= high && array[low] <= array[lowPosition])
                    low++;

                while (high >= low && array[high] > array[lowPosition])
                    high--;
                if (low < high)
                {
                    swap(ref array[low], ref array[high]);
                }
            }

            // Finally we swap the pivot with the point high was pointing to
            swap(ref array[lowPosition], ref array[high]);

            return high;
        }

        public override void sort()
        {
            quickSort(0, size - 1);
        }
    }
}
