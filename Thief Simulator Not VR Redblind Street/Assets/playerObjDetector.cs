
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
using UnityStandardAssets.Characters.FirstPerson;

public class playerObjDetector : MonoBehaviour
{

    public TextMeshProUGUI theText;
    public playerValues player;
    public valueUpdater theUpdater;
    public GameObject Jacob;

    public GameObject exitScreen;

    public GameObject selectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Physics.IgnoreLayerCollision(1, 4);
    }

    public void OnTriggerStay(Collider other)
    {
        selectedObject = other.gameObject;
        if (selectedObject.tag == "object")
        {
            theText.gameObject.SetActive(true);
            theText.text = "'E' to pick up " + other.GetComponent<StealableObject>().name;
            if (Input.GetKey(KeyCode.E))    
            {
                player.monies += selectedObject.GetComponent<StealableObject>().value;
                player.weightCarried += other.GetComponent<StealableObject>().mass;
                selectedObject.gameObject.SetActive(false);
                theText.gameObject.SetActive(false);
                theUpdater.updateGoddammit();
                if(Jacob.GetComponent<NavMeshAgent>().speed <= 8)
                {
                    Jacob.GetComponent<NavMeshAgent>().speed += 0.004f;
                    Jacob.GetComponent<NavMeshAgent>().acceleration += 0.004f;
                    Jacob.GetComponent<NavMeshAgent>().speed += (player.monies / 180000);
                    Jacob.GetComponent<NavMeshAgent>().acceleration += (player.monies / 182000);
                    Jacob.GetComponent<NavMeshAgent>().angularSpeed += 4f;
                }
            }
        }
        if (selectedObject.tag == "interactable")
        {
            theText.gameObject.SetActive(true);
            theText.text = selectedObject.GetComponent<interactable>().displayMessage;

            if (Input.GetKey(KeyCode.E))
            {
                selectedObject.GetComponent<interactable>().contactInteractable();

            }
            if (Input.GetKey(KeyCode.F))
            {
                selectedObject.GetComponent<interactable>().contactSecondaryInteractable();

            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "object")
        {
            theText.gameObject.SetActive(false);
        }
        if (other.tag == "interactable")
        {
            theText.gameObject.SetActive(false);
        }
    }
}
