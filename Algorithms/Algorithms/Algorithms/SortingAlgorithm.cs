/*
	Generic class for all sorting algorithms
*/


﻿namespace Algorithms
{

    abstract class SortingAlgorithm : Algorithm
    {


        public abstract void sort(int[] array, int size);

        protected void swap(ref int x, ref int y)
        {
            int temp= x;
            x = y;
            y = temp;
        }
    }
}
