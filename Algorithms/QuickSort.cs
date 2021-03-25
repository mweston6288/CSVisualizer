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
            StackSize++;
            if (low < high)
            {
                int split = partition(low, high);

                quickSort(low, split - 1);
                quickSort(split + 1, high);
            }
            StackSize--;

        }

        int partition(int low, int high)
        {
            int i, lowPosition;
            if (low >= high)
                return low;

            i = Array[low];
            lowPosition = low;
            low++;

            while (low <= high)
            {
                while (low <= high && Array[low] <= Array[lowPosition])
                    low++;

                while (high >= low && Array[high] > Array[lowPosition])
                    high--;
                if (low < high)
                {
                    swap(ref Array[low], ref Array[high]);
                }
            }

            // Finally we swap the pivot with the point high was pointing to
            swap(ref Array[lowPosition], ref Array[high]);

            return high;
        }

        public override void sort()
        {
            quickSort(0, Size - 1);
        }
    }
}
