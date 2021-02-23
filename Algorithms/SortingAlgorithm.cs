using System;
namespace Algorithms
{
    // SortingAlgorithm just needs to know how big the array will be.
    // It will make an array of that size and then shuffle the elements in the array
    abstract class SortingAlgorithm : Algorithm
    {
        protected int size;
        protected int[] array;

        public SortingAlgorithm(int size)
        {
            this.size = size;
            buildArray();
            print();
        }
        // Build an array and fill it with integers from 1 to size, then shuffle them
        private void buildArray()
        {
            int i;
            array = new int[size];
            Random r = new Random();

            for (i = 0; i < size; i++)
            {
                array[i] = i + 1;
            }

            for(i = 0; i < size; i++)
            {
                swap(ref array[i], ref array[r.Next(i, size)]);
            }
        }
        // since the size and array are global variables, there's no need to pass values into this function
        public abstract void sort();

        protected void swap(ref int x, ref int y)
        {
            int temp= x;
            x = y;
            y = temp;
        }
        // Mostly a debugging tool
        public void print()
        {
            for(int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}