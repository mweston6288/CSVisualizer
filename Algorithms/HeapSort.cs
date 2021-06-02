using System;
namespace Algorithms
{
    class HeapSort : SortingAlgorithm
    {
        int i, parent, child, left, right, bound;
        bool isHeap, percolateNeeded;
        public HeapSort(int size) : base(size)
        {
            child = i = 1;
            parent = 0;
            isHeap = false;

        }
        // Run a single step in HeapSort
        public void next()
        {
            if (i <= 0)
            {
                Console.WriteLine("Sorted");
                throw new Exception();
            }

            // Step 1: make a heap
            if (!isHeap)
            {
                heapifyNext();
                return;
            }

            // Step 2: swap Array[0] with Array[i]
            // Set up for percolate after
            if (!percolateNeeded)
            {
                swap(ref Array[0], ref Array[i]);
                percolateNeeded = true;
                parent = 0;
                bound = i;
                i--;
            }
            // Step 3: Percolate Array[0] down
            else
            {
                if (parent < bound)
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
                            else
                            {
                                percolateNeeded = false;
                                return;
                            }
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
                            else
                            {
                                percolateNeeded = false;
                                return;
                            }
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
                        percolateNeeded = false;
                        return;
                    }
                    // Parent has no children
                    else
                    {
                        percolateNeeded = false;
                        return;
                    }
                }
                else
                    percolateNeeded = false;
            }
        }
        // Run a single step in Heapify
        private void heapifyNext()
        {
            // do a single loop of percolation
            if (Array[child] > Array[parent])
            {
                swap(ref Array[child], ref Array[parent]);
                child = parent;
                parent = (child - 1) / 2;
            }
            // If previous condition was false, that means we'd start the for loop over
            else
            {
                i++;
                // Check if the for-loop would end
                // Setup values for sorting
                if (i >= Size)
                {
                    isHeap = true;
                    percolateNeeded = false;
                    Console.WriteLine("Heaped");
                    i = Size - 1;
                    return;
                }
                child = i;
                parent = (child - 1) / 2;
            }
        }


        public override void sort()
        {
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
