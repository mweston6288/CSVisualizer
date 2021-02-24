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
            for(i = size - 1; i > 0; i--)
            {
                swap(ref array[0], ref array[i]);
                Percolate(i);
            }
        }
        // convert to a max heap
        private void Heapify()
        {
            int i, parent, child;
            for (i = 1; i < size; i++)
            {
                child = i;
                parent = (i - 1) / 2;
                while (array[child] > array[parent])
                {
                    swap(ref array[child], ref array[parent]);
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
                    if (array[right] > array[left])
                    {
                        // swap right child if greater than parent
                        if (array[right] > array[parent])
                        {
                            swap(ref array[parent], ref array[right]);
                            parent = right;
                        }
                        // If parent is greater than right, then it's greater than left too
                        else return;
                    }
                    // left child is the greater child
                    else
                    {
                        // swap left child if greater than parent
                        if (array[left] > array[parent])
                        {
                            swap(ref array[parent], ref array[left]);
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
                    if (array[left] > array[parent])
                    {
                        swap(ref array[parent], ref array[left]);
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
