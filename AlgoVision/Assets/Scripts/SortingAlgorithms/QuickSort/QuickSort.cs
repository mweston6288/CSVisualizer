using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class QuickSort : SortingAlgorithm1
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] public GameObject canvas;

    private Boolean isPlay;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    public void setup(int size){
        this.size = size;
        arr = new int[size];
        array = new ArrayIndex[size];
        sort();
        setCam();
    }
    override public void sort(){
        buildArray(boxPrefab, canvas);
        timer.Restart();
        queue.Enqueue(new QueueCommand());
        quickSort(0, size - 1);
        timer.Stop();
        stopTime = timer.ElapsedMilliseconds;
    }   

    void quickSort(int low, int high)
    {

        if (low < high)
        {
            queue.Enqueue(new QueueCommand(6, low, high, 0, 3));

            int split = partition(low, high);
            queue.Enqueue(new QueueCommand(6, low, high, 0, 0));
            queue.Enqueue(new QueueCommand(3, split, (short)0, 2));

            quickSort(low, split - 1);
            quickSort(split + 1, high);
        }
        else
        {
            if( low > -1 && low < size)
            {
            queue.Enqueue(new QueueCommand(3, low, (short)0, 2));
            queue.Enqueue(new QueueCommand());
            }
            else
            {
            queue.Enqueue(new QueueCommand(3, high, (short)0, 2));
            queue.Enqueue(new QueueCommand());
            }
        }
    }

    int partition(int low, int high)
    {
        // Basically means I got a one-element array
        if (low >= high)
        {
            return low;
        }

        int lowPosition = low++; 

        
        // color the pointers
        queue.Enqueue(new QueueCommand(3, low, (short)0, 5));
        queue.Enqueue(new QueueCommand(3, high, (short)0, 6));
        queue.Enqueue(new QueueCommand());

        while (low <= high)
        {
            while (low <= high && compare(low, lowPosition, 0) && arr[low] <= arr[lowPosition]){
                decompare(low, lowPosition, 0, 5, 3); // lower indices
                queue.Enqueue(new QueueCommand(3, low, (short)0, 3)); // uncolor current low
                if (++low < size){
                    queue.Enqueue(new QueueCommand(3, low, (short)0, 5)); // color new low
                    queue.Enqueue(new QueueCommand());                    
                }


            }
            if (low <= high && arr[low] > arr[lowPosition])
                decompare(low, lowPosition, 0, 5, 3);

            while (high >= low && compare(high, lowPosition, 0)  && arr[high] > arr[lowPosition]){
                decompare(high, lowPosition, 0, 6, 3);
                queue.Enqueue(new QueueCommand(3, high, (short)0, 3));
                high--;
                queue.Enqueue(new QueueCommand(3, low, (short)0, 5)); // recolor low in case high was at the same index
                queue.Enqueue(new QueueCommand(3, high, (short)0, 6));
                queue.Enqueue(new QueueCommand());
            }
            if (high >= low && arr[high] <= arr[lowPosition])
                decompare(high, lowPosition, 0, 6, 3);

            if ( low < high)
            {
                swap(low, high);
                queue.Enqueue(new QueueCommand());
                queue.Enqueue(new QueueCommand(3, low, (short)0, 3));
                low++;
                queue.Enqueue(new QueueCommand(3, high, (short)0, 3));
                high--;
                queue.Enqueue(new QueueCommand(3, low, (short)0, 5));
                queue.Enqueue(new QueueCommand(3, high, (short)0, 6));
            }
        }
        // Finally we swap the pivot with the point high was pointing to
        swap(lowPosition, high);

        return high;
    }

    public void pauseAndPlay()
    {
        if (isPlay)
        {
            Time.timeScale = 1;
            isPlay = false;
            canvas.transform.GetChild(2).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1);
        }
        else
        {
            Time.timeScale = 0;
            isPlay = true;
            canvas.transform.GetChild(2).GetComponent<Image>().color = new Color(0.573f, 1f, 0f, 1);
        }
    }

    public void restartScene()
    {
        SceneManager.LoadScene("QuickSortScene");
    }

    override public IEnumerator extendCommands(QueueCommand q){
        throw new NotImplementedException();
    }
