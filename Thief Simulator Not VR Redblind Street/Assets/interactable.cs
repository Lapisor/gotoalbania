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
        GetComponentInChildren<putOutFire>().interactionFunction();
    }
    public void contactSecondaryInteractable()
    {
        interactObject.GetComponent<openTheDoor>().secondaryInteractionFunction();
        if(GetComponentInChildren<exitTheHouse>() != null)
        {
            GetComponentInChildren<exitTheHouse>().interactionFunction();
        }       
    }
}
