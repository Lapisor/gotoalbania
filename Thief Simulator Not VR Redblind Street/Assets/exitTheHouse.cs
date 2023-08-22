using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;
using TMPro;

public class exitTheHouse : MonoBehaviour
{

    public FirstPersonController player;
    public NavMeshAgent Jacob;
    public TextMeshProUGUI theText2;
    public GameObject exitScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void interactionFunction()
    {
        player.enabled = false;
        player.gameObject.GetComponentInChildren<playerObjDetector>().theText.gameObject.SetActive(false);
        Jacob.isStopped = true;
        theText2.text = "You made: £" + player.gameObject.GetComponent<playerValues>().monies + " tonight";
        exitScreen.SetActive(true);
    }
}
