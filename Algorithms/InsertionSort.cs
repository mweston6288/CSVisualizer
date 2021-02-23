namespace Algorithms
{

    class InsertionSort : SortingAlgorithm
    {
        public InsertionSort(int size) : base(size)
        {
        }

        public override void sort()
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