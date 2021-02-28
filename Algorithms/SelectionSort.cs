using System;
namespace Algorithms
{
    class SelectionSort : SortingAlgorithm
    {
        public SelectionSort(int size) : base(size)
        {
        }

        public override void sort()
        {
            int smallest, i, j;


            for (i = 0; i < Size; i++)
            {
                StackSize++;

                smallest = i;
                for (j = i; j < Size; j++)
                {
                    if (Array[j] < Array[smallest])
                        smallest = j;
                }
                swap(ref Array[i], ref Array[smallest]);
                StackSize--;

            }
        }
    }
}
