
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
    public TextMeshProUGUI theText2;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(2,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "object")
        {
            theText.gameObject.SetActive(true);
            theText.text = "'E' to pick up " + other.GetComponent<StealableObject>().name;
            if (Input.GetKey(KeyCode.E))    
            {
                player.monies += other.GetComponent<StealableObject>().value;
                player.weightCarried += other.GetComponent<StealableObject>().mass;
                other.gameObject.SetActive(false);
                theText.gameObject.SetActive(false);
                theUpdater.updateGoddammit();
                Jacob.GetComponent<NavMeshAgent>().speed += 0.1f;
                Jacob.GetComponent<NavMeshAgent>().acceleration += 0.1f;
                Jacob.GetComponent<NavMeshAgent>().speed += (player.monies / 10000);
                Jacob.GetComponent<NavMeshAgent>().acceleration += (player.monies / 11000);
                Jacob.GetComponent<NavMeshAgent>().angularSpeed += 45f;
            }
        }
        if (other.tag == "interactable")
        {
            theText.gameObject.SetActive(true);
            theText.text = "'E' to leave";
            if (Input.GetKey(KeyCode.E))
            {

                GetComponentInParent<FirstPersonController>().enabled = false;
                theText.gameObject.SetActive(false);
                Jacob.GetComponent<NavMeshAgent>().isStopped = true;
                theText2.text = "You made: £" + player.monies + " tonight";
                exitScreen.SetActive(true);
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "object")
        {
            theText.gameObject.SetActive(false);
        }
    }
}
