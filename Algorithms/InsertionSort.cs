namespace Algorithms
{

    class InsertionSort : SortingAlgorithm
    {
        public InsertionSort(int size) : base(size)
        {
        }

        public override void sort()
        {
            StackSize++;
            int i, j, k;

            for (i = 1; i < Size; i++)
            {
                k = Array[i];

                for (j = i - 1; j >= 0; j--)
                {
                    if (k < Array[j])
                    {
                        Array[j + 1] = Array[j];
                    }
                    else
                        break;
                }
                Array[j + 1] = k;
            }
            StackSize--;

        }
    }
}