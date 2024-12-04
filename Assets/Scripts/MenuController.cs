using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // MenuCanvas to be manipulated
    public GameObject MenuCanvas;
    // time to allow before menu can be toggled again
    public float waitTime = 3f;

    private bool CanvasOn;
    private bool CanToggle = true;
    
    // Start is called before the first frame update
    void Start()
    {
        // sets the CanvasOn bool
        if (MenuCanvas.activeSelf)
        {
            CanvasOn = true;
        }
        else
        {
            CanvasOn = false;
        }

        CanToggle = true;
    }

    // Update is called once per frame
    void Update()
    {
        // checks the imput of the controller start button and if canToggle is true
        // then sets the canvas to active or un-active and starts the wait process
        if (OVRInput.Get(OVRInput.Button.Start) && CanToggle)
        {
            if (CanvasOn)
            {
                MenuCanvas.SetActive(false);
                CanvasOn = false;
            }
            else
            {
                MenuCanvas.SetActive(true);
                CanvasOn = true;
            }

            CanToggle = false;
            StartCoroutine(AllowToggle(waitTime));
        }
    }

    // Coroutine to allow toggling of the canvas again 
    IEnumerator AllowToggle(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CanToggle = true;
    }
}
