using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openTheDoor : MonoBehaviour
{

    public bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            GetComponentInParent<interactable>().displayMessage = "'F' to Close Door";
            GetComponentInParent<interactable>().enabled = false;

        }
        if (doorOpen != true)
        {
            GetComponentInParent<interactable>().displayMessage = "'F' to Open Door";
        }
    }

    public void secondaryInteractionFunction()
    {
        if (doorOpen)
        {

        }
        else
        {
            GetComponentInParent<Animation>().Play();
            doorOpen = true;
        }
    }
}