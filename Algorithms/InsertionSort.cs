/*
	Insertion Sort
*/

﻿namespace Algorithms
{

    class InsertionSort : SortingAlgorithm
    {
        public override void sort(int[] array, int size)
        {
            int i, j, k;

            for (i = 1; i < size; i++)
            {
                k = array[i];

                for (j = i - 1; j >= 0; j--)
                {
                    if (k < array[j])
                    {
                        array[j + 1] = array[j];
                    }
                    else
                        break;
                }
                array[j + 1] = k;
            }
        }
    }
}
