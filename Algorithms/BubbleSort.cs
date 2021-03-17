using System;

namespace Algorithms
{
    class BubbleSort : SortingAlgorithm
    {
        class AlgorithmCompleteException: Exception { }
        int comparisons;
        int i, j;
        public BubbleSort(int size) :base(size)
        {
            comparisons = 0;
            i = 0;
            j = 0;

        }

        public void next()
        {
            if (i >= Size)
            {
                throw new AlgorithmCompleteException();
            }
            if (i < Size)
            {
                if (j < Size - 1 - i)
                {
                    if (++comparisons > 0 && Array[j] > Array[j + 1])
                    {
                        swap(ref Array[j], ref Array[j + 1]);
                    }
                    j++;
                }
                else
                {
                    i++;
                    if (i >= Size)
                    {
                        throw new AlgorithmCompleteException();
                    }
                    else
                    {
                        j = 0;
                        if (++comparisons > 0 && Array[j] > Array[j + 1])
                        {
                            swap(ref Array[j], ref Array[j + 1]);
                        }
                        j++;
                    }
                }
            }
        }
        public override void sort()
        {
            for (i = 0; i < Size; i++)
            {
                for (j = 0; j < Size - 1 - i; j++)
                {
                    if (++comparisons > 0 && Array[j] > Array[j + 1])
                    {
                        swap(ref Array[j], ref Array[j + 1]);
                    }
                }
            }
        }
    }
}
