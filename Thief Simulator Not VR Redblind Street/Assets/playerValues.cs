
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

public class playerValues : MonoBehaviour
{

    public float monies;
    public float weightCarried;
    public Collider Jacob;
    public AudioClip deathSound;
    public GameObject deathScreen;
    public float deathTimer;
    public bool countingDown;
    public bool murderinTime;
    public AudioSource deathSFXplayer;

    public bool nearJacob;
    public float maxDeathTime = 0.6f;

    // Start is called before the first frame update
    void Start()
    {
        deathTimer = maxDeathTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (countingDown)
        {
            deathTimer -= 1 * Time.deltaTime;
        }
        if (deathTimer <= 0)
        {
            if(nearJacob != true)
            {
                maxDeathTime -= 0.1f;
            }
            else
            {
                if (Jacob.GetComponent<jacobAI>().stunned != true && Jacob.GetComponent<jacobAI>().notDetecting != true)
                {
                    
                    murderinTime = true;
                    
                }
                deathTimer = maxDeathTime;
                countingDown = false;
            }
            
        }
    }

    public void OnTriggerEnter(Collider Jacob)
    {
        
        if (Jacob.tag == "jacob")
        {
            Jacob.GetComponent<jacobAI>().notDetecting = false;
            if (nearJacob = true && Jacob.GetComponent<jacobAI>().stunned != true && Jacob.GetComponent<jacobAI>().notDetecting != true)
            {
                deathSFXplayer.PlayOneShot(deathSound, 1);
            }
            if(Jacob.GetComponent<jacobAI>().stunned != true && Jacob.GetComponent<jacobAI>().notDetecting != true)
            {
                countingDown = true;
                
            }
            
        }
        
    }
    public void OnTriggerStay(Collider Jacob)
    {
        if (Jacob.tag == "jacob")
        {
            if (murderinTime)
            {
                deathScreen.SetActive(true);
                this.GetComponent<FirstPersonController>().enabled = false;
            }
        }
        nearJacob = true;
    }

    public void OnTriggerExit(Collider Jacob)
    {
        if (Jacob.tag == "jacob")
        {
            nearJacob = false;
        }
    }

}
