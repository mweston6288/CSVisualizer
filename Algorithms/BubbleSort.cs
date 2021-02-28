namespace Algorithms
{
    class BubbleSort : SortingAlgorithm
    {
        public BubbleSort(int size) :base(size)
        {
            
        }


        public override void sort()
        {
            StackSize++;
            int i, j;
            for (i = 0; i < Size; i++)
            {
                for (j = 0; j < Size - 1 - i; j++)
                {
                    if (Array[j] > Array[j + 1])
                    {
                        swap(ref Array[j], ref Array[j + 1]);
                    }
                }
            }
            StackSize--;
        }
    }
}
