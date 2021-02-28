namespace Algorithms{
	class MergeSort : SortingAlgorithm{
        public MergeSort(int size) : base(size)
        {
        }

        private void merge(int[] array, int low, int middle, int high)
		{
			int i, j, k;
			int n1 = middle - low + 1;
			int n2 = high - middle;

			int[] leftArray = new int[n1];
			int[] rightArray = new int[n2];
            MemoryUse += sizeof(int) * (high - low + 1);
			
			for (i = 0; i < n1; i++)
			{
				leftArray[i] = array[low + i];
			}

			for (j = 0; j < n2; j++)
			{
				rightArray[j] = array[middle + 1 + j];
			}

			i = 0;
			j = 0;
			k = low; 

			while (i < n1 && j < n2)
			{
				if (leftArray[i] <= rightArray[j])
				{
					array[k] = leftArray[i];
					i++;
				}
				else
				{
					array[k] = rightArray[j];
					j++;
				}
				k++; 
			}

			while (i < n1)
			{
				array[k] = leftArray[i];
				i++;
				k++;
			}
			while (j < n2)
			{
				array[k] = rightArray[j];
				j++;
				k++;
			}
            MemoryUse -= sizeof(int) * (high - low + 1);

        }

        private void sort(int[] array, int low, int high){
            StackSize++;
            if (low < high)
			{
				int med = (low + high - 1) / 2;

				sort(array, low, med);
				sort(array, med + 1, high);

				merge(array, low, med, high);
			}
            StackSize--;

        }
        public override void sort(){
			sort(Array, 0, Size - 1);
		}
	}
}