/* static int size = 100;
    int leftPointer, rightPointer, split;
    QuickSortPartition head;
    bool partitioning = false;

    public QuickSort() : base(size)
    {
        head = new QuickSortPartition(0, size - 1);
    }

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


    // Start is called before the first frame update
    void Start()
    {
        // build the GameObject shape, size, and positions
        for (int i = 0; i < size; i++)
        {
            array[i] = GameObject.CreatePrimitive(PrimitiveType.Cube);
            array[i].transform.position = new Vector3((float)i, .5f * i, 0);
            array[i].transform.localScale = new Vector3(1, i + 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (head == null)
        {
            return;
        }
        // First, have the SortingAlgorithm shuffle the array
        if (!unsorted)
        {
            shuffle();
        }
        else
        {
            // Check if we're in the process of partitioning
            // This triggers if we are not
            if (!partitioning)
            {
                // Check if the partition is only one element
                // If yes, set the left, right, and splitting values
                if (head.low < head.high)
                {
                    partitioning = true;
                    leftPointer = head.low + 1;
                    rightPointer = head.high;
                    split = head.low;
                    array[leftPointer].GetComponent<Renderer>().material.color = Color.red;
                    array[rightPointer].GetComponent<Renderer>().material.color = Color.red;
                    array[split].GetComponent<Renderer>().material.color = Color.red;


                }
                // A catcher line. head.low could potentially be out of bounds so if this happens, just discard the partition
                else if (head.low >= size)
                {
                    head = head.next;
                }
                // If partition is only one item, jump to next partition
                else
                {
                    array[head.low].GetComponent<Renderer>().material.color = Color.green;
                    head = head.next;
                }
            }
            // Enter if we are partitioning
            else
            {
                // Check if the left and right pointers have crossed
                // If we're here, we haven't swapped everything yet
                if (leftPointer <= rightPointer)
                {
                    // check if the number at left is less than split
                    // move up if it is
                    if (array[leftPointer].transform.position.y <= array[split].transform.position.y)
                    {
                        array[leftPointer++].GetComponent<Renderer>().material.color = Color.white;
                        array[leftPointer].GetComponent<Renderer>().material.color = Color.red;
                    }
                    // check if the number at right is greater than split
                    // move down if it is
                    else if (array[rightPointer].transform.position.y >= array[split].transform.position.y)
                    {
                        array[rightPointer--].GetComponent<Renderer>().material.color = Color.white;
                        array[rightPointer].GetComponent<Renderer>().material.color = Color.red;

                    }
                    // if we hit this, that means left and right both found something to swap
                    else
                    {
                        swapPointers();
                    }
                }
                // left and right have crossed meaning all elements have been moved
                // swap split and high, turn off partition, and add to the partition list
                else
                {
                    swapSplitter();
                    if (!isMoving)
                    {
                        array[rightPointer].GetComponent<Renderer>().material.color = Color.green;

                        partitioning = false;

                        QuickSortPartition a, b, temp;
                        a = new QuickSortPartition(head.low, rightPointer - 1);
                        // THis line could potentially cause an OutOfBounds Exception if the split happened at the very last value
                        b = new QuickSortPartition(rightPointer + 1, head.high);
                        temp = head.next;
                        b.next = temp;

                        a.next = b;
                        head = a;
                    }

                }
            }
        }
    }
    // set up the variables in SortingAlgorithm that handle moving objects then call movePieces
    public void swapPointers()
    {
        if (!isMoving)
        {
            left = leftPointer;
            right = rightPointer;
            isMoving = true;
            leftOriginal = array[left].transform.position.x;
            rightOriginal = array[right].transform.position.x;
        }
        movePieces();
    }
    public void swapSplitter()
    {
        if (!isMoving)
        {
            left = split;
            right = rightPointer;
            isMoving = true;
            leftOriginal = array[left].transform.position.x;
            rightOriginal = array[right].transform.position.x;
        }
        movePieces();
    }*/
}
