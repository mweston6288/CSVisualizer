using System;
namespace Algorithms
{
    class QuickSort : SortingAlgorithm
    {
        public QuickSort(int size) : base(size)
        {
           head = new QuickSortPartition(0, size - 1);

        }
        void quickSort(int low, int high)
        {
            StackSize++;
            if (low < high)
            {
                int split = partition(low, high);

                quickSort(low, split - 1);
                quickSort(split + 1, high);
            }
            StackSize--;

        }

        int partition(int low, int high)
        {
            int i, lowPosition;
            if (low >= high)
                return low;

            i = Array[low];
            lowPosition = low;
            low++;

            while (low <= high)
            {
                while (low <= high && Array[low] <= Array[lowPosition])
                    low++;

                while (high >= low && Array[high] > Array[lowPosition])
                    high--;
                if (low < high)
                {
                    swap(ref Array[low], ref Array[high]);
                    print();
                }
            }

            // Finally we swap the pivot with the point high was pointing to
            swap(ref Array[lowPosition], ref Array[high]);
            print();

            return high;
        }

        public override void sort()
        {
            print();

            quickSort(0, Size - 1);
        }
        /* All code below is meant for the incremental Sorting process Calling incremental sort will perform one step of the sorting process*/
        int left, right, split;
        QuickSortPartition head;
        bool partitioning = false;
        private class QuickSortPartition
        {
            public int low, high;
            public QuickSortPartition next, prev;
            public QuickSortPartition(int low, int high)
            {
                this.low = low;
                this.high = high;
                next = prev = null;
            }
        }


        public void next()
        {
            // Check if head is null. If null, we're done
            if (head == null)
            {
                Console.WriteLine("Sorted");
                throw new Exception();
            }
            // Check if we're in the process of partitioning
            // This triggers if we are not
            if (!partitioning)
            {
                // Check if the partition is only one element
                // If yes, set the left, right, and splitting values
                if (head.low < head.high)
                {
                    partitioning = true;
                    left = head.low + 1;
                    right = head.high;
                    split = head.low;
                }
                // If partition is only one item, jump to next partition
                else
                {
                    head = head.next;
                }
            }
            // Enter if we are partitioning
            else
            {
                // Check if the left and right pointers have crossed
                // If we're here, we haven't swapped everything yet
                if (left <= right)
                {
                    // check if the number at right is greater than split
                    // move down if it is
                    if (Array[right] >= Array[split])
                    {
                        right--;
                    }
                    // check if the number at left is less than split
                    // move up if it is
                    else if (Array[left]<= Array[split])
                    {
                        left++;
                    }
                    // if we hit this, that means left and right both found something to swap
                    else
                    {
                        swap(ref Array[left], ref Array[right]);
                        print();

                    }
                }
                // left and right have crossed meaning all elements have been moved
                // swap split and high, turn off partition, and add to the partition list
                else
                {
                    partitioning = false;
                    swap(ref Array[split], ref Array[right]);
                    print();
                    split = right;

                    QuickSortPartition a, b, temp;
                    a = new QuickSortPartition(head.low, split - 1);
                    b = new QuickSortPartition(split + 1, head.high);
                    temp = head.next;
                    b.next = temp;

                    a.next = b;
                    head = a;

                }
            }
        }
    }
}
