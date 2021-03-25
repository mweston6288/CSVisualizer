using System;
namespace Algorithms
{
    class HeapSort : SortingAlgorithm
    {
        public HeapSort(int size) : base(size)
        {

        }

        public override void sort()
        {
            int i;
            Heapify();
            for(i = Size - 1; i > 0; i--)
            {
                swap(ref Array[0], ref Array[i]);
                Percolate(i);
            }
        }
        // convert to a max heap
        private void Heapify()
        {
            int i, parent, child;
            for (i = 1; i < Size; i++)
            {
                child = i;
                parent = (i - 1) / 2;
                while (Array[child] > Array[parent])
                {
                    swap(ref Array[child], ref Array[parent]);
                    child = parent;
                    parent = (child - 1) / 2;
                }
            }
            print();
        }
        private void Percolate(int bound)
        {
            int left, right, parent = 0;
            while (parent < bound)
            {
                left = parent * 2 + 1;
                right = parent * 2 + 2;

                // both children are in bound
                if (right < bound)
                {
                    // right child is the greater child
                    if (Array[right] > Array[left])
                    {
                        // swap right child if greater than parent
                        if (Array[right] > Array[parent])
                        {
                            swap(ref Array[parent], ref Array[right]);
                            parent = right;
                        }
                        // If parent is greater than right, then it's greater than left too
                        else return;
                    }
                    // left child is the greater child
                    else
                    {
                        // swap left child if greater than parent
                        if (Array[left] > Array[parent])
                        {
                            swap(ref Array[parent], ref Array[left]);
                            parent = left;
                        }
                        // If parent is greater than left, then it's greater than right too
                        else return;
                    }
                }
                // only left child is in bound
                else if (left < bound)
                {
                    // swap left child if greater than parent
                    if (Array[left] > Array[parent])
                    {
                        swap(ref Array[parent], ref Array[left]);
                    }
                    // This scenario can only happen if you're at the end of bound, so we can just return
                    return;
                }
                // Parent has no children
                else
                    return;
            }

        }
    }
}
