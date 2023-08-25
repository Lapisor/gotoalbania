using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interactable : MonoBehaviour
{

    public string displayMessage;
    public GameObject interactObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void contactInteractable()
    {
        if (interactObject.GetComponent<putOutFire>() != null)
        {
            GetComponentInChildren<putOutFire>().interactionFunction();
        }
        if (interactObject.GetComponent<depositItems>() != null)
        {
            GetComponentInChildren<depositItems>().interactionFunction();
        }
    }
    public void contactSecondaryInteractable()
    {
        if (interactObject.GetComponent<openTheDoor>() != null)
        {
            interactObject.GetComponent<openTheDoor>().secondaryInteractionFunction();
        }
        if (interactObject.GetComponent<exitTheHouse>() != null)
        {
            interactObject.GetComponent<exitTheHouse>().interactionFunction();
        }  
    }
}
