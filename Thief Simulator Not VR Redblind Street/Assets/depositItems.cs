using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class depositItems : MonoBehaviour
{
    public playerValues player;
    public valueUpdater theUpdater;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.weightCarried > 0)
        {
            this.GetComponentInParent<interactable>().displayMessage = "'F' to exit the house<br>'E' to deposit items";
        }
        else
        {
            this.GetComponentInParent<interactable>().displayMessage = "'F' to exit the house";
        }
    }

    public void interactionFunction()
    {
        player.weightCarried = 0;
        player.monies += player.holdingWorth;
        player.holdingWorth = 0;
        theUpdater.updateGoddammit();
        player.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 3 * ((2000 - player.weightCarried) / 3000);
        player.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 6 * ((2000 - player.weightCarried) / 3000);
    }
}