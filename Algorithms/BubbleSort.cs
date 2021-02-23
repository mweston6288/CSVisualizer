namespace Algorithms
{
    class BubbleSort : SortingAlgorithm
    {
        public BubbleSort(int size) :base(size)
        {
            
        }


        public override void sort()
        {
            int i, j;
            for (i = 0; i < size; i++)
            {
                for (j = 0; j < size - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
}
