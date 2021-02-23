using System;
namespace Algorithms
{
    class SelectionSort : SortingAlgorithm
    { 
    public override void sort(int[] array, int size)
        {
            int smallest, i, j;


            for (i = 0; i < size; i++)
            {
                smallest = i;
                for (j = i; j < size; j++)
                {
                    if (array[j] < array[smallest])
                        smallest = j;
                }
                swap(ref array[i], ref array[smallest]);
            }
        }
    }
}
