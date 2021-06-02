using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InsertionSort : SortingAlgorithm
{
    [SerializeField] GameObject boxPrefab;
    
    public void setup(int size)
    {
        this.size = size;  // 70.2 63.8 -114.5
        arr = new int[size];
        array = new ArrayIndex[size];
        sort();
        setCam();
    }

    // Start is called before the first frame update
    void sort()
    {
        buildArray(boxPrefab);

        for(int i = 1; i < size; i++)
        {
            for(int j = i-1; j >= 0; j--)
            {
                if(compare(j, j+1, 4, 0) && arr[j] > arr[j+1])
                {
                    swap(j + 1, j, 0);
                    q.Enqueue(new short[] {1, (short)(j+1), (short)j, 0});

                }
                else
                {
                    break;
                }
            }
        }
        q.Enqueue(new short[] { 8, 0, 0, 0 });

    }

    override public IEnumerator extendCommands(short[] command){
        throw new NotImplementedException();
    }
}
