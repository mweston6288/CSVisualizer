using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AVLUI : MonoBehaviour
{

    [SerializeField] AVL a;
    //[SerializeField] Slider speedSlider;

    // Start is called before the first frame update
    void Start()
    {
        a = new AVL();
        a.size = 0;
        int startSize = 2; // var startSize = FindObjectOfType<Dropdown>().value;
        //( whatever the inputfield is).gameObject.SetActive(false); // makes input field invisible

        switch (startSize)
        {
            case 0:
                {
                    a.insertRandom(7);
                    StartCoroutine(a.readQueue(0.0f));
                    break;
                }
            case 1:
                {
                    a.insertRandom(15);
                    StartCoroutine(a.readQueue(0.0f));
                    break;
                }
            case 2:
                {
                    a.insertRandom(31);
                    StartCoroutine(a.readQueue(0.0f));
                    break;
                }
            case 3:
                {
                    // make the input field visible
                    //convert input field value to integers, if possible
                    //send integers to insertion
                    break;
                }
            default:
                {
                    Debug.Log("Uh oh, i made a fucky wucky");
                    break;
                }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
