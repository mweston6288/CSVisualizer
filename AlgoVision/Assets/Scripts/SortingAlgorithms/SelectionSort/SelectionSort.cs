using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class SelectionSort : SortingAlgorithm1
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] public GameObject canvas;

    private Boolean isPlay;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
    }

    public void setup(int size)
    {
        this.size = size;  // 70.2 63.8 -114.5
        arr = new int[size];
        array = new ArrayIndex[size];
        sort();
        setCam();
    }
    // Start is called before the first frame update
    override public void sort()
    {
        int smallest;
        buildArray(boxPrefab, canvas);

        for(int i = 0; i < size-1; i++)
        {
            smallest = i;

            for(int j = i+1; j < size; j++)
            {
                if(compare(j, smallest, 0) && arr[j] < arr[smallest])
                {
                    decompare(j, smallest, 0, 0);
                    smallest = j;
                }
                else{
                    decompare(j, smallest, 0, 0);
 
                }
            }
            swap(smallest, i);
            queue.Enqueue(new QueueCommand(3, i, (short)0, 2));
        }
        queue.Enqueue(new QueueCommand(3, size - 1, (short)0, 2));

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
        SceneManager.LoadScene("SelectionSortScene");
    }

    override public void extendCommands(QueueCommand q){
        throw new NotImplementedException();
    }
}
