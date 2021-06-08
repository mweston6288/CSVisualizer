using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class InsertionSort : SortingAlgorithm1
{
    [SerializeField] GameObject boxPrefab;
    [SerializeField] GameObject canvas;
    
    private Boolean isPlay;


    // Start is called before the first frame update
    override public void sort()
    {
        buildArray(boxPrefab, canvas);
        timer.Restart();
        int i,j;
        for(i = 1; i < size; i++)
        {
            for(j = i-1; j >= 0; j--)
            {
                if(compare(j, j+1, 0) && arr[j] > arr[j+1])
                {
                    swap(j + 1, j);
                }
                else
                {
                    queue.Enqueue(new QueueCommand(7, arr[j] + " and " + arr[j+1] + " unchanged"));
                    decompare(j, j+1, 0, 2);

                    break;
                }
                decompare(j, j+1, 0, 2);

            }
            queue.Enqueue(new QueueCommand(7, "Indices 0 through " + i + " are in sorted order"));
            queue.Enqueue(new QueueCommand());

        }
        queue.Enqueue(new QueueCommand(6, 0, size - 1, 0, 2));

        timer.Stop();
        stopTime = timer.ElapsedMilliseconds;
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
        SceneManager.LoadScene("InsertionSortScene");
    }

    override public IEnumerator extendCommands(QueueCommand q){
        throw new NotImplementedException();
    }
}
