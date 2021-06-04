using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BubbleSortUI : MonoBehaviour
{

    [SerializeField] BubbleSort v;
    [SerializeField] Slider speedSlider;

    private Boolean isPlay;
    // Start is called before the first frame update
    void Start()
    {
        //v = gameObject.AddComponent(typeof(BubbleSort)) as BubbleSort;
        v.setup(7);
        v.time = 1;
        isPlay = false;
        StartCoroutine(v.readQueue());
    }

    // Update is called once per frame
    void Update()
    {
        v.time = speedSlider.value;
    }
    public void reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void pauseAndPlay()
    {
        if (isPlay)
        {
            Time.timeScale = 1;
            isPlay = false;
        }
        else
        {
            Time.timeScale = 0;
            isPlay = true;
        }
    }
}

