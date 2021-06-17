using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Submit : MonoBehaviour
{
    public void OnSubmit(BaseEventData eventData)
    {
        //Output that the Button is in the submit stage
        Debug.Log("Submitted!");
    }
}
