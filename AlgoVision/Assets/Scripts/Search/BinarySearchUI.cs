using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BinarySearchUI : MonoBehaviour
{
     [SerializeField] BinarySearch v;
    [SerializeField] Slider speedSlider;
    [SerializeField] InputField userInput;

    private Boolean isPlay;
    int startSize;
    // Start is called before the first frame update
    void Start()
    {
        speedSlider = FindObjectOfType<Slider>();

 
        v.time = 1;
        isPlay = false;
        userInput.OnSubmit(HandleSubmit);
    }

    void HandleSubmit(){
        startSize = FindObjectOfType<TMP_Dropdown>().value;

        if (startSize == 2)
        {
            v.setup(21, int.Parse(userInput.text));
        }
        else if (startSize == 1)
        {
            v.setup(13, userInput.text);
        }
        else
        {
            v.setup(8, userInput.text);
        }        

        StartCoroutine(v.readQueue());

    }
    // Update is called once per frame
    void Update()
    {
        v.time = speedSlider.value;
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