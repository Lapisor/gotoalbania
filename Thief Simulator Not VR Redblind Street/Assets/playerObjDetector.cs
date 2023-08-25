
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
        if(this.GetComponentInParent<crouchScript>().isCrouching != true)
        {
            if (player.weightCarried < 1650)
            {
                player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 3 * ((2000 - player.weightCarried) / 3000);
                player.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 6 * ((2000 - player.weightCarried) / 3000);
            }
            else
            {
                player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0.4f;
                player.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 0.8f;
            }
        }
        else
        {
            if (player.weightCarried < 1650)
            {
                player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 1.5f * ((2000 - player.weightCarried) / 3000);
                player.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 3 * ((2000 - player.weightCarried) / 3000);
            }
            else
            {
                player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0.2f;
                player.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 0.4f;
            }
        }
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
                if(player.weightCarried + selectedObject.GetComponent<StealableObject>().mass <= 2000)
                {
                    player.holdingWorth += selectedObject.GetComponent<StealableObject>().value;
                    player.weightCarried += selectedObject.GetComponent<StealableObject>().mass;
                    selectedObject.gameObject.SetActive(false);
                    theText.gameObject.SetActive(false);
                    theUpdater.updateGoddammit();
                    if (player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed < 1)
                    {

                    }
                    else
                    {
                        if(player.weightCarried < 1650)
                        {
                            player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 3 * ((2000 - player.weightCarried) / 3000);
                            player.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 6 * ((2000 - player.weightCarried) / 3000);
                        }
                        else
                        {
                            player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0.4f;
                            player.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 0.8f;
                        }
                        
                    }
                    if (Jacob.GetComponent<NavMeshAgent>().speed <= 6)
                    {
                        Jacob.GetComponent<NavMeshAgent>().speed += 0.001f;
                        Jacob.GetComponent<NavMeshAgent>().acceleration += 0.001f;
                        Jacob.GetComponent<NavMeshAgent>().speed += (player.monies / 360000);
                        Jacob.GetComponent<NavMeshAgent>().acceleration += (player.monies / 362000);
                        Jacob.GetComponent<NavMeshAgent>().angularSpeed += 4f;
                    }
                }
            }
        }
        if (selectedObject.tag == "interactable")
        {
            if(selectedObject)
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
